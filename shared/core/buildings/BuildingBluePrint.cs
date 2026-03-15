using Godot;
using System.Collections.Generic;

using Game.Placement.Core.Area;
using Game.Enums;

public sealed record BuildingBluePrint (BuildingResource Resource) 
{
	public ItemType  Type => Resource.Type;
	public IHandItem    ToHandItem() => new BuildingPlayerHandItem(this);
	public IDisplayable ToDisplayableItem() => new BuildingDisplayItem(this);
}

public sealed record BuildingPlacementItem(BuildingBluePrint BluePrint) : IPlaceable
{
	public ItemType Type => BluePrint.Resource.Type;

	public IGridArea Area(Vector2I start, Vector2I end) => new ShapeArea(end, OccupiedOffsets());
	public IEnumerable<Vector2I> OccupiedOffsets()
	{ 
		yield return new Vector2I(0,0);
	}

	public IGridCellAction PlacementAction(LayerBag layerBag)
	{		
		IGridCellAction action = new BuildingSpawnAction(BluePrint.Resource.scene);
						
						action = new OccupancyAction(
							action,
							layerBag.occupancy,
							BluePrint.Resource.MyType,
							BluePrint.Resource.ConflictsWith);
						
						action = new ExistingFoundationTile(layerBag.ground,action);
		return action;
	}
}

public sealed record BuildingPlayerHandItem(BuildingBluePrint BluePrint) : IHandItem
{
	public ICursorDesign CursorDesign() => new PlayerHandDesign(BluePrint.Resource.Icon);
	public void Selected(PlayerHand hand) => hand.Grasp(this);
	public IPlaceable ToGrid() => new BuildingPlacementItem(BluePrint);
}

public sealed record BuildingDisplayItem(BuildingBluePrint BluePrint) : IDisplayable
{
	
	public Texture2D Icon => 	BluePrint.Resource.Icon;
	public string    Label  =>  BluePrint.Resource.Name;

	public void DisplayOn(IGallery gallery)
	{
		gallery.Show(this);
	}

	public void Select(PlayerHand hand)
	{
		hand.Grasp(BluePrint.ToHandItem());
	}

}
