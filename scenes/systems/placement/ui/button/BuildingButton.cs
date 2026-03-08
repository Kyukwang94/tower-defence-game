using Godot;
using System;

public partial class BuildingButton : Button
{
	[Export] CanvasLayer buildingInventoryUI;
	
	public override void _Ready()
	{
		Pressed += OnButtonPressed;
	}

	public void OnButtonPressed()
	{
		if(buildingInventoryUI != null)
		{
			buildingInventoryUI.Visible = !buildingInventoryUI.Visible;
		}
		else
		{
			GD.PrintErr("buildingInventoryUI가 할당되지 않았습니다");
		}
	}
	
}
