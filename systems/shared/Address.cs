using Godot;
using System.Collections.Generic;
using System.Linq;
public sealed record Address(Vector2I StartCell, IEnumerable<Vector2I> Shape)
{
	public IEnumerable<Vector2I> OccupiedCells => Shape.Select(offset => StartCell + offset);
}

