using Godot;
using System;

public sealed record BuildingExhibit(Building Core) : IDisplayable
{
	public void RecallDisplayMedia(IDisplayMedia form)
	{
		Core.SetDisplayMedia(form);
	}

	public void Select(PlayerHand hand)
	{
		hand.Grasp(new BuildingTool(Core));
	}

}
