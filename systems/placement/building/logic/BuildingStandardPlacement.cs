using Godot;
using System;

public sealed class BuildingStandardPlacement : IGridCellAction
{
	private readonly IGridCellAction _action;

	public BuildingStandardPlacement(BuildingBluePrint bluePrint, LayerBag layerBag)
	{
		
		IGridCellAction spawn = new BuildingSpawnAction(bluePrint,layerBag);

		IGridCellAction tileLogic = new OccupancyAction(
			new EmptyAction(),
			layerBag.occupancy,
			bluePrint.Resource.MyType,
			bluePrint.Resource.ConflictsWith);

		tileLogic = new ExistingFoundationTile(layerBag.ground, tileLogic);
		
		IGridCellAction integrity = new ShapeIntegrity(tileLogic, bluePrint.Resource.Shape);

		_action = new PlacementComposite(integrity, spawn);
	}

	public void OnCell(TileMapLayer layer, Vector2I cell)  => _action.OnCell(layer, cell);
	public bool TryOnCell(TileMapLayer layer, Vector2I cell) => _action.TryOnCell(layer, cell);
}
