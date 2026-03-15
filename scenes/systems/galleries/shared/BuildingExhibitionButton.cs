using Godot;
using System;

public partial class BuildingExhibitionButton : Button
{
	[Export] CanvasLayer buildingExhibitionPanel;
	
	public override void _Ready()
	{
		Pressed += OnButtonPressed;
	}

	public void OnButtonPressed()
	{
		if(buildingExhibitionPanel != null)
		{
			buildingExhibitionPanel.Visible = !buildingExhibitionPanel.Visible;
		}
		else
		{
			GD.PrintErr("buildingInventoryUI가 할당되지 않았습니다");
		}
	}
	
}
