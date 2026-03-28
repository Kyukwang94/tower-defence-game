using Godot;
using System;

public interface  IGridCellAction
{
	void OnCell(Board board ,Vector2I cell);

	bool TryOnCell(Board board ,Vector2I cell);
}
