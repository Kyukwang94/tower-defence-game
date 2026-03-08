using Godot;
using System;

namespace Game.Action.Validation;

public sealed class SpecificFoundationRequired : IGridCellAction
{
	private readonly IGridCellAction _origin;
	private readonly TileMapLayer _map;
	private readonly Vector2I _requiredCoords;

	public SpecificFoundationRequired(IGridCellAction origin, TileMapLayer map , Vector2I requiredCoords )
	{
		_origin = origin;
		_map = map;
		_requiredCoords =	requiredCoords;
	}

	public bool CanOnCell(Vector2I cell)
	{
		return _map.GetCellAtlasCoords(cell) == _requiredCoords && _origin.CanOnCell(cell);
	}


	public void OnCell(Vector2I cell)
	{
		if(CanOnCell(cell))
		{
			_origin.OnCell(cell);
		}
	}
}
