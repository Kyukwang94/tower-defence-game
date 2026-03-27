using Game.Enums;
using Godot;
using System;

public sealed record Address(Vector2I Cell);

public partial class BuildingNode : Node2D, IInitializable
{

	private Address _address;
	private BuildingResource _resource;
	private LayerBag _layerBag;

	private bool _isActivated = false;

	[Export] private BuildingResource _editorResource;
	public BuildingResource EditorResource => _editorResource;
	
	#region NoUse
	public BuildingNode() : base() { }
	#endregion


	#region For Runtime
	public override void _Ready()
	{
		//런타임
		if (_layerBag != null)
		{
		Activate();
		}
	}

	public BuildingNode(Address address, BuildingResource resource, LayerBag bag)
	{
		_address = address ?? throw new ArgumentNullException(nameof(address));
		_resource = resource ?? throw new ArgumentNullException(nameof(resource));
		_layerBag = bag ?? throw new ArgumentNullException(nameof(bag));
	}
	#endregion

	#region For Editor
	
	public void Initialize(LayerBag bag)
	{
		new BuildingConstruction(this, bag).Shipping();

		if (_resource.MyType != OccupancyType.None)
		{
			new OccupancyLedger(bag.occupancy).MarkShape(_address.Cell, _resource.Shape, _resource.MyType);
		}
	}

	public void Initialize(Address address, BuildingResource resource, LayerBag layerBag)
	{
		_address = address ?? throw new ArgumentNullException(nameof(address));
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

		_isActivated = true;

		GD.Print($"[Building] 활성화 완료 - Cell: {_address.Cell}, Type: {_resource.MyType}");
	}


	#endregion
}