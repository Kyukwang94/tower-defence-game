using System;
using Godot;

public sealed class BuildingConstruction : IConstruction
{
	private readonly Address _runtimeAddress;
	private readonly BuildingResource _resource;
	private readonly BuildingNode _existingBuilding;

	//Runtime Initialize
	public BuildingConstruction(Address address, BuildingResource resource)
	{
		_runtimeAddress = address; 
		_resource = resource;
		_existingBuilding = null;
	}

	//Editor Initialize
	public BuildingConstruction(Node2D existingNode)
	{
		_existingBuilding = existingNode as BuildingNode ?? throw new ArgumentException($"{nameof(existingNode)}는 Building 타입이어야 합니다.");
		_resource = _existingBuilding.EditorResource ?? throw new InvalidOperationException("에디터 리소스가 비어있습니다.");
	}

	public BuildingNode Execute(Board board)
	{
		if(_existingBuilding != null)
		{
			return board.EditorBuildingPlacement(_existingBuilding,_resource);
		}

		//RunTime 
		return board.BuildNewBuilding(_resource, _runtimeAddress);
	}
}
