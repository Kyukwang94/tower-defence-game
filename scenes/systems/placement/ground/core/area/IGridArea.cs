using Godot;
using System;
using System.Collections.Generic;

public interface IGridArea 
{
	public void ApplyTo(Godot.TileMapLayer layer, IGridCellAction action);
	public IEnumerable<Vector2I> CalculateCells();
}
