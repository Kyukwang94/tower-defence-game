using Godot;
using System;

public sealed class DefaultPlayerHandDesign : ICursorDesign
{
	public void Apply(ICursorCanvas canvas)
	{
		canvas.ResetToDefault();
	}
}
