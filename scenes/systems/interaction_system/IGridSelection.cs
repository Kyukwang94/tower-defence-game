using Godot;
using System.Collections.Generic;

public interface IGridSelection
{
	GridArea Area();
	IReadOnlyCollection<Vector2I> Cells();
	void ApplyTo(IGridCellAction action);
}
