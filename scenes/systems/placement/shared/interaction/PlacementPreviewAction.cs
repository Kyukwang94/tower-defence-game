using Godot;
using System;

public partial class PlacementPreviewAction : IGridCellAction 
{
	private readonly IGridCellAction _origin;
	private readonly TileMapLayer _FinalLayer;

	public PlacementPreviewAction(TileMapLayer finalLayer, IGridCellAction origin)
	{
		_FinalLayer = finalLayer;
		_origin = origin;
	}
 
	public bool TryOnCell(TileMapLayer layer, Vector2I cell) => true;
	

	public void OnCell(TileMapLayer layer, Vector2I cell)
	{
		bool canPlace = _origin.TryOnCell(_FinalLayer, cell);
		
		Vector2I coords = canPlace ? new Vector2I(0,0) : new Vector2I(1, 0);

		GD.Print($"PlacementPreview {coords}는 {canPlace} 이다.");

		layer.SetCell(cell, 1, coords);
	}
}
