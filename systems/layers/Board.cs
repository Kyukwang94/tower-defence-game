using System.Collections.Generic;
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
	private BoardContext _context;
	public ILayerProvider LayerProvider => _layerBag;

	public override void _Ready()
	{
		_layerBag = new LayerBag(_groundLayer, _occupancyLayer, _buildingLayer, _prevLayer, _interactionLayer);
		_occupancyLedger = new OccupancyLedger(_layerBag.Occupancy);
		_context = new(this, _occupancyLedger, _layerBag);

		_occupancyLayer.Hide();
		ActOn(new SyncEditorBuildingsAction());
	}

	public void ActOn(IGridArea area, IGridCellAction action)
	{
		ActOn(new ClearPreviewAction());

		if (area.CanApply(_context, action))
		{
			area.ApplyTo(_context, action);
		}
		else
		{
			GD.Print("[Board] 설치 불가");
		}
	}

	public void ActOn(IBoardAction boardAction)
	{
		boardAction.Execute(_context);
	}

	public T Ask<T>(ILayerQuery<T> query)
	{
		return query.Execute(LayerProvider);
	}
}
