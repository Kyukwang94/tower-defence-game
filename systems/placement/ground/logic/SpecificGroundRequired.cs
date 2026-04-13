using System;
using Godot;

namespace Game.Action.Validation;

public sealed class SpecificGroundRequired : IGridCellAction
{
	private readonly IGridCellAction _origin;
	private readonly Vector2I _requiredCoords;

	public SpecificGroundRequired(IGridCellAction origin, Vector2I requiredCoords)
	{
		_origin = origin;
		_requiredCoords = requiredCoords;
	}

	public bool TryOnCell(BoardContext context, Vector2I cell)
	{
		return context.Board.Ask(new GroundMatch(cell, _requiredCoords)) && _origin.TryOnCell(context, cell);
	}


	public void OnCell(BoardContext context, Vector2I cell)
	{
		if (TryOnCell(context, cell))
		{
			_origin.OnCell(context, cell);
		}
	}
}
