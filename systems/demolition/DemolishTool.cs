using Game.Placement.Core.Area;
using Godot;
using System.Linq;
public sealed record DemolishTool(DemolishResource Core) : IHandTool
{
	public ICursorDesign CursorDesign() => new DemolishCursorDesign(Core);
	public void Act(BoardEnvironment boardEnv, Vector2I start, Vector2I end)
	{
		boardEnv.DemolishBuilding(end);
	}
	

	public void ActPrev(BoardEnvironment boardEnv, Vector2I start, Vector2I end)
	{	
		IGridArea area = Core.OccupyPlan(end,end);
		
		IGridCellAction prevAction = new DemolishPreviewAction();

		boardEnv.ActOn(area, prevAction);		
	}
}	