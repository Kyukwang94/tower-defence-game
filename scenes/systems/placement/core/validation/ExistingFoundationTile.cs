using Godot;
using System;

namespace Game.Action.Validation;

public sealed class ExistingFoundationTile : IGridCellAction
{
	private readonly IGridCellAction _origin;
	private readonly TileMapLayer _map;

	public ExistingFoundationTile(IGridCellAction origin , TileMapLayer map)
	{
		_origin = origin;
		_map = map;	
	}

	public bool TryOnCell(Vector2I cell)
	{
		return _map.GetCellSourceId(cell) != -1 && _origin.TryOnCell(cell) ;
	}

	public void OnCell(Vector2I cell)
	{
		if(TryOnCell(cell))
		{
			_origin.OnCell(cell);
		}
	}

}
