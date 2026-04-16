using Godot;

public sealed class DemolitionPreview : IBoardAction
{
	private readonly Vector2I _cell;


	public DemolitionPreview(Vector2I cell)
	{
		_cell = cell;
	}

	public void Execute(IBoard board)
	{
		board.Layers.Preview.Clear();

		var target = new DemolishTarget(_cell).Ask(board);
		if(target == null) return;

		Vector2I atlasCoords = target.CanDemolish() ? Vector2I.Zero : new Vector2I(1, 0);

		foreach (var occupantCell in target.Address.OccupiedCells)
		{
			new SetCellAtPrevAction(occupantCell, 1, atlasCoords).Execute(board);
		}
	}
}