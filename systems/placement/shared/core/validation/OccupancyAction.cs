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

	public void OnCell(BoardEnvironment boardEnv, Vector2I cell)
	{	
		boardEnv.ActOn(new MarkCellOccupancyAction(cell, _myType));
		
		_origin.OnCell(boardEnv, cell);
	}

	public bool TryOnCell(BoardEnvironment boardEnv, Vector2I cell)
	{	
		if(boardEnv.Ask(new OccupancyConflict(cell, _conflictsWith)))
		{
			GD.Print($"[OccupancyAction]{cell} 실패!");
			return false;
		}

		return _origin.TryOnCell(boardEnv,  cell);
	}
}
