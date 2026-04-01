using Godot;
using System.Collections.Generic;
public interface IDemolishable
{
	void Demolish(Board board);
	IEnumerable<Vector2I> Shape();
}