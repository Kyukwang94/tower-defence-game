using Godot;
using System.Collections.Generic;
using Game.Placement.Core.Area;
using Game.Action.Validation;
using Game.Enums;

public sealed record GroundPlacement(GroundBluePrint BluePrint) : IPlaceable
{
	public ItemType Type => BluePrint.Resource.Type;

	public IGridArea OccupyPlan(Vector2I start, Vector2I end) => new GridArea(start, end);

	public IEnumerable<Vector2I> OccupiedOffsets()
	{
		yield return new Vector2I(0, 0);
	}

	public IGridCellAction PlacementAction(LayerBag layerBag)
	{
		// 기본 행위: 타일 칠하기
		IGridCellAction action = new GroundPaint(BluePrint.Resource.SourceId, BluePrint.Resource.AtlasCoords);

		// 1. 변칙 규칙 (Variant Rules): 리소스에 정의된 특수 로직들 적용
		if (BluePrint.Resource.SpecificRules != null)
		{
			foreach (var rule in BluePrint.Resource.SpecificRules)
			{
				action = rule.Wrap(action);
			}
		}

		// 2. 보편적 법칙 (Universal Laws): 모든 타일이 지켜야 하는 규칙
		action = new OccupancyAction(
			action,
			layerBag.occupancy,
			BluePrint.Resource.MyType,
			BluePrint.Resource.ConflictsWith);

		action = new ExistingFoundationTile(layerBag.ground, action);
		action = new UniqueTilePlacement(action, BluePrint.Resource.SourceId, BluePrint.Resource.AtlasCoords);

		return action;
	}
}