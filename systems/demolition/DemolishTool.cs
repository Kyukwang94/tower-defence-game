using Game.Placement.Core.Area;
using Godot;

public sealed record DemolishTool() : IHandTool
{
	public ICursorDesign CursorDesign() => new NormalCursorDesign();
	public void Act(Board board, Vector2I start, Vector2I end)
	{
		board.TryDemolishAt(end);
	}

	public void ActPrev(Board board, Vector2I start, Vector2I end)
	{
		
	}
}