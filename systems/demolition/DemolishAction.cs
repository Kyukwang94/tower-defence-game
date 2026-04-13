using Godot;

public interface IDemolishAction
{
	public void Execute(BoardContext board);
}
public sealed class DemolishAction : IBoardAction
{
	private readonly Vector2I _cell;
	public DemolishAction(Vector2I cell)
	{
		_cell = cell;
		
	}
	public void Execute(BoardContext context)
	{
		if (context.OccupancyLedger.TryGetOccupant(_cell, out var target))
		{	
			target.Demolish((address) =>
			{
				context.Board.ActOn(new ClearOccupancyAction(address));
			});
		}
	}
}