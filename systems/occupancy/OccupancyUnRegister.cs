public sealed class OccupancyUnRegister : IBoardAction
{
	private readonly Address _address;
	
	public OccupancyUnRegister(Address address)
	{
		_address = address;
	}

	public void Execute(BoardContext boardContext)
	{
		boardContext.OccupancyLedger.UnRegisterOccupant(_address);
	}
}