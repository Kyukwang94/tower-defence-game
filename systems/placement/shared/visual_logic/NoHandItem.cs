using Game.Placement.NullObject;

public sealed record NoHandItem : IHandItem
{
    public static readonly NoHandItem Instance = new();
    
	private NoHandItem() { }
    
    public IPlaceable ToPlaceable() => NoPlaceable.Instance;
    
    public ICursorDesign CursorDesign() => new DefaultPlayerHandDesign();
}