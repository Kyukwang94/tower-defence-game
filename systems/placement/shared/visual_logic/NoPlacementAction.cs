using Godot;
using System;

public sealed class NoPlacementAction : IGridCellAction
{
	public bool TryOnCell(Board board, Vector2I cell) => false;

	public void OnCell(Board board, Vector2I cell)
	{
		
	}
}
