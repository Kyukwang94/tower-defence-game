using Godot;
using System;

public partial class DemolitionBtn : Button
{
	[Export] private PlayerHand playerHand;
	[Export] private DemolishResource _resource ;
	public override void _Ready()
	{
		this.Pressed += () => playerHand.Grasp(new DemolishTool(_resource));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
