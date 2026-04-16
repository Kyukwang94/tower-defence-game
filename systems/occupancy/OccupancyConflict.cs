using Godot;
using Game.Enums;
public sealed class OccupancyConflict : IBoardQuery<bool>
{
	private readonly Vector2I _cell;
	private readonly OccupancyType _conflictsWith;
	public OccupancyConflict(Vector2I cell, OccupancyType conflictsWith)
	{
		_cell = cell;
		_conflictsWith = conflictsWith;
	}
	public bool Ask(IBoard boardContext)
	{
		int currentVal = boardContext.Layers.Occupancy.GetCellSourceId(_cell);

		if (currentVal == -1) return false;

		return (currentVal & (int)_conflictsWith) != 0;
	}
}