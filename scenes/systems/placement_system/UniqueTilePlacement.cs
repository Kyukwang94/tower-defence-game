using Godot;
using System;

namespace Game.Action.Validation;

public sealed class UniqueTilePlacement : IGridCellAction
{
	private readonly IGridCellAction _origin;
	private readonly TileMapLayer _map;
	private readonly int _targetSourceId;
	private readonly Vector2I _targetCoords;

	public UniqueTilePlacement(IGridCellAction origin, TileMapLayer map , int heldSourceId ,Vector2I heldCoords)
	{
		_origin 		= origin;
		_map    		= map;
		_targetSourceId = heldSourceId;
		_targetCoords 	= heldCoords;
	}

	public bool CanOnCell(Vector2I cell)
	{
		return CanOverlap(cell) && _origin.CanOnCell(cell);
	}

	public void OnCell(Vector2I cell)
	{
		if(CanOverlap(cell))
		{
			_origin.OnCell(cell);
		}
	}
	private bool CanOverlap(Vector2I cell)
	{
		int existingSourceId =    _map.GetCellSourceId(cell);
		Vector2I existingCoords = _map.GetCellAtlasCoords(cell);

		if(existingSourceId == _targetSourceId && existingCoords == _targetCoords)
		{
			GD.Print($"{cell}동일한 타일이 설치되어있습니다.");
			return false;
		}
		else
		{
			GD.Print($"{cell} Overlap 통과");
			return true;
		}
	}

}
