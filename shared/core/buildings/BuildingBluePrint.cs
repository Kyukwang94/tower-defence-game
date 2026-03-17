using Godot;
using Game.Enums;


public sealed record BuildingBluePrint(BuildingResource Resource)
{
	public ItemType Type => Resource.Type;
	public IHandItem ToHandItem() => new BuildingPlayerHand(this);
	public IDisplayable ToDisplayableItem() => new BuildingDisplayItem(this);
}