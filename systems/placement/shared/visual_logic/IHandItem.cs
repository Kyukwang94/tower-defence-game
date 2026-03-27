using Godot;
using System.Collections.Generic;
using Game.Enums;

public interface IHandTool
{
	public ICursorDesign CursorDesign();
	public void Act(Board board, Vector2I start, Vector2I end);
	public void ActPrev(Board board, Vector2I start, Vector2I end);
}
