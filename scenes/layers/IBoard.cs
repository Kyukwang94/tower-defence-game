using Godot;
using System;
using Game.Enums;

public interface IBoard
{
	void ActOn(IPlaceable item, IGridArea area);
	void PreviewOn(IPlaceable item, IGridArea area);
}
