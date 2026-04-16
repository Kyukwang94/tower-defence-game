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

	public void OnCell(IBoard boardContext, Vector2I cell)
	{	
		new MarkCellOccupancyAction(cell, _myType).Execute(boardContext);
		
		_origin.OnCell(boardContext, cell);
	}

	public bool TryOnCell(IBoard boardContext, Vector2I cell)
	{	
		
		if(new OccupancyConflict(cell, _conflictsWith).Ask(boardContext))
		{
			GD.Print($"[OccupancyAction]{cell} 실패!");
			return false;
		}

		return _origin.TryOnCell(boardContext,  cell);
	}
}
