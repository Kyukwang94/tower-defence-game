using Godot;
using Game.Enums;
using System.Collections.Generic;


public sealed record Building(BuildingResource Resource) : IPlaceable
{
	//Identity
	public ItemType Type => Resource.Type;
	public IGridCellAction PlacementAction(LayerBag bag) => Resource.InstallationRule.CreateAction(this, bag);
	public IGridArea OccupyPlan(Vector2I start, Vector2I end) => new PointArea(end);

	
	//Display
	public void SetDisplayMedia(IDisplayMedia media)
	{
		media.SetTitle(Resource.Name);
		media.SetIcon(Resource.Icon);
	}
}