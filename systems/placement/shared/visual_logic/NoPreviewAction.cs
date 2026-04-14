using Godot;
using System;

public sealed class NoPreviewAction : IGridCellAction
{
	public void OnCell(BoardEnvironment board, Vector2I cell)
	{
		
	}

	public bool TryOnCell(BoardEnvironment board, Vector2I cell)
	{
		return true;
	}
}

