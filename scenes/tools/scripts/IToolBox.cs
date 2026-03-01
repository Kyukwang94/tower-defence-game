using Godot;
using System;
using Game.Enums;
public interface IToolBox
{
	ToolType TypeId {get;}

	IGridCellAction MakeAction(IPlaceable item, ILayerProvider map);
	void Activate();
	void Deactivate();
}
