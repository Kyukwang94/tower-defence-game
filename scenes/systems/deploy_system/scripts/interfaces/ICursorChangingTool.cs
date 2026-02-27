using Godot;
using System;

public interface ICursorChangingTool
{
	event Action<Texture2D> OnCursorChangeRequested;
}
