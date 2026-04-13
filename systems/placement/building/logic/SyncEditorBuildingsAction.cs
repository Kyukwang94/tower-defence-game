using Godot;
using System.Linq;
public sealed class SyncEditorBuildingsAction : IBoardAction
{
	public void Execute(BoardContext boardContext)
	{
		boardContext.OccupancyLedger.Clear();

		var prePlacedBuildings = boardContext.LayerProvider.Building.GetChildren().OfType<BuildingNode>();

		foreach (var building in prePlacedBuildings)
		{
			Vector2I cell = GridUtils.WorldToCell(building.GlobalPosition);
			
			boardContext.Board.ActOn(new PlaceBuildingAction(building, building.Resource, cell));
		}
	}
}