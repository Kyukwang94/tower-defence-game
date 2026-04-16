using Godot;
using System;

public sealed class BuildingSpawnAction : IGridCellAction
{
	private readonly Building _bluePrint;

	public BuildingSpawnAction(Building bluePrint)
	{
		_bluePrint = bluePrint ?? throw new ArgumentNullException(nameof(bluePrint));
	}

	public void OnCell(IBoard boardContext, Vector2I cell)
	{
		var construction = new BuildingConstruction(new Address(cell, _bluePrint.Shape), _bluePrint.Resource);
		
		construction.Execute(boardContext);

		GD.Print($"[BuildingSpawnAction] 건물을 소환했습니다: {cell}");
	}


	public bool TryOnCell(IBoard boardContext, Vector2I cell)
	{
		return _bluePrint != null && _bluePrint.Resource != null;
	}
}