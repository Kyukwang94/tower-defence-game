using Godot;
using System.Collections.Generic;
using System;

public sealed class GridSelection : IGridSelection
{
	private readonly Vector2I _start;
	private readonly Vector2I _end;

	public GridSelection(Vector2I start , Vector2I end)
	{
		_start 	= start;
		_end 	= end;
	}

	public void ApplyTo(IGridCellAction action)
	{
		ArgumentNullException.ThrowIfNull(action);

		foreach (var cell in Cells())
    	{
    	    action.OnCell(cell);
    	}
	}
	//MEMO : 지향해야함 데이터를 Getter 성향이라 BuildingManager가 아직 원하는방식으로 되어있지않기때문에 타협안으로 사용됨
	//만약 고친다면 Area을 주입을 시켜주고 해당 Area로 .. 흠 .. 
	public GridArea Area()
	{
		return new GridArea(_start, _end);
	}

	public IReadOnlyCollection<Vector2I> Cells()
	{
		return Area().Cells();
	}	
}
