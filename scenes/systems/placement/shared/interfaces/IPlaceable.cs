using Godot;
using System.Collections.Generic;
using Game.Enums;

public interface IPlaceable
{
	ItemType Type {get;}

	IGridCellAction PlacementAction(LayerBag bag);
	IGridArea Area(Vector2I start, Vector2I end);
	IEnumerable<Vector2I> OccupiedOffsets();
}
