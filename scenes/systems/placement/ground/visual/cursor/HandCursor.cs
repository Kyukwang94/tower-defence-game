using Godot;
using System;

public partial class HandCursor : Node2D , ICursorCanvas
{
	[Export] private Sprite2D _visual;

	
	public override void _Process(double delta)
	{
		GlobalPosition = GetViewport().GetMousePosition();
	}

	public void SetTexture(Texture2D texture)
	{
		_visual.Texture = texture;
	}

	public void SetColor(Color color)
	{
		_visual.Modulate = color;
	}

}
