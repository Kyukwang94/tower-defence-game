using Godot;
public sealed class BuildingDemolition
{
	private readonly OccupancyLedger _occupancyLedger;
	private readonly BoardEnvironment _boardEnv;
	private readonly Vector2I _cell;

	public BuildingDemolition(BoardEnvironment boardEnv, OccupancyLedger occupancyLedger, Vector2I cell)
	{
		_occupancyLedger = occupancyLedger;
		_cell = cell;
		_boardEnv = boardEnv;
	}
	public void Demolish()
	{
		if(!_occupancyLedger.TryGetOccupant(_cell, out var target))
			return;

		target.Demolish((address) =>
		{
			new ClearOccupancyAction(address, _occupancyLedger).Execute(_boardEnv);
		});
	}
}