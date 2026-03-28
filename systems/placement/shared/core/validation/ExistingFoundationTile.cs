using Godot;
using System;



public sealed class ExistingFoundationTile : IGridCellAction
{
	private readonly IGridCellAction _origin;

	public ExistingFoundationTile(IGridCellAction origin )
	{
		_origin = origin;
	}

	public bool TryOnCell(Board board , Vector2I cell)
	{
		if(board.HasFoundation(cell) && _origin.TryOnCell(board , cell))
		{
			return true;
		}
		else
		{
			GD.Print($"[ExistingFoundationTile] False ");
			return false;
		}	
	}

	public void OnCell(Board board, Vector2I cell)
	{
		if(TryOnCell(board, cell))
		{
			_origin.OnCell(board, cell);
		}
	}

}
