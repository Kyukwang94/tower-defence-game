using Game.Enums;
using Godot;

public sealed class MarkCellOccupancyAction : IOccupancyAction
{
	public LayerType TargetLayer => LayerType.Occupancy;
	private readonly Vector2I _cell;
	private readonly OccupancyType _occupancyType;
	public MarkCellOccupancyAction(Vector2I cell, OccupancyType occupancyType)
	{
		_cell = cell;
		_occupancyType = occupancyType;
	}

	public void Execute(OccupancyLedger ledger)
	{
		ledger.MarkCell(_cell, _occupancyType);
	}
}