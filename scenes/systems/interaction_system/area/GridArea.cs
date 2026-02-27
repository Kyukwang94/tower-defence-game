using Godot;
using System;
using System.Collections.Generic;

public sealed class GridArea
{
	private readonly Vector2I _start;
	private readonly Vector2I _end;

	public GridArea(Vector2I start, Vector2I end)
	{
		_start = start;
		_end = end;
	}
	public IReadOnlyCollection<Vector2I> Cells()
	{
		int minX = Math.Min(_start.X, _end.X);
    	int maxX = Math.Max(_start.X, _end.X);
    	int minY = Math.Min(_start.Y, _end.Y);
    	int maxY = Math.Max(_start.Y, _end.Y);	

    	var cells = new HashSet<Vector2I>();

    	for (int x = minX; x <= maxX; x++)
    	for (int y = minY; y <= maxY; y++)
    	    cells.Add(new Vector2I(x, y));

    	return cells;
	}
}
