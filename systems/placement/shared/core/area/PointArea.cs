using System.Collections.Generic;
using Godot;

public sealed class PointArea : IGridArea
{
    private readonly Vector2I _point;

    public PointArea(Vector2I point) => _point = point;

    public bool CanApply(BoardEnvironment boardEnv, IGridCellAction action) 
        => action.TryOnCell(boardEnv, _point);

    public void ApplyTo(BoardEnvironment boardEnv, IGridCellAction action) 
        => action.OnCell(boardEnv, _point);

	public IEnumerable<Vector2I> CalculateCells()
	{
		yield return _point;
	}
}