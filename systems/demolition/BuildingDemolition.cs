using Godot;
public sealed class BuildingDemolition : IBoardAction
{
	private readonly Vector2I _cell;
	public BuildingDemolition(Vector2I cell)
	{
		_cell = cell;
	}
	public void Execute(IBoard board)
	{
		if(!board.Ledger.TryGetOccupant(_cell, out var target))
			return;

		target.Demolish((address) =>
		{
			board.ActOn(new ClearOccupancyAction(address));
		});
	}

}