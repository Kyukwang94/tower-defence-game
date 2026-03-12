using Godot;
using System;
using System.Collections.Generic;

public interface IGridArea 
{
	public void ApplyTo(TileMapLayer layer, IGridCellAction action);
	public IEnumerable<Vector2I> CalculateCells();
}
