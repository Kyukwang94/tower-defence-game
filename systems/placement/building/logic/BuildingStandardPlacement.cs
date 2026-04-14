using System;
using Godot;

public sealed class BuildingStandardPlacement : IGridCellAction
{
	private readonly IGridCellAction _action;
	public BuildingStandardPlacement(Building bluePrint)
	{
		IGridCellAction spawn = new BuildingSpawnAction(bluePrint);

		IGridCellAction tileLogic = new OccupancyAction(
			new EmptyAction(),
			bluePrint.Resource.MyType,
			bluePrint.Resource.ConflictsWith);

		tileLogic = new ExistingFoundationTile(tileLogic);


		IGridCellAction integrity = new ShapeIntegrity(tileLogic, bluePrint.Resource.Shape);

		_action = new PlacementComposite(integrity, spawn);
	}
	public void OnCell(BoardEnvironment boardEnv, Vector2I cell) => _action.OnCell(boardEnv, cell);
	public bool TryOnCell(BoardEnvironment boardEnv, Vector2I cell) => _action.TryOnCell(boardEnv, cell);
}
