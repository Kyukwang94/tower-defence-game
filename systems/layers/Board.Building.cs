using Godot;
using System.Linq;

public partial class Board
{
	private void SyncEditorBuildings()
	{
		_layerBag.occupancy.Clear();

		var prePlacedBuildings = _layerBag.building.GetChildren().OfType<BuildingNode>();

		foreach (var building in prePlacedBuildings)
		{

			Vector2I cell = WorldToCell(building.GlobalPosition);
			PlaceBuilding(building, building.Resource, cell);
		}
	}
	public void PlaceBuilding(BuildingNode node, BuildingResource resource, Vector2I cell)
	{
		if (node.GetParent() == null)
		{
			_layerBag.building.AddChild(node);
		}

		Vector2 centerPos = _layerBag.building.MapToLocal(cell);
		Vector2 finalPos = centerPos - new Vector2(16, 16);
		Address address = new(cell, resource.Shape.Duplicate());

		node.Setup(address, resource, finalPos);
		ActOn(new MarkShapeOccupancyAction(node.Address, resource.MyType));
		ActOn(new OccupancyRegister(node, resource, cell));
	}
}