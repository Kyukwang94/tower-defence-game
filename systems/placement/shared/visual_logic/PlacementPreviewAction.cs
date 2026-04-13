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
	public void OnCell(BoardContext context, Vector2I pivot)
	{
		bool totalCanPlace = _origin.TryOnCell(context, pivot);

		foreach (var offset in _shape)
		{
			Vector2I worldCell = pivot + offset;

			Vector2I atlasCoords = totalCanPlace ? new Vector2I(0, 0) : new Vector2I(1, 0);

			context.Board.ActOn(new SetCellAtPrevAction(worldCell, 1, atlasCoords));
		}
	}
	public bool TryOnCell(BoardContext board, Vector2I pivot) => true;
}
