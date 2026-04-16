using Godot;
using System.Linq;
public sealed class OccupancySync
{
	private readonly IBoard _boardContext;

	public OccupancySync(IBoard boardContext)
	{
		_boardContext = boardContext;
	}

	public void Sync()
	{
		new ILayerProvider.Smart(_boardContext.Layers).ClearOccupancy();

		var prePlacedBuildings = _boardContext.Layers.Building.GetChildren().OfType<BuildingNode>();

		foreach (var building in prePlacedBuildings)
		{
			Vector2I cell = GridUtils.WorldToCell(building.GlobalPosition);

			new BuildingInstallation(_boardContext.Layers, _boardContext.Ledger, building, building.Resource, cell).Install();
		}
	}
}