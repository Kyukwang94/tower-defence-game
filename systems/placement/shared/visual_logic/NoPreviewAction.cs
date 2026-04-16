using Godot;
using System;

public sealed class NoPreviewAction : IGridCellAction
{
	public void OnCell(IBoard boardContext, Vector2I cell)
	{
		
	}

	public bool TryOnCell(IBoard boardContext, Vector2I cell)
	{
		return true;
	}
}

