using System;
using System.Collections.Generic;
using Game.Enums;
using Godot;

public sealed record OccupancyLedger(TileMapLayer Layer)
{


	public void MarkCell(Vector2I cell, OccupancyType type)
	{
		int current = Layer.GetCellSourceId(cell);
		int existing = (current == -1) ? 0 : current;
		Layer.SetCell(cell, existing | (int)type, Vector2I.Zero);

		GD.Print($"[Ledger] {type}에 대한 점유 기록 완료 (Cell: {cell})");
	}

	public void MarkShape(Vector2I pivot, IEnumerable<Vector2I> shape, OccupancyType type)
	{
		if (type == OccupancyType.None)
		{
			foreach (var offset in shape)
			{
				Vector2I target = pivot + offset;
				Layer.SetCell(target, 0, Vector2I.Zero);
			}
		}
		foreach (var offset in shape)
		{
			Vector2I target = pivot + offset;
			int current = Layer.GetCellSourceId(target);
			int val = (current == -1) ? 0 : current;

			Layer.SetCell(target, val | (int)type, Vector2I.Zero);

			GD.Print($"[Ledger] {type}에 대한 점유 기록 완료 (Cell: {target})");
		}
	}
}