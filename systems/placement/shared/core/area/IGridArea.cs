using Godot;
using System;
using System.Collections.Generic;

public interface IGridArea 
{
	public void ApplyTo(Board board, IGridCellAction action);
	public bool CanApply(Board board, IGridCellAction aciton);
	public IEnumerable<Vector2I> CalculateCells();
}
