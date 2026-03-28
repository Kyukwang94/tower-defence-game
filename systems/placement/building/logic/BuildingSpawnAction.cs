using Godot;
using System;

public sealed class BuildingSpawnAction : IGridCellAction
{
	private readonly Building _bluePrint;

	public BuildingSpawnAction(Building bluePrint)
	{
		_bluePrint = bluePrint ?? throw new ArgumentNullException(nameof(bluePrint));
	}

	public void OnCell(Board board, Vector2I cell)
	{

		var construction = new BuildingConstruction(new Address(cell), _bluePrint.Resource);
		
		construction.Execute(board);

		GD.Print($"[BuildingSpawnAction] 건물을 소환했습니다: {cell}");
	}


	public bool TryOnCell(Board board, Vector2I cell)
	{
		return _bluePrint != null && _bluePrint.Resource != null;
	}
}