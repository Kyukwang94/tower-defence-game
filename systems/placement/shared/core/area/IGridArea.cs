using Godot;
using System;
using System.Collections.Generic;

public interface IGridArea 
{
	public void ApplyTo(BoardContext context, IGridCellAction action);
	public bool CanApply(BoardContext context, IGridCellAction aciton);
	public IEnumerable<Vector2I> CalculateCells();
}
