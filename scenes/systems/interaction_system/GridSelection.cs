using Godot;
using System.Collections.Generic;

public partial class GridSelection : Node
{
	private readonly Vector2I _start;
	private readonly Vector2I _end;

	public GridSelection(Vector2I start , Vector2I end)
	{
		_start 	= start;
		_end 	= end;
	}
	public GridArea Area()
	{
		return new GridArea(_start, _end);
	}

	public IReadOnlyCollection<Vector2I> Cells()
	{
		return Area().Cells();
	}
	
}
