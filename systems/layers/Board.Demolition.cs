using Godot;
using Game.Enums;
public partial class Board
{
	public void DemolishAt(Vector2I cell)
	{
		if (_occupancyLedger.TryGetOccupant(cell, out var target))
		{
			target.Demolish((address, shape) =>
			{
				ActOn(new MarkShapeOccupancyAction(target.Address, OccupancyType.None));
				ActOn(new OccupancyUnRegister(address));
			});
		}
	}	
}