using Godot;
using System;

public partial class PlacementPreviewAction : IGridCellAction 
{
	private readonly IGridCellAction _origin;
	private readonly TileMapLayer _prevLayer;

	public PlacementPreviewAction(TileMapLayer prevLayer, IGridCellAction origin)
	{
		_prevLayer = prevLayer;
		_origin = origin;
	}
 
	public bool TryOnCell(TileMapLayer layer, Vector2I cell) => true;
	

	public void OnCell(TileMapLayer layer, Vector2I cell)
	{
		bool canPlace = _origin.TryOnCell(_prevLayer, cell);
		
		Vector2I coords = canPlace ? new Vector2I(0,0) : new Vector2I(1, 0);

		layer.SetCell(cell, 1, coords);
	}
}
