using Godot;
public sealed class GroundMatch : ILayerQuery<bool>
{
	private readonly Vector2I _cell;
	private readonly Vector2I _requiredAtlas;
	public GroundMatch(Vector2I cell, Vector2I requiredAtlas)
	{
		_cell = cell;
		_requiredAtlas = requiredAtlas;
	}
	public bool Execute(ILayerProvider layerProvider)
	{
		return layerProvider.Ground.GetCellAtlasCoords(_cell) == _requiredAtlas;
	}
}