using Godot;
using System;
using System.Collections.Generic;

public partial class EmptyArea : IGridArea
{
	public static readonly EmptyArea Instance = new EmptyArea();

	private EmptyArea() { }


	public void ApplyTo(BoardEnvironment boardEnv, IGridCellAction action)
	{
		
	}


	public IEnumerable<Vector2I> CalculateCells()
	{
		return [];
	}

	public bool CanApply(BoardEnvironment boardEnv, IGridCellAction aciton)
	{
		return false;
	}
}
