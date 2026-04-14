using System.Collections.Generic;
using Godot;

public partial class DemolishPreviewAction : IGridCellAction
{
	public void OnCell(BoardEnvironment boardEnv, Vector2I cell)
	{
		boardEnv.ShowPreviewForDemolishBuilding(cell);
	}

	public bool TryOnCell(BoardEnvironment boardEvn, Vector2I cell) => true;

}