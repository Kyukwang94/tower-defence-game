using Godot;
using System;
using Game.Enums;

public interface IBoard
{
	void ActOn(IGridArea gridArea, IGridCellAction action);
	void PreviewOn(IGridArea area, IGridCellAction action);
}
