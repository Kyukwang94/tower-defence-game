using Godot;
using System;

public partial class PlacementPreviewAction : IGridCellAction 
{
	private readonly IGridCellAction _origin;
	
	public PlacementPreviewAction(IGridCellAction origin)
	{
		_origin = origin;
	}
 
	public bool TryOnCell(TileMapLayer layer, Vector2I cell) => true;
	

	public void OnCell(TileMapLayer layer, Vector2I cell)
	{
		bool canPlace = _origin.TryOnCell(layer, cell);
		Vector2I coords = canPlace ? new Vector2I(0,0) : new Vector2I(1, 0);
		layer.SetCell(cell, 1, coords);

		GD.Print($"PlacementPreview {coords} 가 설치됨");
	}
}
