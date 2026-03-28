using Godot;
using System;

public partial class PlacementPreviewAction : IGridCellAction 
{
	private readonly IGridCellAction _origin;

	public PlacementPreviewAction(IGridCellAction origin)
	{
		_origin = origin;
	}
 
	public bool TryOnCell(Board board , Vector2I cell) => true;
	

	public void OnCell(Board board , Vector2I cell)
	{
		bool canPlace = _origin.TryOnCell(board, cell);
		
		Vector2I coords = canPlace ? new Vector2I(0,0) : new Vector2I(1, 0);


		board.SetCellAtPrev(cell, 1, coords);
	}
}
