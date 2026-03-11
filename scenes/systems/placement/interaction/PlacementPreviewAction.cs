using Godot;
using System;

public partial class PlacementPreviewAction : IGridCellAction 
{
	private readonly IGridCellAction _origin;
	private readonly TileMapLayer _targetLayer;
	
	public PlacementPreviewAction(IGridCellAction origin, TileMapLayer targetLayer)
	{
		_origin = origin;
		_targetLayer = targetLayer;
	}
 
	public bool TryOnCell(Vector2I cell) => true;
	

	public void OnCell(Vector2I cell)
	{
		bool canPlace = _origin.TryOnCell(cell);
		Vector2I coords = canPlace ? new Vector2I(0,0) : new Vector2I(1, 0);
		_targetLayer.SetCell(cell, 1, coords);

		GD.Print($"PlacementPreview {coords} 가 설치됨");
	}
}
