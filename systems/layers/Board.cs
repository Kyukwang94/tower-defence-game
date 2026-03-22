using Game.Enums;
using Godot;
using System.Collections.Generic;
using System.Linq;
public partial class Board : Node, IBoard
{
	// 도화지
	[Export] private TileMapLayer _groundLayer;
	[Export] private TileMapLayer _buildingLayer;
	[Export] private TileMapLayer _previewLayer;
	[Export] private TileMapLayer _interactionLayer;
	[Export] private TileMapLayer _occupancyLayer;

	private Dictionary<ItemType, TileMapLayer> _worldMap = [];
	private LayerBag _layerBag;

	public override void _Ready()
	{
		Setup();
	}

	public void Setup()
	{
		_layerBag = new LayerBag(_groundLayer, _occupancyLayer, _buildingLayer, _previewLayer);
		_worldMap = new Dictionary<ItemType, TileMapLayer>
		{
	  		{ ItemType.Ground  , _groundLayer },
	  		{ ItemType.Building, _buildingLayer},
		};

		var initializabled = GetTree().GetNodesInGroup("Initializables")
		  .OfType<IInitializable>();

		foreach (var target in initializabled)
		{
			target.Initialize(_layerBag);
		}

		_occupancyLayer.Hide();

	}

	public void ActOn(IPlaceable item, IGridArea area)
	{
		if (!_worldMap.TryGetValue(item.Type, out TileMapLayer layer)) return;

		IGridCellAction action = item.PlacementAction(_layerBag);
		
		if (area.CanApply(layer, action))
		{
			area.ApplyTo(layer, action);
		}
		else
		{
			GD.Print("[Board] 무결성 파괴 감지. 설치 불가");
		}
	}

	public void PreviewOn(IPlaceable item, IGridArea area)
	{
		if (!_worldMap.TryGetValue(item.Type, out TileMapLayer itemTargetLayer))
		{
			return;
		}
		_previewLayer.Clear();

		IGridCellAction placementAction = item.PlacementAction(_layerBag);

		IGridCellAction prevAction = new PlacementPreviewAction(itemTargetLayer, placementAction);

		area.ApplyTo(_previewLayer, prevAction);
	}

	public Vector2I WorldToCell(Vector2 worldPosition)
	{
		Vector2 boardPos = _interactionLayer.ToLocal(worldPosition);
		return _interactionLayer.LocalToMap(boardPos);
	}

	public void PreviewOff()
	{
		_previewLayer.Clear();
	}
}
