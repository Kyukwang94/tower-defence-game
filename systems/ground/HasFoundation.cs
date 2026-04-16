using Godot;
public sealed class HasFoundation : IBoardQuery<bool>
{
	private readonly Vector2I _cell;

	public HasFoundation(Vector2I cell)
	{
		_cell = cell;
	}
	public bool Ask(IBoard boardContext)
	{
		if (boardContext.Layers.Ground.GetCellSourceId(_cell) != -1)
		{
			return true;
		}
		return false;
	}
}