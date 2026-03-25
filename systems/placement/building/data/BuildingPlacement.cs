using Godot;
using Game.Enums;
using System.Collections.Generic;

public sealed record BuildingPlacement(BuildingBluePrint BluePrint) : IPlaceable
{
	public ItemType Type => BluePrint.Resource.Type;

	public IGridArea OccupyPlan(Vector2I start, Vector2I end) => new PointArea(end);
	
	public IEnumerable<Vector2I> OccupiedOffsets()
	{	
		yield return new Vector2I(0, 0);
	}

	public IGridCellAction PlacementAction(LayerBag layerBag)
	{
		return new BuildingStandardPlacement(BluePrint, layerBag);
	}
}
