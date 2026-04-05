using System.Collections.Generic;
using Game.Enums;
using Game.Placement.Core.Area;
using Godot;
// 1. 순수 설계도: 타일의 정체성



public sealed record Ground(GroundResource Resource) : IPlaceable
{
	public ItemType Type => Resource.Type;
	public IEnumerable<Vector2I> Shape => new[] { Vector2I.Zero };
	public void SetFormForDisplay(IDisplayMedia emptyForm)
	{
		emptyForm.SetTitle(Resource.Name);
		emptyForm.SetIcon(Resource.Icon);
	}

	public IGridCellAction PlacementAction() => Resource.installationRule.CreateAction(this);
	public IGridArea OccupyPlan(Vector2I start, Vector2I end) => new GridArea(start, end);

	public IHandTool ToHandItem() => new GroundTool(this);
}
