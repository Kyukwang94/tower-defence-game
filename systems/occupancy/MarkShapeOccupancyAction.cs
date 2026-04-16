using Game.Enums;
using Godot;

public sealed class MarkShapeOccupancyAction : IBoardAction
{
	private readonly Address _address;
	private readonly OccupancyType _occupancyType;
	public MarkShapeOccupancyAction(Address address, OccupancyType occupancyType)
	{
		_address = address;
		_occupancyType = occupancyType;
	}
	public void Execute(IBoard boardContext)
	{
		boardContext.Ledger.MarkShape(_address, _occupancyType);
	}
}