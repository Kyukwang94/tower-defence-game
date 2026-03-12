using Game.Enums;
using Godot;
using System.Collections.Generic;


public partial class Stage : Node , IStage
{
    // 도화지
    [Export] private TileMapLayer _groundLayer;
	[Export] private TileMapLayer _previewLayer;

	private Dictionary<ItemType, TileMapLayer> _worldMap = [];
	
	public override void _Ready()
	{
		_worldMap = new Dictionary<ItemType, TileMapLayer>
        {
        	{ ItemType.Ground, _groundLayer },
			//새로운 아이템 추후 추가.
        };
	}

	public void ActOn(ItemType type, IGridArea area, IGridCellAction action)
	{
		if(_worldMap.TryGetValue(type, out TileMapLayer layer))
		{
			area.ApplyTo(layer, action);
		}
		else
		{
			GD.PushError($"World: {type}에 해당하는 레이어를 찾을 수 없습니다.");
		}
	}
	
	public void PreviewOn(IGridArea area, IGridCellAction action)
	{
		_previewLayer.Clear();
		area.ApplyTo(_previewLayer, action);
	}

} 