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

	public bool TryOnCell(BoardContext context, Vector2I point) => _validator.TryOnCell(context, point);

	public void OnCell(BoardContext context, Vector2I point)
	{
		_validator.OnCell(context, point); 
		_spawn.OnCell(context, point);     
	}
}