using Game.Enums;
using Godot;

public sealed class MarkShapeOccupancyAction : IBoardAction
{
	public LayerType TargetLayer => LayerType.Occupancy;

	private readonly Address _address;
	private readonly OccupancyType _occupancyType;
	public MarkShapeOccupancyAction(Address address, OccupancyType occupancyType)
	{
		_address = address;
		_occupancyType = occupancyType;
	}

	public void Execute(BoardContext context)
	{
		context.OccupancyLedger.MarkShape(_address, _occupancyType);
	}
}