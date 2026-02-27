using Godot;
using System.Collections.Generic;
using System;

public sealed class GridSelection : IGridSelection
{
	private readonly Vector2I _start;
	private readonly Vector2I _end;

	public GridSelection(Vector2I start , Vector2I end)
	{
		_start 	= start;
		_end 	= end;
	}

	public void ApplyTo(IGridCellAction action)
	{
		ArgumentNullException.ThrowIfNull(action);

		foreach (var cell in Cells())
        {
            action.OnCell(cell);
        }
	}


	public GridArea Area()
	{
		return new GridArea(_start, _end);
	}

	public IReadOnlyCollection<Vector2I> Cells()
	{
		return Area().Cells();
	}
	
}
