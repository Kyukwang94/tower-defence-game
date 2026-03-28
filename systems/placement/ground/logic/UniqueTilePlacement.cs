using Godot;

namespace Game.Action.Validation;

public sealed class UniqueTilePlacement : IGridCellAction
{
	private readonly IGridCellAction _origin;
	private readonly int _targetSourceId;
	private readonly Vector2I _targetCoords;

	public UniqueTilePlacement(IGridCellAction origin, int heldSourceId ,Vector2I heldCoords)
	{
		_origin 		= origin;
		_targetSourceId = heldSourceId;
		_targetCoords 	= heldCoords;
	}

	public bool TryOnCell(Board board, Vector2I cell)
	{
		return board.CanOverlap(cell, _targetSourceId, _targetCoords) && _origin.TryOnCell(board, cell);
	}

	public void OnCell(Board board, Vector2I cell)
	{
		if(board.CanOverlap(cell, _targetSourceId, _targetCoords))
		{
			_origin.OnCell(board, cell);
		}
	}
	

}
