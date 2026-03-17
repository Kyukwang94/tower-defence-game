using Godot;
using System;

public sealed record BuildingPlayerHandItem(BuildingBluePrint BluePrint) : IHandItem
{
	public ICursorDesign CursorDesign() => new PlayerHandDesign(BluePrint.Resource.Icon);
	public void Selected(PlayerHand hand) => hand.Grasp(this);
	public IPlaceable ToGrid() => new BuildingPlacementItem(BluePrint);
}
