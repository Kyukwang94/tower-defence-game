using Godot;
using System;
using Godot.Collections;
public sealed class ShapeIntegrity : IGridCellAction
{
	private readonly IGridCellAction _origin;
	private readonly Array<Vector2I>  _shapeCells;

	public ShapeIntegrity(IGridCellAction origin, Array<Vector2I> shapeCells)
	{
		_origin = origin ?? throw new ArgumentException(nameof(origin));
		_shapeCells = shapeCells ?? throw new ArgumentException(nameof(origin));
	}

	public void OnCell(IBoard boardContext, Vector2I pivot)
	{
		foreach (var cell in _shapeCells)
		{
			_origin.OnCell(boardContext, pivot + cell);	
		}
	}

	public bool TryOnCell(IBoard boardContext, Vector2I pivot)
	{
		foreach( var cell in _shapeCells)
		{
			Vector2I unverfiedCell = pivot + cell;

			if(!_origin.TryOnCell(boardContext, unverfiedCell))
			{
				return false;
			}
		}

		return true;
	}
}