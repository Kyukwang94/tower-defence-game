using System.Collections.Generic;
using Godot;

public partial class DemolishPreviewAction : IGridCellAction
{
	public void OnCell(Board board, Vector2I cell)
	{
		if (!board.HasOccupant(cell, out IDemolishable target)) return;

		Vector2I atlasCoords = target.CanDemolish() ? Vector2I.Zero : new Vector2I(1, 0);

		foreach (var occupantCell in target.Address.OccupiedCells)
		{
			board.SetCellAtPrev(occupantCell, 1, atlasCoords);
		}		
	}

	public bool TryOnCell(Board board, Vector2I cell) => true;

}