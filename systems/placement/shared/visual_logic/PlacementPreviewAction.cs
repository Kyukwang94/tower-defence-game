using System;
using System.Collections.Generic;
using Godot;

public partial class PlacementPreviewAction : IGridCellAction

{
	private readonly IGridCellAction _origin;
	private readonly IEnumerable<Vector2I> _shape;

	public PlacementPreviewAction(IGridCellAction origin, IEnumerable<Vector2I> shape)
	{
		_origin = origin;
		_shape = shape;
	}

	public bool TryOnCell(Board board, Vector2I pivot) => true;

	public void OnCell(Board board, Vector2I pivot)
	{
		bool totalCanPlace = _origin.TryOnCell(board, pivot);

		foreach (var offset in _shape)
		{
			Vector2I worldCell = pivot + offset;

			Vector2I atlasCoords = totalCanPlace ? new Vector2I(0, 0) : new Vector2I(1, 0);

			board.SetCellAtPrev(worldCell, 1, atlasCoords);
		}
	}
}
