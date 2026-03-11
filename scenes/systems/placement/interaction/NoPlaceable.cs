using Godot;
using System.Collections.Generic;


public partial class NoPlaceable : IPlaceable
{
	public static readonly IPlaceable Empty = new NoPlaceable();
	
	public ICursorDesign CursorDesign()
	{
		return new DefaultPlayerHandDesign();
	}

	public IGridArea Area(Vector2I start, Vector2I end)
	{
		return EmprtyArea.Instance;	
	}

	public IEnumerable<Vector2I> OccupiedOffsets()
	{
		return [];
	}

	public IGridCellAction PlacementAction(ILayerProvider mapProvider)
	{
		return new NoPlacementAction();
	}
}
