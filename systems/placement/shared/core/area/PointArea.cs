using System.Collections.Generic;
using Godot;

public sealed class PointArea : IGridArea
{
    private readonly Vector2I _point;

    public PointArea(Vector2I point) => _point = point;

    public bool CanApply(TileMapLayer layer, IGridCellAction action) 
        => action.TryOnCell(layer, _point);

    public void ApplyTo(TileMapLayer layer, IGridCellAction action) 
        => action.OnCell(layer, _point);

	public IEnumerable<Vector2I> CalculateCells()
	{
		yield return _point;
	}
}