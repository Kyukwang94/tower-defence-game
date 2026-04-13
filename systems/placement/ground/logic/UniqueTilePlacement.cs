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

	public bool TryOnCell(BoardContext context, Vector2I cell)
	{
		return context.Board.Ask(new CanOverlap(cell, _targetSourceId, _targetCoords)) && _origin.TryOnCell(context, cell);
	}

	public void OnCell(BoardContext context, Vector2I cell)
	{
		if (context.Board.Ask(new CanOverlap(cell, _targetSourceId, _targetCoords)))
		{
			_origin.OnCell(context, cell);
		}
	}


}
