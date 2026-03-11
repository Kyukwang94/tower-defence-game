using Godot;
using System;

public sealed class NoPlacementAction : IGridCellAction
{
	public bool TryOnCell(Vector2I cell) => false;

	public void OnCell(Vector2I cell)
	{
		
	}
}
