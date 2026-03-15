using Godot;
using System;
using System.Collections.Generic;

public partial class EmptyArea : IGridArea
{
	public static readonly EmptyArea Instance = new EmptyArea();

	private EmptyArea() { }


	public void ApplyTo(Godot.TileMapLayer layer, IGridCellAction action)
	{
		
	}


	public IEnumerable<Vector2I> CalculateCells()
	{
		return [];
	}

}
