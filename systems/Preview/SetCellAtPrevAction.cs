using Godot;

public sealed class SetCellAtPrevAction : IBoardAction
{
	private readonly Vector2I _cell;
	private readonly int _sourceId;
	private readonly Vector2I _coords;
	public SetCellAtPrevAction(Vector2I cell, int sourceId, Vector2I coords)
	{
		_cell = cell;
		_sourceId = sourceId;
		_coords = coords;
	}
	public void Execute(IBoard board)
	{
		board.Layers.Preview.SetCell(_cell, _sourceId, _coords);
	}
}