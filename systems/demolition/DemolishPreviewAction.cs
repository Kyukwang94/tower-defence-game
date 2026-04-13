using System.Collections.Generic;
using Godot;

public partial class DemolishPreviewAction : IGridCellAction
{
	public void OnCell(BoardContext context, Vector2I cell)
	{
		if(!context.OccupancyLedger.TryGetOccupant(cell, out IDemolishable target)) return;

		Vector2I atlasCoords = target.CanDemolish() ? Vector2I.Zero : new Vector2I(1, 0);

		foreach (var occupantCell in target.Address.OccupiedCells)
		{
			context.Board.ActOn(new SetCellAtPrevAction(occupantCell, 1, atlasCoords));
		}		
	}

	public bool TryOnCell(BoardContext board, Vector2I cell) => true;

}