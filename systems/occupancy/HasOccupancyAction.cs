// using Godot;
// using Game.Enums;
// public sealed class HasOccupancyAction : ILayerQuery<bool>
// {
// 	private readonly Vector2I _cell;
// 	private readonly IDemolishable _target;
// 	public HasOccupancyAction(Vector2I cell, IDemolishable target)
// 	{
// 		_cell = cell;
// 		_target = target;
// 	}
// 	public bool Execute(ILayerProvider layerProvider)
// 	{
// 		int currentVal = layerProvider.Occupancy.GetCellSourceId(_cell);

// 		if (currentVal == -1) return false;

// 		return (currentVal & (int)_target) != 0;
// 	}
// }