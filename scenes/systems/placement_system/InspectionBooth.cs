using Godot;
using System;

public sealed class InspectionBooth : IGridCellAction
{
	private readonly IGridCellAction _origin;
	private readonly TileMapLayer _map;
	private readonly Resource 	  _item;
	
	public InspectionBooth(IGridCellAction origin , TileMapLayer map , Resource item)
	{
		
	}
	public void OnCell(Vector2I cell)
	{
	
	}

	private bool IsApprovable(Vector2I cell)
	{
		return _map.GetCellSourceId(cell) == -1;
	}

}
