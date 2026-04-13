using Godot;
using System;

public interface  IGridCellAction
{
	void OnCell(BoardContext context ,Vector2I cell);

	bool TryOnCell(BoardContext context ,Vector2I cell);
}
