using Godot;


public sealed class DemolishAction : IBoardAction
{
	private readonly Vector2I _cell;
	private readonly IBoard _board;
	public DemolishAction(IBoard board, Vector2I cell)
	{
		_board = board;
		_cell = cell;	
	}
	public void Execute(IBoard board)
	{	
		_board.ActOn(new BuildingDemolition(_cell));
	}
}