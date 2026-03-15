using Game.Enums;
using Godot;
using System.Collections.Generic;
using System;

namespace Game.Placement.NullObject;

public sealed record NoHandItem : IHandItem
{
    public static readonly NoHandItem Instance = new();
    
	private NoHandItem() { }
    
    public IPlaceable ToGrid() => NoPlaceable.Instance;
    
    public ICursorDesign CursorDesign() => new DefaultPlayerHandDesign();
}

public sealed record NoPlaceable : IPlaceable
{
    public static readonly NoPlaceable Instance = new();
    
	private NoPlaceable() { } // 외부 생성 방지

    public ItemType Type => ItemType.None;

    public IGridArea Area(Vector2I start, Vector2I end) => EmptyArea.Instance;

    public IEnumerable<Vector2I> OccupiedOffsets() => Array.Empty<Vector2I>();

    public IGridCellAction PlacementAction(LayerBag bag) => new NoPlacementAction();
}
