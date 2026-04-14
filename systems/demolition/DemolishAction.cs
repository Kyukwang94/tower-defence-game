using Godot;


public sealed class DemolishAction : IBoardAction
{
	private readonly Vector2I _cell;
	public DemolishAction(Vector2I cell)
	{
		_cell = cell;
		
	}
	public void Execute(BoardEnvironment boardEnv)
	{
		boardEnv.DemolishBuilding(_cell);
	}
}