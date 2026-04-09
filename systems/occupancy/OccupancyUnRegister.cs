using Game.Enums;
using Godot;

public sealed class OccupancyUnRegister : IOccupancyAction
{
	public LayerType TargetLayer => LayerType.Occupancy;

	private readonly Address _address;
	
	public OccupancyUnRegister(Address address)
	{
		_address = address;
	}
	public void Execute(OccupancyLedger ledger)
	{
		ledger.UnRegisterOccupant(_address);
	}
}