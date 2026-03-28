using Godot;
using System;

public sealed class NoPreviewAction : IGridCellAction
{
	public void OnCell(Board board, Vector2I cell)
	{
		
	}

	public bool TryOnCell(Board board, Vector2I cell)
	{
		return true;
	}
}

