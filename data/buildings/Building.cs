using Game.Enums;
using Godot;
using System;

public sealed record Address(Vector2I Cell);

public partial class Building : Node2D, IInitializable
{

	private Address _address;
	private BuildingResource _resource;
	private LayerBag _layerBag;

	private bool _isActivated = false;

	[Export] private BuildingResource _editorResource;
	public BuildingResource EditorResource => _editorResource;

	#region NoUse
	public Building() : base() { }
	#endregion

	public override void _Ready()
	{
		//런타임
		if (_layerBag != null)
		{
			Activate();
		}
	}

	#region For Editor
	public Building(Address address, BuildingResource resource, LayerBag bag)
	{
		_address = address ?? throw new ArgumentNullException(nameof(address));
		_resource = resource ?? throw new ArgumentNullException(nameof(resource));
		_layerBag = bag ?? throw new ArgumentNullException(nameof(bag));
	}
	
	//Editor Trigger 
	public void Initialize(LayerBag bag)
	{
		new BuildingConstruction(this, bag).Shipping();
	}

	//에디터로 미리 생성된 객체에 불완전한 상태 완전한 상태로 초기화.
	public void Initialize(Address address, BuildingResource resource, LayerBag layerBag)
	{
		_address  = address  ?? throw new ArgumentNullException(nameof(address));
		_resource = resource ?? throw new ArgumentNullException(nameof(resource));
		_layerBag = layerBag ?? throw new ArgumentNullException(nameof(layerBag));

		Activate();
	}
	#endregion

	#region Runtime/Editor 공용
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
	#endregion
}