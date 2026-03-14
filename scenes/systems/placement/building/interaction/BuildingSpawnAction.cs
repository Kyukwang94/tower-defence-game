using Godot;
using System;

public sealed class BuildingSpawnAction : IGridCellAction
{
	private readonly PackedScene _buildingScene;

	public BuildingSpawnAction(PackedScene buildingScene)
	{
		_buildingScene = buildingScene;
	}

	public void OnCell(TileMapLayer layer, Vector2I cell)
	{
		var building = _buildingScene.Instantiate<Node2D>();

		layer.AddChild(building);

		building.Position = layer.MapToLocal(cell);

		GD.Print($"[BuildingSpawnAction] Spawned at {cell}");
	}

	public bool TryOnCell(TileMapLayer _bag, Vector2I cell)
	{
		return _buildingScene != null;
	}
}
