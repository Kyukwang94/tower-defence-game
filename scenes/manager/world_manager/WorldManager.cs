using Godot;
using System.Collections.Generic;
using Game.Enums;

public partial class WorldManager : Node
{
	public static WorldManager Instance;

	private readonly Dictionary<ItemType,TileMapLayer> _allLayers = [];

	[Export] private GroundManager groundManager;

	public override void _Ready()
	{
		Instance = this;

		_allLayers.Add(ItemType.Ground,groundManager.groundTileMapLayer);
	}

	public override void _ExitTree()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public Dictionary<ItemType,TileMapLayer> GetAllTileMapLayers()
	{
		return _allLayers;
	}
	 	
	public TileMapLayer GetTileMapLayer(ItemType key)
	{
		_allLayers.TryGetValue(key , out var value);

		return value;
	}
	
	public GroundManager GetGroundManager()
	{
		return groundManager;
	}
}

