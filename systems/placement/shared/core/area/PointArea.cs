using System.Collections.Generic;
using Godot;

public sealed class PointArea : IGridArea
{
    private readonly Vector2I _point;

    public PointArea(Vector2I point) => _point = point;

    public bool CanApply(BoardContext context, IGridCellAction action) 
        => action.TryOnCell(context, _point);

    public void ApplyTo(BoardContext context, IGridCellAction action) 
        => action.OnCell(context, _point);

	public IEnumerable<Vector2I> CalculateCells()
	{
		yield return _point;
	}
}