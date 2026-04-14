using Godot;
using System;

public sealed class NoPlacementAction : IGridCellAction
{
	public bool TryOnCell(BoardEnvironment board, Vector2I cell) => false;

	public void OnCell(BoardEnvironment board, Vector2I cell)
	{
		
	}
}
