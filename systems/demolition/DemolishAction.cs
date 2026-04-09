using Godot;
public sealed record DemolishAction() : IGridCellAction
{
	public void OnCell(Board board, Vector2I cell)
	{
		board.DemolishAt(cell);
	}

	public bool TryOnCell(Board board, Vector2I cell)
	{
		return board.HasOccupant(cell, out var target);
	}
}