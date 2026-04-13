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

	public void Execute(BoardContext context)
	{	
		var building = _resource.scene.Instantiate<BuildingNode>();
		context.Board.ActOn(new PlaceBuildingAction(building, _resource, _runtimeAddress.StartCell));
	}
}
