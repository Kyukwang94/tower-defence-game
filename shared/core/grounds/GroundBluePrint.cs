using Godot;
using System.Collections.Generic;
using Game.Placement.Core.Area;
using Game.Action.Validation;
using Game.Enums;

// 1. 순수 설계도: 타일의 정체성
public sealed record GroundBluePrint(GroundResource Resource)
{
    public ItemType Type => Resource.Type;
    public IHandItem ToHandItem() => new GroundPlayerHandItem(this);
    public IDisplayable ToDisplayableItem() => new GroundDisplayItem(this);
}

// 2. 디스플레이 관점: UI와 갤러리
public sealed record GroundDisplayItem(GroundBluePrint BluePrint) : IDisplayable
{
    public Texture2D Icon => BluePrint.Resource.Icon;
    public string Label => BluePrint.Resource.Name;

    public void DisplayOn(IGallery gallery)
    {
        gallery.Show(this);
    }

	public void Select(PlayerHand hand)
	{
		hand.Grasp(BluePrint.ToHandItem());
	}
}

// 3. 플레이어 손 관점: 커서와 선택 로직
public sealed record GroundPlayerHandItem(GroundBluePrint BluePrint) : IHandItem
{
    public ICursorDesign CursorDesign() => new PlayerHandDesign(BluePrint.Resource.Icon);
    
    public void Selected(PlayerHand hand)
    {
        GD.Print($"[Ground] 선택됨: {BluePrint.Resource.Name}");
        hand.Grasp(this);
    }

    // 설치 로직으로 연결
    public IPlaceable ToGrid() => new GroundPlacementItem(BluePrint);

	public IPlaceable ToPlaceable()
	{
		throw new System.NotImplementedException();
	}

}

// 4. 설치 로직 관점: 타일만의 특수한 규칙들 (Universal Laws & Variant Rules)
public sealed record GroundPlacementItem(GroundBluePrint BluePrint) : IPlaceable
{
	public ItemType Type => BluePrint.Resource.Type;
    public IGridArea Area(Vector2I start, Vector2I end) => new GridArea(start, end);

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