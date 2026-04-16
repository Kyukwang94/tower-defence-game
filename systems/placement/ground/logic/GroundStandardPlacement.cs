using Godot;
using Game.Action.Validation;

public sealed class GroundStandardPlacement : IGridCellAction
{
	private readonly IGridCellAction _origin;

	public GroundStandardPlacement(Ground bluePrint)
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
			bluePrint.Resource.MyType,
			bluePrint.Resource.ConflictsWith);

		action = new ExistingFoundationTile(action);
		action = new UniqueTilePlacement(action, bluePrint.Resource.SourceId, bluePrint.Resource.AtlasCoords);

		_origin = action;
	}

	public void OnCell(IBoard board, Vector2I cell) => _origin.OnCell(board, cell);
	public bool TryOnCell(IBoard board, Vector2I cell) => _origin.TryOnCell(board, cell);
}
