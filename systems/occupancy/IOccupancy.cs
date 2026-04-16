using Godot;
using Game.Enums;
public interface IOccupancy
{
	public void MarkShape(Address address, OccupancyType myType);
	public void RegisterOccupant(BuildingNode node, BuildingResource res, Vector2I cell);
	public void UnRegisterOccupant(Address address);
	public void MarkCell(Vector2I cell, OccupancyType myType);
	public void ClearOccupancy();
}