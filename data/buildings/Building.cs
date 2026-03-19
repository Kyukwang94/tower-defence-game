using Game.Enums;
using Godot;
using System;

public sealed record Address(Vector2I Cell);


public partial class Building : Node2D, ILayerConsumer
{
	private Address _location;
	private BuildingResource _buildingResource;
	private LayerBag _layerBag;


	[Export] private BuildingResource _editorResource;


	public Building() : base() { }

	public Building(Address location, BuildingResource resource, LayerBag bag)
	{
		_location = location ?? throw new ArgumentNullException(nameof(location));
		_buildingResource = resource ?? throw new ArgumentNullException(nameof(resource));
		_layerBag = bag ?? throw new ArgumentNullException(nameof(bag));
	}

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

	private void InitFromEditor()
	{
		if (_editorResource == null)
			throw new InvalidOperationException("[Building] 에디터 리소스가 설정되지 않았습니다.");

		_buildingResource = _editorResource;

		Vector2I point = _layerBag.building.LocalToMap(Position);
		_location = new Address(point);
	}

	private void Activate()
	{
		var visual = _buildingResource.scene.Instantiate();
		AddChild(visual);


		Vector2 centerPos = _layerBag.building.MapToLocal(_location.Cell);
		Vector2 halfTile = new(16, 16);
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

		_layerBag.occupancy.SetCell(
			_location.Cell,
			existing | (int)_buildingResource.MyType,
			Vector2I.Zero
		);
	}

	public override void _Ready()
	{
		//객체가 동적으로 생성되었을때
		if (_layerBag != null)
		{
			Activate();
		}
	}
}