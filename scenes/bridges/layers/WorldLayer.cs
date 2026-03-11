using Game.Enums;
using Godot;
using System.Collections.Generic;


public sealed class WorldLayer : ILayerProvider
{
	private readonly Dictionary<ItemType , TileMapLayer>  _layers = [];
	
	public WorldLayer(Dictionary<ItemType, TileMapLayer> layers)
	{
		_layers = layers;
	}

	public TileMapLayer GetLayer(ItemType itemType)
	{
		return _layers.GetValueOrDefault(itemType);
	}
}
