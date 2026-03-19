using Game.Enums;
using Godot;
using System;

public sealed record Address(Vector2I Cell);

/// <summary>
/// User가 런타임때 Building을 설치할때의 객체 초기화와 
/// 미리 존재하는 객체가 있을때 이 둘을 통합하는 시스템
/// </summary>
public partial class Building : Node2D, ILayerConsumer
{
	private Address _location;
	private BuildingResource _buildingResource;
	private LayerBag _layerBag;

	private bool _isActivated = false;

	[Export] private BuildingResource _editorResource;


	public Building() : base() { }

	//RunTime 객체 초기화
	public Building(Address location, BuildingResource resource, LayerBag bag)
	{
		_location = location ?? throw new ArgumentNullException(nameof(location));
		_buildingResource = resource ?? throw new ArgumentNullException(nameof(resource));
		_layerBag = bag ?? throw new ArgumentNullException(nameof(bag));
	}

	//Editor 객체 초기화
	private void InitFromEditor()
	{
		if (_editorResource == null)
			throw new InvalidOperationException($"[Building] 에디터 리소스가 설정되지 않았습니다.");

		_buildingResource = _editorResource;

		Vector2I point = _layerBag.building.LocalToMap(Position);
		_location = new Address(point);
	}

	//editor용 실행.
	public void SetUp(LayerBag layerBag)
	{

		if (_layerBag != null) return;
		_layerBag = layerBag;


		if (_buildingResource == null)
		{
			InitFromEditor();
		}
		
		Activate();
	}
	
	public override void _Ready()
	{
		//런타임
		if (_layerBag != null)
		{
			Activate();
		}
	}
	
	//RunTime , Editor 모두 객체 초기화 완료되었다고 보장
	private void Activate()
	{
		if (_isActivated || _layerBag == null || _buildingResource == null) return;

		var visual = _buildingResource.scene.Instantiate();
		AddChild(visual);

		Vector2 centerPos = _layerBag.building.MapToLocal(_location.Cell);
		Vector2 halfTile = new(16, 16);
		Position = centerPos - halfTile;

		if (_buildingResource.MyType != OccupancyType.None)
		{
			RecordToOccupancy();
		}
		_isActivated = true;

		GD.Print($"[Building] 활성화 완료 - Cell: {_location.Cell}, Type: {_buildingResource.MyType}");
	}

	private void RecordToOccupancy()
	{
		int currentVal = _layerBag.occupancy.GetCellSourceId(_location.Cell);
		int existing = (currentVal == -1) ? 0 : currentVal;

		_layerBag.occupancy.SetCell(
			_location.Cell,
			existing | (int)_buildingResource.MyType,
			Vector2I.Zero
		);
	}

	
}