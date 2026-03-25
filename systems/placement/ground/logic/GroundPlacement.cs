using Godot;
using System.Collections.Generic;
using Game.Placement.Core.Area;

using Game.Enums;

public sealed record GroundPlacement(GroundBluePrint BluePrint) : IPlaceable
{
	public ItemType Type => BluePrint.Resource.Type;

	public IGridArea OccupyPlan(Vector2I start, Vector2I end) => new GridArea(start, end);

	public IEnumerable<Vector2I> OccupiedOffsets()
	{
		yield return new Vector2I(0, 0);
	}

	public IGridCellAction PlacementAction(LayerBag layerBag)
	{
		return new GroundStandardPlacement(BluePrint, layerBag);
	}
}