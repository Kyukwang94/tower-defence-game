using Godot;
using Game.Action.Validation;

public sealed class GroundStandardPlacement : IGridCellAction
{
	private readonly IGridCellAction _origin;

	public GroundStandardPlacement(Ground bluePrint, LayerBag layerBag)
	{
		IGridCellAction action = new GroundPaint(
			bluePrint.Resource.SourceId,
			bluePrint.Resource.AtlasCoords
			);

		if (bluePrint.Resource.SpecificRules != null)
		{
			foreach (var rule in bluePrint.Resource.SpecificRules)
			{
				action = rule.Wrap(action);
			}
		}
		
		action = new OccupancyAction(
			action,
			layerBag.occupancy,
			bluePrint.Resource.MyType,
			bluePrint.Resource.ConflictsWith);

		action = new ExistingFoundationTile(layerBag.ground, action);
		action = new UniqueTilePlacement(action, bluePrint.Resource.SourceId, bluePrint.Resource.AtlasCoords);

		_origin = action;
	}

	public void OnCell(TileMapLayer layer, Vector2I cell) => _origin.OnCell(layer, cell);
	public bool TryOnCell(TileMapLayer layer, Vector2I cell) => _origin.TryOnCell(layer, cell);
}
