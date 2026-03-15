using Game.Enums;
using Godot;
using System.Collections.Generic;

namespace Game.Placement.NullObject;

public partial class NoPlaceable : IHandItem
{
	public ItemType Type 		 	   => ItemType.None;
	public OccupancyType OccupancyType => OccupancyType.None;
	public static readonly NoPlaceable Instance = new();


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

	public IGridCellAction PlacementAction(LayerBag bag)
	{
		return new NoPlacementAction();
	}

	public IGridCellAction PreviewAction()
	{
		return new NoPreviewAction();
	}

	public void DisplayOn(IGallery gallery)
	{
		
	}
}
