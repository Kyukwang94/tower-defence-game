using Godot;
using System;
using System.Collections.Generic;

namespace Game.Placement.Core.Area;

public sealed class PointArea : IGridArea
{
	Vector2I 			  _cursorPos;
	IEnumerable<Vector2I> _shapeCells;

	public PointArea(Vector2I cursorPos, IEnumerable<Vector2I> shapeCells)
	{
		_cursorPos  = cursorPos;
		_shapeCells = shapeCells;	
	}
	public void ApplyTo(Board board , IGridCellAction action)
	{
		foreach (var cell in CalculateCells())
		{
			action.OnCell(board, cell);
		}
	}

	public IEnumerable<Vector2I> CalculateCells()
	{
		foreach(Vector2I cell in _shapeCells)
		{
			yield return _cursorPos + cell;
		}
	}

	public bool CanApply(Board board, IGridCellAction action)
	=> action.TryOnCell(board, _cursorPos);
}
