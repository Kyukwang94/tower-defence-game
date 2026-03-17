using Godot;
using System;

public partial class PlacementExhibitionButton : Button
{
	[Export] CanvasLayer PlacementExhibitionPanel;

	public override void _Ready()
	{
		Pressed += OnButtonPressed;
	}

	public void OnButtonPressed()
	{
		if (PlacementExhibitionPanel != null)
		{
			PlacementExhibitionPanel.Visible = !PlacementExhibitionPanel.Visible;
		}
		else
		{
			GD.PrintErr("PlacementExhibitionUI가 할당되지 않았습니다");
		}
	}

}
