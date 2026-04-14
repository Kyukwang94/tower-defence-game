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

	public bool TryOnCell(BoardEnvironment boardEnv, Vector2I point) => _validator.TryOnCell(boardEnv, point);

	public void OnCell(BoardEnvironment boardEnv, Vector2I point)
	{
		_validator.OnCell(boardEnv, point); 
		_spawn.OnCell(boardEnv, point);     
	}
}