using Godot;

public sealed record GroundTool(Ground Core) : IHandTool
{
	public ICursorDesign CursorDesign() => new PlayerHandDesign(Core.Resource.Icon);
	public void Selected(PlayerHand hand) => hand.Grasp(this);

	public void Act(BoardEnvironment boardEnv, Vector2I start, Vector2I end)
	{
		IGridArea area = Core.OccupyPlan(start, end);
		IGridCellAction action = Core.PlacementAction();
		boardEnv.ActOn(area, action );
	}
	public void ActPrev(BoardEnvironment boardEnv, Vector2I start, Vector2I end)
	{
		IGridArea area = Core.OccupyPlan(start, end);

		IGridCellAction placementAction = Core.PlacementAction();
		IGridCellAction prevAction = new PlacementPreviewAction(placementAction, Core.Shape);

		boardEnv.ActOn(area, prevAction);
	}

}
