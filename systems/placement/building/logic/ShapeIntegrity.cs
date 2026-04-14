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

	public void OnCell(BoardEnvironment boardEnv, Vector2I pivot)
	{
		foreach (var cell in _shapeCells)
		{
			_origin.OnCell(boardEnv, pivot + cell);	
		}
	}

	public bool TryOnCell(BoardEnvironment boardEnv, Vector2I pivot)
	{
		foreach( var cell in _shapeCells)
		{
			Vector2I unverfiedCell = pivot + cell;

			if(!_origin.TryOnCell(boardEnv, unverfiedCell))
			{
				return false;
			}
		}

		return true;
	}
}