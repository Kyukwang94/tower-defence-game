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

	public bool TryOnCell(BoardEnvironment boardEnv, Vector2I cell)
	{
		return boardEnv.Ask(new GroundMatch(cell, _requiredCoords)) && _origin.TryOnCell(boardEnv, cell);
	}


	public void OnCell(BoardEnvironment boardEnv, Vector2I cell)
	{
		if (TryOnCell(boardEnv, cell))
		{
			_origin.OnCell(boardEnv, cell);
		}
	}
}
