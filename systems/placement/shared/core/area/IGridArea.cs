using Godot;
using System;
using System.Collections.Generic;

public interface IGridArea 
{
	public void ApplyTo(BoardEnvironment boardEnv, IGridCellAction action);
	public bool CanApply(BoardEnvironment boardEnv, IGridCellAction aciton);
	public IEnumerable<Vector2I> CalculateCells();
}
