using Game.Enums;
using Godot;
using System;

public sealed record GridLocation(Vector2I Cell);

public partial class Building : Node2D, ILayerConsumer
{
    private GridLocation _location;
    private BuildingResource _buildingResource;
    private LayerBag _layerBag;

    
    [Export] private BuildingResource _editorResource;

    
    public Building() : base() { }

    public Building(GridLocation location, BuildingResource resource, LayerBag bag)
    {
        _location = location ?? throw new ArgumentNullException(nameof(location));
        _buildingResource = resource ?? throw new ArgumentNullException(nameof(resource));
        _layerBag = bag ?? throw new ArgumentNullException(nameof(bag));
    }

    public void SetUp(LayerBag layerBag)
    {
        // 중복 초기화 방지 (객체의 무결성 보호)
        if (_layerBag != null) return;
        _layerBag = layerBag;

        // 1. 데이터 보완 (에디터 배치 시 부족한 정보 채우기)
        if (_buildingResource == null)
        {
            HydrateFromEditor();
        }

        // 2. 존재의 증명 (모든 건물이 공통으로 수행해야 하는 의무)
        Activate();
    }

    private void HydrateFromEditor()
    {
        if (_editorResource == null)
            throw new InvalidOperationException("[Building] 에디터 리소스가 설정되지 않았습니다.");

        _buildingResource = _editorResource;
        
        // 현재 Position(Pixel)을 그리드 좌표(Cell)로 변환하여 영혼(Location)을 만듭니다.
        Vector2I cellPos = _layerBag.building.LocalToMap(Position);
        _location = new GridLocation(cellPos);
    }

    private void Activate()
    {
        // 시각적 육체 소환
        var visual = _buildingResource.scene.Instantiate();
        AddChild(visual);

        // 물리적 위치 확정 (그리드 스냅)
        // [수정된 로직]: MapToLocal은 중심점을 주므로, 오프셋을 빼서 좌상단 기준인 에디터 스냅과 맞춥니다.
        Vector2 centerPos = _layerBag.building.MapToLocal(_location.Cell);
        Vector2 halfTile = new Vector2(16, 16); 
        Position = centerPos - halfTile;

        // 장부(Occupancy Layer)에 기록
        if (_buildingResource.MyType != OccupancyType.None)
        {
            RecordToOccupancy();
        }

        GD.Print($"[Building] 활성화 완료 - Cell: {_location.Cell}, Type: {_buildingResource.MyType}");
    }

    private void RecordToOccupancy()
    {
        int currentVal = _layerBag.occupancy.GetCellSourceId(_location.Cell);
        int existing = (currentVal == -1) ? 0 : currentVal;
        
        // 비트 OR 연산을 통해 기존 점유 정보와 나의 타입을 합칩니다.
        _layerBag.occupancy.SetCell(
            _location.Cell, 
            existing | (int)_buildingResource.MyType, 
            Vector2I.Zero
        );
    }

    public override void _Ready()
    {
        // 런타임에 new로 생성된 경우, AddChild 직후에 이미 데이터가 있으므로 
        // 스스로 활성화를 시도할 수 있습니다. (Board의 SetUp을 기다리지 않는 경우 대비)
        if (_layerBag != null && GetChildCount() == 0)
        {
            Activate();
        }
    }
}