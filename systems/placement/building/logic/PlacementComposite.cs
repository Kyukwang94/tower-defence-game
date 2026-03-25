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

	public bool TryOnCell(TileMapLayer layer, Vector2I point) => _validator.TryOnCell(layer, point);

	public void OnCell(TileMapLayer layer, Vector2I point)
	{
		_validator.OnCell(layer, point); 
		_spawn.OnCell(layer, point);     
	}
}