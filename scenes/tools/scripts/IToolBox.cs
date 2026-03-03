using Godot;
using System;
using Game.Enums;
public interface IToolBox
{
	ToolType TypeId {get;}

	IGridCellAction ActionFor(IPlaceable item, ILayerProvider map);
	void Activate();
	void Deactivate();
}
