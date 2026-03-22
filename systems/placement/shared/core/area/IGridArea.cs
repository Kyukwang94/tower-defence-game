using Godot;
using System;
using System.Collections.Generic;

public interface IGridArea 
{
	public void ApplyTo(TileMapLayer layer, IGridCellAction action);
	public bool CanApply(TileMapLayer layer, IGridCellAction aciton);
	public IEnumerable<Vector2I> CalculateCells();
}
