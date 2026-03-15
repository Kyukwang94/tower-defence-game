using Godot;
using System.Collections.Generic;
using Game.Enums;

public interface IPlaceable
{
	ItemType Type {get;}
	OccupancyType OccupancyType {get;}

	IGridCellAction PlacementAction();
	IGridArea Area(Vector2I start, Vector2I end);
	IEnumerable<Vector2I> OccupiedOffsets();
}
