using Godot;
using System;
using System.Collections.Generic;

public partial class EmprtyArea : IGridArea
{
	public static readonly EmprtyArea Instance = new EmprtyArea();

	private EmprtyArea() { }


	public void ApplyTo(Godot.TileMapLayer layer, IGridCellAction action)
	{
		
	}


	public IEnumerable<Vector2I> CalculateCells()
	{
		return [];
	}

}
