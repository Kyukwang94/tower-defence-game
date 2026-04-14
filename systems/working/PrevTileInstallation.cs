using Godot;

public sealed class PrevTileInstallation
{	
	private readonly Vector2I _cell;
	private readonly int _sourceId;
	private readonly Vector2I _coords;
	public PrevTileInstallation(Vector2I cell, int sourceId, Vector2I coords)
	{
		_cell = cell;
		_sourceId = sourceId;
		_coords = coords;
	}
	public void Paint(ILayerProvider layerProvider)
	{
		layerProvider.Preview.SetCell(_cell, _sourceId, _coords);
	}
}