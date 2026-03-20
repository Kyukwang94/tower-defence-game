using Godot;
using System;

public sealed class BuildingSpawnAction : IGridCellAction
{
	private readonly BuildingBluePrint _bluePrint;
	private readonly LayerBag _layerBag;

	public BuildingSpawnAction(BuildingBluePrint bluePrint, LayerBag layerBag)
	{
		_bluePrint = bluePrint ?? throw new ArgumentNullException(nameof(bluePrint));
		_layerBag = layerBag ?? throw new ArgumentNullException(nameof(layerBag));
	}

	public void OnCell(TileMapLayer layer, Vector2I cell)
	{

		Address address = new(cell);

		Building building = new BuildingConstruction(address, _bluePrint.Resource, _layerBag).Shipping();
		
		layer.AddChild(building);

		GD.Print($"[BuildingSpawnAction] 건물을 소환했습니다: {cell}");
	}


	public bool TryOnCell(TileMapLayer layer, Vector2I cell)
	{
		return _bluePrint != null && _bluePrint.Resource != null;
	}
}