using Godot;
using System;

namespace Game.Action.Validation;

public sealed class SpecificGroundRequired : IGridCellAction
{
	private readonly IGridCellAction _origin;
	private readonly Vector2I _requiredCoords;

	public SpecificGroundRequired(IGridCellAction origin, Vector2I requiredCoords )
	{
		_origin = origin;
		_requiredCoords =  requiredCoords;
	}

	public bool TryOnCell(Board board ,Vector2I cell)
	{
		return board.IsGroundMatch(cell, _requiredCoords) && _origin.TryOnCell(board, cell);
	}


	public void OnCell(Board board, Vector2I cell )
	{
		if(TryOnCell(board, cell))
		{
			_origin.OnCell(board, cell);
		}
	}
}
