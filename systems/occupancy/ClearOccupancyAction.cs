using Game.Enums;


public sealed class ClearOccupancyAction : IBoardAction
{
	
	private readonly Address _address;
	public ClearOccupancyAction(Address address)
	{
		_address = address;
	}
	public void Execute(IBoard boardContext)
	{
		boardContext.Ledger.MarkShape(_address, OccupancyType.None);
		boardContext.Ledger.UnRegisterOccupant(_address);
	}
}