using Godot;
using System;
using System.Collections.Generic;

public partial class EmptyArea : IGridArea
{
	public static readonly EmptyArea Instance = new EmptyArea();

	private EmptyArea() { }


	public void ApplyTo(BoardContext context, IGridCellAction action)
	{
		
	}


	public IEnumerable<Vector2I> CalculateCells()
	{
		return [];
	}

	public bool CanApply(BoardContext context, IGridCellAction aciton)
	{
		return false;
	}
}
