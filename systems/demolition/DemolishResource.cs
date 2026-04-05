using Godot;


[GlobalClass] 
public partial class DemolishResource : Resource
{
    [Export] public Texture2D PrevTexture { get; private set; } 
	[Export] public Texture2D MouseTexture {get; private set;}
	public IGridArea OccupyPlan(Vector2I start, Vector2I end) => new PointArea(end);
}