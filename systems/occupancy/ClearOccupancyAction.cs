using Game.Enums;


public sealed class ClearOccupancyAction : IBoardAction
{
	
	private readonly Address _address;
	private readonly OccupancyLedger _occupancyLedger;
	public ClearOccupancyAction(Address address, OccupancyLedger occupancyLedger)
	{
		_address = address;
		_occupancyLedger = occupancyLedger;
	}
	public void Execute(BoardEnvironment boardEnv)
	{
		_occupancyLedger.MarkShape(_address, OccupancyType.None);
		_occupancyLedger.UnRegisterOccupant(_address);
	}
}