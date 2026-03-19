using Godot;

public sealed class GroundPaint : IGridCellAction
{
	private readonly int _sourceId;
	private readonly Vector2I _atlasCoords;

	public GroundPaint(int sourceId , Vector2I atlasCoords)
	{
		_sourceId = sourceId;
		_atlasCoords = atlasCoords;
	}

	public bool TryOnCell(Godot.TileMapLayer layer, Vector2I cell) => true;
	

	public void OnCell(Godot.TileMapLayer layer, Vector2I cell)
	{
		if(TryOnCell(layer, cell))
			layer.SetCell(cell , _sourceId, _atlasCoords);
	}
}
