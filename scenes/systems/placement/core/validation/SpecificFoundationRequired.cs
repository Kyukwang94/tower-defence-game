using Godot;
using System;

namespace Game.Action.Validation;

public sealed class SpecificFoundationRequired : IGridCellAction
{
	private readonly IGridCellAction _origin;
	private readonly Vector2I _requiredCoords;

	public SpecificFoundationRequired(IGridCellAction origin, Vector2I requiredCoords )
	{
		_origin = origin;
		_requiredCoords =	requiredCoords;
	}

	public bool TryOnCell(TileMapLayer layer ,Vector2I cell)
	{
		return layer.GetCellAtlasCoords(cell) == _requiredCoords && _origin.TryOnCell(layer, cell);
	}


	public void OnCell(TileMapLayer layer, Vector2I cell )
	{
		if(TryOnCell(layer, cell))
		{
			_origin.OnCell(layer, cell);
		}
	}
}
