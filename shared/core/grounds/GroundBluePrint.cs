using Godot;
using Game.Enums;

// 1. 순수 설계도: 타일의 정체성
public sealed record GroundBluePrint(GroundResource Resource)
{
    public ItemType Type => Resource.Type;
    public IHandItem ToHandItem() => new GroundPlayerHand(this);
    public IDisplayable ToDisplayableItem() => new GroundDisplayItem(this);
}
