using Godot;
using System;

public sealed class NoPlacementAction : IGridCellAction
{
	public bool TryOnCell(BoardContext board, Vector2I cell) => false;

	public void OnCell(BoardContext board, Vector2I cell)
	{
		
	}
}
