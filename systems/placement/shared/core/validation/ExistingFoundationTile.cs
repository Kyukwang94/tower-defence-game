using Godot;

public sealed class ExistingFoundationTile : IGridCellAction
{
	private readonly IGridCellAction _origin;

	public ExistingFoundationTile(IGridCellAction origin )
	{
		_origin = origin;
	}

	public bool TryOnCell(BoardContext context , Vector2I cell)
	{
		if(context.Board.Ask(new HasFoundation(cell)) && _origin.TryOnCell(context , cell))
		{
			return true;
		}
		else
		{
			GD.Print($"[ExistingFoundationTile] False ");
			return false;
		}	
	}

	public void OnCell(BoardContext context, Vector2I cell)
	{
		if(TryOnCell(context, cell))
		{
			_origin.OnCell(context, cell);
		}
	}
}
