using Game.Enums;


public sealed class ClearOccupancyAction : IBoardAction
{
	
	private readonly Address _address;
	public ClearOccupancyAction(Address address)
	{
		_address = address;
	}
	public void Execute(BoardContext context)
	{
		context.OccupancyLedger.MarkShape(_address, OccupancyType.None);
		context.OccupancyLedger.UnRegisterOccupant(_address);
	}
}