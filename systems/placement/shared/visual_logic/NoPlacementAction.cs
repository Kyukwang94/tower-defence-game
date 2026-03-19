using Godot;
using System;

public sealed class NoPlacementAction : IGridCellAction
{
	public bool TryOnCell(TileMapLayer bag, Vector2I cell) => false;

	public void OnCell(TileMapLayer bag, Vector2I cell)
	{
		
	}
}
