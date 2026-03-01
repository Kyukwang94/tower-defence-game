using Godot;
using System;

public interface IPlaceable
{
	IGridCellAction Validated(IGridCellAction origin, ILayerProvider map, bool isDevMode);

	void BuildOn(ILayerProvider mapProvider, Vector2I cell);
}
