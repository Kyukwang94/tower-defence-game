using Godot;
using System;
using System.Collections.Generic;

namespace Game.Placement.Core.Area;

public sealed class ShapeArea : IGridArea
{
	Vector2I 			  _cursorPos;
	IEnumerable<Vector2I> _shapeCells;

	public ShapeArea(Vector2I cursorPos, IEnumerable<Vector2I> shapeCells)
	{
		_cursorPos  = cursorPos;
		_shapeCells = shapeCells;	
	}
	public void ApplyTo(Godot.TileMapLayer layer , IGridCellAction action)
	{
		foreach (var cell in CalculateCells())
		{
			action.OnCell(layer, cell);
		}
	}

	public IEnumerable<Vector2I> CalculateCells()
	{
		foreach(Vector2I cell in _shapeCells)
		{
			yield return _cursorPos + cell;
		}
	}

}
