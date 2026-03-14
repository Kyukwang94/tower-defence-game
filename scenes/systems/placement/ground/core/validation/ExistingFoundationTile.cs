using Godot;
using System;



public sealed class ExistingFoundationTile : IGridCellAction
{
	private readonly IGridCellAction _origin;
	private readonly TileMapLayer	 _foundationLayer;

	public ExistingFoundationTile(TileMapLayer foundationLayer, IGridCellAction origin )
	{
		_origin = origin;
		_foundationLayer = foundationLayer;
	}

	public bool TryOnCell(TileMapLayer layer , Vector2I cell)
	{
		if(_foundationLayer.GetCellSourceId(cell) != -1 && _origin.TryOnCell(layer , cell))
		{
			return true;
		}
		else
		{
			GD.Print($"[ExistingFoundationTile] False ");
			return false;
		}	
	}

	public void OnCell(TileMapLayer layer, Vector2I cell)
	{
		if(TryOnCell(layer, cell))
		{
			_origin.OnCell(layer, cell);
		}
	}

}
