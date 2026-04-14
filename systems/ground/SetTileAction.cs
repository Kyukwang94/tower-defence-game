using Godot;
	

public sealed class SetTileAction : IBoardAction
{
	private readonly Vector2I _cell;
	private readonly int _sourceId;
	private readonly Vector2I _atlasCoords;
	public SetTileAction(Vector2I cell, int sourceId, Vector2I atlasCoords)
	{
		_cell = cell;
		_sourceId = sourceId;
		_atlasCoords = atlasCoords;
	}
	public void Execute(BoardEnvironment boardEnv)
	{
		boardEnv.PaintTile(_cell, _sourceId, _atlasCoords);
	}
}