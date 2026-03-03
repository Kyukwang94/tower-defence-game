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

	public void OnCell(Vector2I cell)
	{
		if(_map.GetCellSourceId(cell) != -1)
		{
			_origin.OnCell(cell);
		}
	}

}
