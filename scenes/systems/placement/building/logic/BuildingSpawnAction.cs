using Godot;
using System;

/// <summary>
/// [Elegant Objects] 건물을 생성하고 세상(Scene Tree)에 배치하는 액션입니다.
/// </summary>
public sealed class BuildingSpawnAction : IGridCellAction
{
    private readonly BuildingBluePrint _bluePrint;
    private readonly LayerBag _layerBag;

    public BuildingSpawnAction(BuildingBluePrint bluePrint, LayerBag layerBag)
    {
        // 생성자에서는 오직 할당만 수행합니다. (No Logic in Constructor)
        _bluePrint = bluePrint ?? throw new ArgumentNullException(nameof(bluePrint));
        _layerBag = layerBag ?? throw new ArgumentNullException(nameof(layerBag));
    }

    /// <summary>
    /// 지정된 셀 위치에 건물을 실제로 생성합니다.
    /// </summary>
    public void OnCell(TileMapLayer layer, Vector2I cell)
    {
        // 1. 객체의 정체성(Location) 정의
        GridLocation location = new GridLocation(cell);

        // 2. 객체의 탄생 (우리가 정의한 '진짜 문'을 통해 생성)
        // 이 시점에 Building은 영혼(Location)과 육체(Resource), 도구(LayerBag)를 모두 가집니다.
        Building building = new Building(
            location, 
            _bluePrint.Resource, 
            _layerBag
        );

        // 3. 세상(Scene Tree)에 입성
        // AddChild가 호출되는 순간, Building 내부의 _Ready()가 실행되면서 
        // 스스로 시각화(Instantiate)와 장부 기록을 시작합니다.
        layer.AddChild(building);
        
        GD.Print($"[BuildingSpawnAction] 건물을 소환했습니다: {cell}");
    }

    /// <summary>
    /// 설치가 가능한 상태인지 기초적인 확인을 수행합니다.
    /// 상세한 점유 검사는 OccupancyAction 데코레이터에게 맡깁니다.
    /// </summary>
    public bool TryOnCell(TileMapLayer layer, Vector2I cell)
    {
        return _bluePrint != null && _bluePrint.Resource != null;
    }
}