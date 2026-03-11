using Godot;
using System.Collections.Generic;
public interface IPlaceable
{
	IGridCellAction PlacementAction(ILayerProvider mapProvider);

	ICursorDesign   CursorDesign();	

	IEnumerable<Vector2I> OccupiedOffsets();

	public IGridArea Area(Vector2I start, Vector2I end);
}
