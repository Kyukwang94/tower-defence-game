using Godot;
using Game.Enums;

public sealed class OccupancyAction : IGridCellAction
{
	private readonly IGridCellAction _origin        ;
	private readonly TileMapLayer    _occupancyLayer;
	private readonly OccupancyType   _myType        ;
	private readonly OccupancyType   _conflictsWith ;

	
	public OccupancyAction(IGridCellAction origin     ,
						   TileMapLayer occupanyLayer ,
						   OccupancyType myType       ,
						   OccupancyType conflitcsWith )

	{
		_origin 		= origin;
		_occupancyLayer = occupanyLayer;		
		_myType 		= myType;
		_conflictsWith  = conflitcsWith;
	}


	public void OnCell(TileMapLayer layer, Vector2I cell)
	{	
		new OccupancyLedger(_occupancyLayer).MarkCell(cell, _myType);

		_origin.OnCell(layer, cell);
	}

	public bool TryOnCell(TileMapLayer layer, Vector2I cell)
	{
		int currentVal = _occupancyLayer.GetCellSourceId(cell);

		if (currentVal != -1)
		{
			if((currentVal & (int)_conflictsWith) != 0)
			{
				GD.Print($"[OccupancyAction]{cell} 실패!");
				return false;
			}
		}

		return _origin.TryOnCell(layer,  cell);
	}
}
