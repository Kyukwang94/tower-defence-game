using Godot;
using System;

public interface  IGridCellAction
{
	void OnCell(TileMapLayer layer ,Vector2I cell);

	bool TryOnCell(TileMapLayer layer ,Vector2I cell);
}
