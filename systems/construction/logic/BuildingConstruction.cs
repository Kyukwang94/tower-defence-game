using System;
using Godot;

public sealed class BuildingConstruction : IConstruction
{
	private readonly Address _runtimeAddress;
	private readonly BuildingResource _resource;
	
	public BuildingConstruction(Address address, BuildingResource resource)
	{
		_runtimeAddress = address;
		_resource = resource;
	}

	public void Execute(Board board)
	{
		var building = _resource.scene.Instantiate<BuildingNode>();
		board.PlaceBuilding(building, _resource, _runtimeAddress.StartCell);
	}
}
