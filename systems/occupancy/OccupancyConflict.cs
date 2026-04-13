using Godot;
using Game.Enums;
public sealed class OccupancyConflict : ILayerQuery<bool>
{
	private readonly Vector2I _cell;
	private readonly OccupancyType _conflictsWith;
	public OccupancyConflict(Vector2I cell, OccupancyType conflictsWith)
	{
		_cell = cell;
		_conflictsWith = conflictsWith;
	}
	public bool Execute(ILayerProvider layerProvider)
	{
		int currentVal = layerProvider.Occupancy.GetCellSourceId(_cell);

		if (currentVal == -1) return false;

		return (currentVal & (int)_conflictsWith) != 0;
	}
}