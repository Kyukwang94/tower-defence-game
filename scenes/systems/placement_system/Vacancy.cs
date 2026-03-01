using Godot;
using System;

// TODO : 이건 필요없음 DuPlication 으로 해야함
public sealed class Vacancy : IGridCellAction
{
	private readonly IGridCellAction _origin;
	private readonly TileMapLayer _map;

	public Vacancy(IGridCellAction origin, TileMapLayer map)
	{
		_origin = origin;
		_map    = map;
	}
	public void OnCell(Vector2I cell)
	{
		if(_map.GetCellSourceId(cell) != -1)
		{
			_origin.OnCell(cell);
		}
	}

}
