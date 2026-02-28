using Godot;
using System.Collections.Generic;

public interface IGridSelection
{
	void ApplyTo(IGridCellAction action);
}
