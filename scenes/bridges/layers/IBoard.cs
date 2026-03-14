using Godot;
using System;
using Game.Enums;

public interface IBoard
{
	void ActOn(IHandItem item, IGridArea area);
	void PreviewOn(IHandItem item, IGridArea area);
}
