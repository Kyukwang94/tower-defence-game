using Godot;
using System;

public interface  IGridCellAction
{
	void OnCell(IBoard boardContext ,Vector2I cell);
	bool TryOnCell(IBoard boardContext ,Vector2I cell);
}
