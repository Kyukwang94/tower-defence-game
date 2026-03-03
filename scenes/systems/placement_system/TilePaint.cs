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
	public void OnCell(Vector2I cell)
	{
		GD.Print($"[TilePaint] 칠하기 시도! ➡️ 좌표: {cell}, SourceID: {_sourceId}, Coords: {_atlasCoords}");
		_mapLayer.SetCell(cell , _sourceId, _atlasCoords);
	}
}
