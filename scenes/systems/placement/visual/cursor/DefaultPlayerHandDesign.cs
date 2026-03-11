using Godot;
using System;

public sealed class DefaultPlayerHandDesign : ICursorDesign
{
	public void Apply(Sprite2D cursorVisual)
	{
		cursorVisual.Texture  = default;
		cursorVisual.Modulate = default;
		cursorVisual.Centered = default;
	}

}
