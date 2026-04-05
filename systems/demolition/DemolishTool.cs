using Game.Placement.Core.Area;
using Godot;

public sealed record DemolishTool(DemolishResource Core) : IHandTool
{
	public ICursorDesign CursorDesign() => new DemolishCursorDesign(Core);
	public void Act(Board board, Vector2I start, Vector2I end)
	{
		board.DemolishAt(end);
	}

	public void ActPrev(Board board, Vector2I start, Vector2I end)
	{
		//가능하다면 해당 건물의 색을 바꿀까
			
	}
}