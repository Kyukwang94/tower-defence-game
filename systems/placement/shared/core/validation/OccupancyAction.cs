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


	public void OnCell(BoardContext context, Vector2I cell)
	{	
		context.Board.ActOn(new MarkCellOccupancyAction(cell, _myType));
		
		_origin.OnCell(context, cell);
	}

	public bool TryOnCell(BoardContext context, Vector2I cell)
	{	
		if(context.Board.Ask(new OccupancyConflict(cell, _conflictsWith)))
		{
			GD.Print($"[OccupancyAction]{cell} 실패!");
			return false;
		}

		return _origin.TryOnCell(context,  cell);
	}
}
