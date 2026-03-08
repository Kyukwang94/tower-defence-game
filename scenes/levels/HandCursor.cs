using Godot;
using System;

public partial class HandCursor : Node2D
{
	[Export] private Sprite2D design;

	
	public override void _Process(double delta)
	{
		GlobalPosition = GetGlobalMousePosition();
	}

	public void ChangeDesign(ICursorDesign cursorDesign)
	{
		cursorDesign.Apply(design);		
	}
}
