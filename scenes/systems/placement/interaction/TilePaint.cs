using Godot;
using System;

public sealed class TilePaint : IGridCellAction
{
	private readonly int _sourceId;
	private readonly Vector2I _atlasCoords;

	public TilePaint(int sourceId , Vector2I atlasCoords)
	{
		_sourceId = sourceId;
		_atlasCoords = atlasCoords;
	}

	public bool TryOnCell(TileMapLayer layer, Vector2I cell)
	{
		return true;	
	}

	public void OnCell(TileMapLayer layer, Vector2I cell)
	{
		if(TryOnCell(layer, cell))
			layer.SetCell(cell , _sourceId, _atlasCoords);
	}
}
