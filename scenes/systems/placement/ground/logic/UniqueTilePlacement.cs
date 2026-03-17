using Godot;
using System;

namespace Game.Action.Validation;

public sealed class UniqueTilePlacement : IGridCellAction
{
	private readonly IGridCellAction _origin;
	private readonly int _targetSourceId;
	private readonly Vector2I _targetCoords;

	public UniqueTilePlacement(IGridCellAction origin, int heldSourceId ,Vector2I heldCoords)
	{
		_origin 		= origin;
		_targetSourceId = heldSourceId;
		_targetCoords 	= heldCoords;
	}

	public bool TryOnCell(Godot.TileMapLayer layer, Vector2I cell)
	{
		return CanOverlap(layer, cell) && _origin.TryOnCell(layer, cell);
	}

	public void OnCell(Godot.TileMapLayer layer, Vector2I cell)
	{
		if(CanOverlap(layer, cell))
		{
			_origin.OnCell(layer, cell);
		}
	}
	private bool CanOverlap(Godot.TileMapLayer layer, Vector2I cell)
	{
		int existingSourceId =    layer.GetCellSourceId(cell);
		Vector2I existingCoords = layer.GetCellAtlasCoords(cell);

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
