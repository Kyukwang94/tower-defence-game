using Godot;
using Game.Enums;

public partial class Board
{
	public bool IsOccupancyConflict(Vector2I cell, OccupancyType conflictsWith)
	{
		return _occupancyLedger.IsOccupancyConflict(cell, conflictsWith);
	}

	public bool HasOccupant(Vector2I cell, out IDemolishable target)
	{
		return _occupancyLedger.TryGetOccupant(cell, out target);
	}
}