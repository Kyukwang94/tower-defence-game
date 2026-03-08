using Godot;
using System;

public sealed class TilePaint : IGridCellAction
{
	private readonly TileMapLayer _mapLayer;
	private readonly int _sourceId;
	private readonly Vector2I _atlasCoords;

	public TilePaint(TileMapLayer mapLayer , int sourceId , Vector2I atlasCoords)
	{
		_mapLayer = mapLayer;
		_sourceId = sourceId;
		_atlasCoords = atlasCoords;
	}

	public bool CanOnCell(Vector2I cell)
	{
		return true;	
	}

	public void OnCell(Vector2I cell)
	{
		if(CanOnCell(cell))
			_mapLayer.SetCell(cell , _sourceId, _atlasCoords);
	}
}
