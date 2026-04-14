using Godot;
public interface IPlacementSystem
{
	void InstallBuilding(BuildingNode node, Vector2I cell);
	void DemolishBuilding(Vector2I cell);
}