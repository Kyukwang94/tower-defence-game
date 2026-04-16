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

	public bool TryOnCell(IBoard boardContext, Vector2I cell)
	{
		bool groundMatch = new GroundMatch(cell, _requiredCoords).Ask(boardContext);
		return groundMatch && _origin.TryOnCell(boardContext, cell);
	}


	public void OnCell(IBoard boardContext, Vector2I cell)
	{
		if (TryOnCell(boardContext, cell))
		{
			_origin.OnCell(boardContext, cell);
		}
	}
}
