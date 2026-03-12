using Godot;
using System;

namespace Game.Action.Validation;

public sealed class ExistingFoundationTile : IGridCellAction
{
	private readonly IGridCellAction _origin;
	

	public ExistingFoundationTile(IGridCellAction origin )
	{
		_origin = origin;
	}

	public bool TryOnCell(TileMapLayer layer , Vector2I cell)
	{
		return layer.GetCellSourceId(cell) != -1 && _origin.TryOnCell(layer , cell) ;
	}

	public void OnCell(TileMapLayer layer, Vector2I cell)
	{
		if(TryOnCell(layer, cell))
		{
			_origin.OnCell(layer, cell);
		}
	}

}
