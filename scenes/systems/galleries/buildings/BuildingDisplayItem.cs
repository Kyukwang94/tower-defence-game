using Godot;
using System;

public sealed record BuildingDisplayItem(BuildingBluePrint BluePrint) : IDisplayable
{

	public Texture2D Icon => BluePrint.Resource.Icon;
	public string Label => BluePrint.Resource.Name;

	public void DisplayOn(IGallery gallery)
	{
		gallery.Show(this);
	}

	public void Select(PlayerHand hand)
	{
		hand.Grasp(BluePrint.ToHandItem());
	}

}
