using Godot;
public sealed record DemolishAction() : IGridCellAction
{
	public void OnCell(Board board, Vector2I cell)
	{
		// 보드에게 이 칸을 비우라고 시킵니다.
		
	}

	public bool TryOnCell(Board board, Vector2I cell)
	{
		// 건물이 있는 칸에서만 철거가 가능합니다.
		return true;
	}
}