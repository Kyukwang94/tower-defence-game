using Godot;
using Game.Enums;
using System.Collections.Generic;


public sealed record Building(BuildingResource Resource) : IPlaceable
{
	//Identity
	public ItemType Type => Resource.Type;
	public IEnumerable<Vector2I> Shape => Resource.Shape;
	public IGridCellAction PlacementAction() => Resource.InstallationRule.CreateAction(this);
	public IGridArea OccupyPlan(Vector2I start, Vector2I end) => new PointArea(end);

	
	//Display
	public void SetDisplayMedia(IDisplayMedia media)
	{
		media.SetTitle(Resource.Name);
		media.SetIcon(Resource.Icon);
	}
}