using Godot;
using System;

public sealed class NoPreviewAction : IGridCellAction
{
	public void OnCell(Godot.TileMapLayer layer, Vector2I cell)
	{
		
	}

	public bool TryOnCell(Godot.TileMapLayer layer, Vector2I cell)
	{
		return true;
	}
}

