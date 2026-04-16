using Godot;

namespace Game.Action.Validation;

public sealed class UniqueTilePlacement : IGridCellAction
{
	private readonly IGridCellAction _origin;
	private readonly int _targetSourceId;
	private readonly Vector2I _targetCoords;

	public UniqueTilePlacement(IGridCellAction origin, int heldSourceId, Vector2I heldCoords)
	{
		_origin = origin;
		_targetSourceId = heldSourceId;
		_targetCoords = heldCoords;
	}

	public bool TryOnCell(IBoard boardContext, Vector2I cell)
	{
		bool canOverlap = new CanOverlap(cell, _targetSourceId, _targetCoords).Ask(boardContext);
		return canOverlap && _origin.TryOnCell(boardContext, cell);
	}

	public void OnCell(IBoard boardContext, Vector2I cell)
	{
		if (new CanOverlap(cell, _targetSourceId, _targetCoords).Ask(boardContext))
		{
			_origin.OnCell(boardContext, cell);
		}
	}


}
