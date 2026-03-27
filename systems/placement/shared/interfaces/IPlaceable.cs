using Godot;
using System.Collections.Generic;
using Game.Enums;

public interface IPlaceable
{
	ItemType Type { get; }

	IGridCellAction PlacementAction(LayerBag bag);
	IGridArea OccupyPlan(Vector2I start, Vector2I end);
}
