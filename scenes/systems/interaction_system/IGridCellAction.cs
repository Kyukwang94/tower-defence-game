using Godot;
using System;

public interface  IGridCellAction
{
	void OnCell(Vector2I cell);
}
