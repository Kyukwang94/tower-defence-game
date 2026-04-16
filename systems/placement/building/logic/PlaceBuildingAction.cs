
using Godot;
public sealed class PlaceBuildingAction : IBoardAction
{
	BuildingNode _node;
	Vector2I _cell;
	public PlaceBuildingAction(BuildingNode node, Vector2I cell )
	{
		_node = node;
		_cell = cell;
	}
	
	public void Execute(IBoard board)
	{
		new BuildingInstallation(board.Layers, board.Ledger, _node, _node.Resource, _cell ).Install();
	}
}