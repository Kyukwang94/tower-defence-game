using Godot;

public sealed record GroundTool(Ground Core) : IHandTool
{
	public ICursorDesign CursorDesign() => new PlayerHandDesign(Core.Resource.Icon);
	public void Selected(PlayerHand hand) => hand.Grasp(this);

	public void Act(Board board, Vector2I start, Vector2I end)
	{
		IGridArea area = Core.OccupyPlan(start, end);
		IGridCellAction action = Core.PlacementAction();
		board.ActOn(area, action );
	}
	public void ActPrev(Board board, Vector2I start, Vector2I end)
	{
		IGridArea area = Core.OccupyPlan(start, end);

		IGridCellAction placementAction = Core.PlacementAction();
		IGridCellAction prevAction = new PlacementPreviewAction(placementAction, Core.Shape);

		board.ActOn(area, prevAction);
	}

}
