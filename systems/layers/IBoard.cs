using Godot;
using System;
using Game.Enums;

public interface IBoard
{
	void ActOn(IGridArea area, IGridCellAction action);
	void ActOn(IOccupancyAction action);
	 void PreviewOn(IGridArea area, IGridCellAction action);
}
