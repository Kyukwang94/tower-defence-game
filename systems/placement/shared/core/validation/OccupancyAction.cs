using Godot;
using Game.Enums;

public sealed class OccupancyAction : IGridCellAction
{
	private readonly IGridCellAction _origin        ;
	private readonly OccupancyType   _myType        ;
	private readonly OccupancyType   _conflictsWith ;

	
	public OccupancyAction(IGridCellAction origin     ,
						   OccupancyType myType       ,
						   OccupancyType conflitcsWith )

	{
		_origin 		= origin;
		_myType 		= myType;
		_conflictsWith  = conflitcsWith;
	}


	public void OnCell(Board board, Vector2I cell)
	{	
		board.ActOn(new MarkCellOccupancyAction(cell, _myType));
		
		_origin.OnCell(board, cell);
	}

	public bool TryOnCell(Board board, Vector2I cell)
	{	
		if(board.IsOccupancyConflict(cell, _conflictsWith))
		{
			GD.Print($"[OccupancyAction]{cell} 실패!");
			return false;
		}

		return _origin.TryOnCell(board,  cell);
	}
}
