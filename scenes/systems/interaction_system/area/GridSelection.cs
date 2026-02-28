using Godot;
using System.Collections.Generic;
using System;

public sealed class GridSelection : IGridSelection
{
	private readonly GridArea _area;

	public GridSelection(GridArea area)
	{
		_area = area;
	}

	public void ApplyTo(IGridCellAction action)
	{
		_area.ApplyTo(action);
	}
}
