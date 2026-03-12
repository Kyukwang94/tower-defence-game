using Godot;
using System;

public sealed class NoPlacementAction : IGridCellAction
{
	public bool TryOnCell(TileMapLayer layer, Vector2I cell) => false;

	public void OnCell(TileMapLayer layer, Vector2I cell)
	{
		
	}
}
