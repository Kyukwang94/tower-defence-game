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

	public bool TryOnCell(IBoard boardContext, Vector2I point) => _validator.TryOnCell(boardContext, point);

	public void OnCell(IBoard boardContext, Vector2I point)
	{
		_validator.OnCell(boardContext, point); 
		_spawn.OnCell(boardContext, point);     
	}
}