using Godot;
using Game.Enums;
using Game.Placement.Core.Area;
using System.Collections.Generic;

public sealed record BuildingPlacement(BuildingBluePrint BluePrint) : IPlaceable
{
	public ItemType Type => BluePrint.Resource.Type;

	public IGridArea OccupyPlan(Vector2I start, Vector2I end) => new ShapeArea(end, OccupiedOffsets());
	
	public IEnumerable<Vector2I> OccupiedOffsets()
	{	
		yield return new Vector2I(0, 0);
	}

	public IGridCellAction PlacementAction(LayerBag layerBag)
	{
		IGridCellAction action = new BuildingSpawnAction(BluePrint.Resource.scene);

		action = new OccupancyValidatorAction(
			action,
			layerBag.occupancy,
			BluePrint.Resource.MyType,
			BluePrint.Resource.ConflictsWith);

		action = new ExistingFoundationTile(layerBag.ground, action);
		return action;
	}
}
