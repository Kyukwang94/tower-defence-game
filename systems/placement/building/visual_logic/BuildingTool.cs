using Godot;
using System;

public sealed record BuildingTool(Building Core) : IHandTool
{
	public ICursorDesign CursorDesign() => new PlayerHandDesign(Core.Resource.Icon);

	public void Act(Board board, Vector2I start, Vector2I end)
	{
		IGridArea gridArea = Core.OccupyPlan(start, end);
		board.ActOn(Core, gridArea);
	}
	public void ActPrev(Board board, Vector2I start, Vector2I end)
	{
		IGridArea area = Core.OccupyPlan(start, end);
		board.PreviewOn(Core, area);
	}
}
