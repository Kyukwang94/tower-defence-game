using Game.Enums;
using Godot;

public sealed class MarkShapeOccupancyAction : IOccupancyAction
{
	public LayerType TargetLayer => LayerType.Occupancy;

	private readonly Address _address;
	private readonly OccupancyType _occupancyType;
	public MarkShapeOccupancyAction(Address address, OccupancyType occupancyType)
	{
		_address = address;
		_occupancyType = occupancyType;
	}

	public void Execute(OccupancyLedger ledger)
	{
		ledger.MarkShape(_address, _occupancyType);
	}
}