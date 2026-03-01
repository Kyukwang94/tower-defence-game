using Godot;
using System;

public class Brush : IGridCellAction
{
	private readonly ILayerProvider _mapProvider;
	private readonly IPlaceable 	_item;
	
	public Brush(ILayerProvider mapProvider, IPlaceable item)
	{
		_mapProvider = mapProvider;
		_item = item;
	}
	
	public void OnCell(Vector2I cell)
	{
		_item.BuildOn(_mapProvider, cell);
	}
}
