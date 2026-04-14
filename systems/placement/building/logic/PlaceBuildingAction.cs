
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
	
	public void Execute(BoardEnvironment boardEnv)
	{
		boardEnv.InstallBuilding(_node, _cell);
	}
}