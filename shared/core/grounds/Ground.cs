using Godot;
using Game.Enums;
using Game.Placement.Core.Area;
// 1. 순수 설계도: 타일의 정체성

public sealed record Ground(GroundResource Resource) : IPlaceable 
{
    public ItemType Type => Resource.Type;

	public void SetFormForDisplay(IDisplayMedia emptyForm)
	{
		emptyForm.SetTitle(Resource.Name);
		emptyForm.SetIcon(Resource.Icon);
	}

	public IGridCellAction PlacementAction(LayerBag bag) => Resource.installationRule.CreateAction(this, bag);
	public IGridArea OccupyPlan(Vector2I start, Vector2I end) => new GridArea(start, end);

	public IHandItem ToHandItem() => new GroundTool(this);
}
