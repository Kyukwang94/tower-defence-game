using Game.Enums;
using Godot;

public sealed class MarkCellOccupancyAction : IBoardAction
{
	private readonly Vector2I _cell;
	private readonly OccupancyType _occupancyType;
	public MarkCellOccupancyAction(Vector2I cell, OccupancyType occupancyType)
	{
		_cell = cell;
		_occupancyType = occupancyType;
	}

	public void Execute(BoardContext context)
	{
		context.OccupancyLedger.MarkCell(_cell, _occupancyType);
	}
	
}