using Godot;

public sealed class PaintTileInstallation
{
	private readonly Vector2I _cell;
	private readonly int _sourceId;
	private readonly  Vector2I _atlasCoords;

	public PaintTileInstallation(Vector2I cell, int sourceId, Vector2I atlasCoords)
	{
		_cell = cell;
		_sourceId = sourceId;
		_atlasCoords = atlasCoords;
	}

	public void Paint(ILayerProvider layerProvider)
	{
		layerProvider.Ground.SetCell(_cell, _sourceId, _atlasCoords);
	}
}