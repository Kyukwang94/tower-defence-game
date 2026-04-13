
using Godot;
public sealed class PlaceBuildingAction : IBoardAction
{
	BuildingNode _node;
	BuildingResource _resource ;
	Vector2I _cell;
	public PlaceBuildingAction(BuildingNode node, BuildingResource resource, Vector2I cell )
	{
		_node = node;
		_resource = resource;
		_cell = cell;
	}
	
	public void Execute(BoardContext boardContext)
	{
		if (_node.GetParent() == null)
			boardContext.LayerProvider.Building.AddChild(_node);

		Vector2 centerPos = boardContext.LayerProvider.Building.MapToLocal(_cell);
		Vector2 finalPos = centerPos - new Vector2(16, 16);
		Address address = new(_cell, _resource.Shape.Duplicate());
		_node.Setup(address, _resource, finalPos);

		boardContext.OccupancyLedger.MarkShape(_node.Address, _resource.MyType);
		boardContext.OccupancyLedger.RegisterOccupant(_node, _resource, _cell);
	}
}