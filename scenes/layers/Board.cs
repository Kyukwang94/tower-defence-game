using Game.Enums;
using Godot;
using System.Collections.Generic;

public partial class Board : Node , IBoard
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
		_worldMap = new Dictionary<ItemType, TileMapLayer>
		{
        	{ ItemType.Ground  , _groundLayer },
			{ ItemType.Building, _buildingLayer},
        };

		_layerBag = new LayerBag (_groundLayer,_occupancyLayer,_buildingLayer,_previewLayer);

		_occupancyLayer.Hide();
	}

	public void ActOn(IPlaceable item, IGridArea area)
	{	
		if(!_worldMap.TryGetValue(item.Type, out TileMapLayer layer))
		{
			GD.PrintErr($"[Board] {item.Type} 에 해당하는 레이어를 찾을 수 없습니다");
		}

		IGridCellAction placementAction = item.PlacementAction(_layerBag);
		area.ApplyTo(layer, placementAction);
	}
	
	public void PreviewOn(IPlaceable item, IGridArea area)
	{
		if (!_worldMap.TryGetValue(item.Type, out TileMapLayer itemTargetLayer))
		{
			GD.PrintErr($"[Board] {item.Type}에 해당하는 레이어를 찾을 수 없습니다.");
			return;
		}
		_previewLayer.Clear();

		IGridCellAction placementAction = item.PlacementAction(_layerBag);
		
		IGridCellAction prevAction = new PlacementPreviewAction(itemTargetLayer, placementAction);

		area.ApplyTo(_previewLayer,prevAction);
	}

	public Vector2I WorldToCell(Vector2 worldPosition)
	{
		Vector2 boardPos = _interactionLayer.ToLocal(worldPosition)	;
		return _interactionLayer.LocalToMap(boardPos);
	}

	public void PreviewOff()
	{
		_previewLayer.Clear();
	}

	

} 