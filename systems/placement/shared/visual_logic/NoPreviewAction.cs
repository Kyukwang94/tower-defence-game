using Godot;
using System;

public sealed class NoPreviewAction : IGridCellAction
{
	public void OnCell(BoardContext board, Vector2I cell)
	{
		
	}

	public bool TryOnCell(BoardContext board, Vector2I cell)
	{
		return true;
	}
}

