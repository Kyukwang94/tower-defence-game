using Godot;

public sealed record NoHandItem : IHandItem
{
    public static readonly NoHandItem Instance = new();
    
	private NoHandItem() { }
    
    public ICursorDesign CursorDesign() => new DefaultPlayerHandDesign();

	public void Act(Board board, Vector2I start, Vector2I end){	}

	public void ActPrev(Board board, Vector2I start, Vector2I end){	}

}