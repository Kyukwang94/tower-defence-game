using Godot;

public sealed record EraseTool() : IHandTool
{
	public void Act(Board board, Vector2I start, Vector2I end)
	{
		///Board쪽에 통신도해야하는데 ..
		///
		throw new System.NotImplementedException();

		
	}

	public void ActPrev(Board board, Vector2I start, Vector2I end)
	{
		throw new System.NotImplementedException();
	}

	public ICursorDesign CursorDesign()
	{
		throw new System.NotImplementedException();
	}
}