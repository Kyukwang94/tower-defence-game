using Godot;
using System;

public interface IPlaceable
{
	IGridCellAction PlacementAction(ILayerProvider mapProvider, bool isDevMode);
}
