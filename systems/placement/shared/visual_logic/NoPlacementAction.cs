using Godot;
using System;

public sealed class NoPlacementAction : IGridCellAction
{
	public bool TryOnCell(IBoard board, Vector2I cell) => false;

	public void OnCell(IBoard board, Vector2I cell)
	{
		
	}
}
