using System.Collections.Generic;
using Godot;

public sealed class PointArea : IGridArea
{
    private readonly Vector2I _point;

    public PointArea(Vector2I point) => _point = point;

    public bool CanApply(Board board, IGridCellAction action) 
        => action.TryOnCell(board, _point);

    public void ApplyTo(Board board, IGridCellAction action) 
        => action.OnCell(board, _point);

	public IEnumerable<Vector2I> CalculateCells()
	{
		yield return _point;
	}
}