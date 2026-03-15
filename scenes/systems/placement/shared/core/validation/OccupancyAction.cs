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
		_occupancyLayer = occupanyLayer;
		_origin 		= origin;
		_myType 		= myType;
		_conflictsWith  = conflitcsWith;
	}


	public void OnCell(TileMapLayer layer, Vector2I cell)
	{	
		if(this.TryOnCell(layer, cell))
		{
			_origin.OnCell(layer, cell);

			if(_myType != OccupancyType.None)
			{
				int currentVal = _occupancyLayer.GetCellSourceId(cell);
        		int existing   = (currentVal == -1) ? 0 : currentVal;
				_occupancyLayer.SetCell(cell, existing | (int)_myType, Vector2I.Zero);	
				GD.Print($"[OccupancyAction] 장부 기록 완료 - Cell: {cell}, Type: {_myType}");			
			}			
		}
		else
		{
			GD.Print($"[OccupancyAction] 장부 기록 실패 - Cell: {cell}");
		}
	}

	public bool TryOnCell(TileMapLayer layer, Vector2I cell)
	{
		int currentVal = _occupancyLayer.GetCellSourceId(cell);

		if (currentVal != -1)
		{
			if((currentVal & (int)_conflictsWith) != 0)
			{
				GD.Print($"[OccupancyAction] 점유되어있습니다. - ConflictsWith: {_conflictsWith}, Type: {_myType}");			
				return false;
			}
		}
		return true;
	}
}
