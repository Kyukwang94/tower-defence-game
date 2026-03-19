using Game.Enums;
using Godot;
using System;

public sealed record Address(Vector2I Cell);

/// <summary>
/// User가 런타임때 Building을 설치할때의 객체 초기화와 
/// 미리 존재하는 객체가 있을때 이 둘을 통합하는 시스템
/// </summary>
public partial class Building : Node2D , ILayerConsumer
{
	private Address _address;
	private BuildingResource _resource;
	private LayerBag _layerBag;

	private bool _isActivated = false;

	[Export] private BuildingResource _editorResource;
	public BuildingResource EditorResource => _editorResource;

	public Building() : base() { }

	//RunTime 객체 초기화
	public Building(Address location, BuildingResource resource, LayerBag bag)
	{
		_address = location ?? throw new ArgumentNullException(nameof(location));
		_resource = resource ?? throw new ArgumentNullException(nameof(resource));
		_layerBag = bag ?? throw new ArgumentNullException(nameof(bag));
	}

	public void SetUp(Address address, BuildingResource resource, LayerBag layerBag )
	{

		_address = address;
		_resource = resource;
		_layerBag = layerBag;
		
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
		if (_isActivated || _layerBag == null || _resource == null) return;

		var visual = _resource.scene.Instantiate();
		AddChild(visual);

		Vector2 centerPos = _layerBag.building.MapToLocal(_address.Cell);
		Vector2 halfTile = new(16, 16);
		Position = centerPos - halfTile;

		if (_resource.MyType != OccupancyType.None)
		{
			RecordToOccupancy();
		}
		_isActivated = true;

		GD.Print($"[Building] 활성화 완료 - Cell: {_address.Cell}, Type: {_resource.MyType}");
	}

	private void RecordToOccupancy()
	{
		int currentVal = _layerBag.occupancy.GetCellSourceId(_address.Cell);
		int existing = (currentVal == -1) ? 0 : currentVal;

		_layerBag.occupancy.SetCell(
			_address.Cell,
			existing | (int)_resource.MyType,
			Vector2I.Zero
		);
	}

	public void SetUp(LayerBag layerBag)
	{
		
	}

}