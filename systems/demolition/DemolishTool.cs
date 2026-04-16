using Game.Placement.Core.Area;
using Godot;
using System.Linq;
public sealed record DemolishTool(DemolishResource Core) : IHandTool
{
	public ICursorDesign CursorDesign() => new DemolishCursorDesign(Core);
	public void Act(Board board, Vector2I start, Vector2I end)
	{
		board.ActOn(new BuildingDemolition(end));
	}

	public void ActPrev(Board board, Vector2I start, Vector2I end)
	{	
		board.ActOn(new DemolitionPreview(end));		
	}
}