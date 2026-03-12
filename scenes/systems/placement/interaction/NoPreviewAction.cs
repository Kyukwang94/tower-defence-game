using Godot;
using System;

public sealed class NoPreviewAction : IGridCellAction
{
	public void OnCell(TileMapLayer layer, Vector2I cell)
	{
		
	}

	public bool TryOnCell(TileMapLayer layer, Vector2I cell)
	{
		return true;
	}
}

