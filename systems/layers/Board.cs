using System.Collections.Generic;
using System.Linq;
using Game.Enums;
using Godot;
public partial class Board : Node, IBoard
{
	[Export] private TileMapLayer _groundLayer;
	[Export] private TileMapLayer _buildingLayer;
	[Export] private TileMapLayer _prevLayer;
	[Export] private TileMapLayer _interactionLayer;
	[Export] private TileMapLayer _occupancyLayer;

	private LayerBag _layerBag;
	private OccupancyLedger _occupancyLedger;
	private readonly Dictionary<Vector2I, IDemolishable> _occupantRegistry = [];
	private readonly Dictionary<LayerType, TileMapLayer> _layers = [];


	public override void _Ready()
	{
		_layers[LayerType.Ground] = _groundLayer;
		_layers[LayerType.Building] = _buildingLayer;
		_layers[LayerType.Preview] = _prevLayer;
		_layers[LayerType.Interaction] = _interactionLayer;
		_layers[LayerType.Occupancy] = _occupancyLayer;
		
		_layerBag = new LayerBag(_groundLayer, _occupancyLayer, _buildingLayer, _prevLayer);
		_occupancyLedger = new OccupancyLedger(_layerBag.occupancy, _occupantRegistry);
		
		_occupancyLayer.Hide();
		SyncEditorBuildings();
	}

	public void ActOn(IGridArea area, IGridCellAction action)
	{
		if (area.CanApply(this, action))
		{
			area.ApplyTo(this, action);
		}
		else
		{
			GD.Print("[Board] 무결성 파괴 감지. 설치 불가");
		}
	}

	public void ActOn(IOccupancyAction action)
	{
		action.Execute(_occupancyLedger);
	}
}
