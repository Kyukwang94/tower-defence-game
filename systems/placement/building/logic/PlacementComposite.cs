using Godot;

public sealed class PlacementComposite : IGridCellAction
{
	private readonly IGridCellAction _validator;
	private readonly IGridCellAction _spawn;

	public PlacementComposite(IGridCellAction validator, IGridCellAction spawn)
	{
		_validator = validator;
		_spawn = spawn;
	}

	public bool TryOnCell(Board board, Vector2I point) => _validator.TryOnCell(board, point);

	public void OnCell(Board board, Vector2I point)
	{
		_validator.OnCell(board, point); 
		_spawn.OnCell(board, point);     
	}
}