using Godot;
using System;
using Game.Enums;

public interface IStage
{
	void ActOn(ItemType type, IGridArea area, IGridCellAction action);
}
