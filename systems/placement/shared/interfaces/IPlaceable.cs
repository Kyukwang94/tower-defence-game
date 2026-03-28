using Godot;
using System.Collections.Generic;
using Game.Enums;

public interface IPlaceable
{
	ItemType Type { get; }

	IGridCellAction PlacementAction();
	IGridArea OccupyPlan(Vector2I start, Vector2I end);
}
