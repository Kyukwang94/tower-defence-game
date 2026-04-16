using System.Collections.Generic;
using Godot;

public partial class DemolishPreviewAction : IGridCellAction
{
	public void OnCell(IBoard boardContext, Vector2I cell)
	{
		new DemolitionPreview(cell).Execute(boardContext);
	}

	public bool TryOnCell(IBoard boardContext, Vector2I cell) => true;

}