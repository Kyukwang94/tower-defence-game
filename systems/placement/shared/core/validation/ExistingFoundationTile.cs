using Godot;

public sealed class ExistingFoundationTile : IGridCellAction
{
	private readonly IGridCellAction _origin;

	public ExistingFoundationTile(IGridCellAction origin )
	{
		_origin = origin;
	}

	public bool TryOnCell(IBoard boardContext , Vector2I cell)
	{
		bool hasFoundation = new HasFoundation(cell).Ask(boardContext);

		if(hasFoundation && _origin.TryOnCell(boardContext , cell))
		{
			return true;
		}
		else
		{
			GD.Print($"[ExistingFoundationTile] False ");
			return false;
		}	
	}

	public void OnCell(IBoard boardContext, Vector2I cell)
	{
		if(TryOnCell(boardContext, cell))
		{
			_origin.OnCell(boardContext, cell);
		}
	}
}
