using Godot;

public sealed record GroundPlayerHand(GroundBluePrint BluePrint) : IHandItem
{
    public ICursorDesign CursorDesign() => new PlayerHandDesign(BluePrint.Resource.Icon);
    public void Selected(PlayerHand hand) => hand.Grasp(this);    
    public IPlaceable ToPlaceable() => new GroundPlacement(BluePrint);
}
