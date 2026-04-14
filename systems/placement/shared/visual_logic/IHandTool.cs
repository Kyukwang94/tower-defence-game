using Godot;
using System.Collections.Generic;
using Game.Enums;

public interface IHandTool
{
	public ICursorDesign CursorDesign();
	public void Act(BoardEnvironment boardEnv, Vector2I start, Vector2I end);
	public void ActPrev(BoardEnvironment boardEnv, Vector2I start, Vector2I end);
}
