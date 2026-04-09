using System;
using System.Collections.Generic;
using Game.Enums;
using Godot;

public sealed class OccupancyLedger
{
	private readonly TileMapLayer _layer;
	private readonly Dictionary<Vector2I, IDemolishable> _registry = [];
	public OccupancyLedger(TileMapLayer layer, Dictionary<Vector2I, IDemolishable> registry)
	{
		_layer = layer;
		_registry = registry;
	}

	public void MarkCell(Vector2I cell, OccupancyType occupancyType)
	{
		int current = _layer.GetCellSourceId(cell);
		int existing = (current == -1) ? 0 : current;
		_layer.SetCell(cell, existing | (int)occupancyType, Vector2I.Zero);

		GD.Print($"[Ledger] {occupancyType}에 대한 점유 기록 완료 (Cell: {cell})");
	}
	public void MarkShape(Address address, OccupancyType occupancyType)
	{
		if (occupancyType == OccupancyType.None)
		{
			foreach (var target in address.OccupiedCells)
			{
				_layer.SetCell(target, 0, Vector2I.Zero);
			}

			return;
		}
		foreach (var target in address.OccupiedCells)
		{
			int current = _layer.GetCellSourceId(target);

			int val = (current == -1) ? 0 : current;


			_layer.SetCell(target, val | (int)occupancyType, Vector2I.Zero);

			GD.Print($"[Ledger] {occupancyType}에 대한 점유 기록 완료 (Cell: {target})");
		}
	}
	public void RegisterOccupant(BuildingNode node, BuildingResource resource, Vector2I cell)
	{
		foreach (var offset in resource.Shape)
		{
			Vector2I occupiedCell = cell + offset;
			_registry[occupiedCell] = node;
		}
	}
	public void UnRegisterOccupant(Address address)
	{
		foreach (var cell in address.OccupiedCells)
		{
			_registry.Remove(cell);
		}
	}
	public bool TryGetOccupant(Vector2I cell, out IDemolishable target)
	{
		if(_registry.TryGetValue(cell, out target))
		{
			return true;	
		}
		target = null;
		return false;
		
	}
	public bool IsOccupancyConflict(Vector2I cell, OccupancyType conflictsWith)
	{
		int currentVal = _layer.GetCellSourceId(cell);

		if (currentVal == -1) return false;

		return (currentVal & (int)conflictsWith) != 0;	
	}
}