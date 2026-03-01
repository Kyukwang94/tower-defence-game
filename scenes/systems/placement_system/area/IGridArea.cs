using Godot;
using System;
using System.Collections.Generic;

public interface IGridArea 
{
	public void ApplyTo(IGridCellAction action);
	public IEnumerable<Vector2I> CalculateCells();
}
