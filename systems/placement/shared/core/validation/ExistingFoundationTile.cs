using Godot;

public sealed class ExistingFoundationTile : IGridCellAction
{
	private readonly IGridCellAction _origin;

	public ExistingFoundationTile(IGridCellAction origin )
	{
		_origin = origin;
	}

	public bool TryOnCell(BoardEnvironment boardEnv , Vector2I cell)
	{
		if(boardEnv.Ask(new HasFoundation(cell)) && _origin.TryOnCell(boardEnv , cell))
		{
			return true;
		}
		else
		{
			GD.Print($"[ExistingFoundationTile] False ");
			return false;
		}	
	}

	public void OnCell(BoardEnvironment boardEnv, Vector2I cell)
	{
		if(TryOnCell(boardEnv, cell))
		{
			_origin.OnCell(boardEnv, cell);
		}
	}
}
