using Godot;

public sealed record NoHandItem : IHandTool
{
    public static readonly NoHandItem Instance = new();
    
	private NoHandItem() { }
    
    public ICursorDesign CursorDesign() => new DefaultPlayerHandDesign();

	public void Act(BoardEnvironment boardEnv, Vector2I start, Vector2I end){	}

	public void ActPrev(BoardEnvironment boardEnv, Vector2I start, Vector2I end){	}

}