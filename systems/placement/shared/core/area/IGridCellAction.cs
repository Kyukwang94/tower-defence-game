using Godot;
using System;

public interface  IGridCellAction
{
	void OnCell(BoardEnvironment boardEnv ,Vector2I cell);
	bool TryOnCell(BoardEnvironment boardEnv ,Vector2I cell);
}
