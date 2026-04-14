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

	public bool TryOnCell(BoardEnvironment boardEnv, Vector2I cell)
	{
		return boardEnv.Ask(new CanOverlap(cell, _targetSourceId, _targetCoords)) && _origin.TryOnCell(boardEnv, cell);
	}

	public void OnCell(BoardEnvironment boardEnv, Vector2I cell)
	{
		if (boardEnv.Ask(new CanOverlap(cell, _targetSourceId, _targetCoords)))
		{
			_origin.OnCell(boardEnv, cell);
		}
	}


}
