namespace Game.Placement.NullObject;

using Game.Enums;
using Godot;
using System.Collections.Generic;
using System;


public sealed record NoPlaceable : IPlaceable
{
    public static readonly NoPlaceable Instance = new();
    
	private NoPlaceable() { } // 외부 생성 방지

    public ItemType Type => ItemType.None;

    public IGridArea OccupyPlan(Vector2I start, Vector2I end) => EmptyArea.Instance;

    public IEnumerable<Vector2I> OccupiedOffsets() => Array.Empty<Vector2I>();

    public IGridCellAction PlacementAction(LayerBag bag) => new NoPlacementAction();
}
