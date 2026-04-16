using Godot;
using System;
using System.Collections.Generic;

public partial class EmptyArea : IGridArea
{
	public static readonly EmptyArea Instance = new EmptyArea();

	private EmptyArea() { }


	public void ApplyTo(Board board, IGridCellAction action)
	{
		
	}


	public IEnumerable<Vector2I> CalculateCells()
	{
		return [];
	}

	public bool CanApply(Board board, IGridCellAction aciton)
	{
		return false;
	}
}
