using Godot;
using System.Collections.Generic;
using Game.Enums;

public partial class WorldManager : Node
{
	public static WorldManager Instance;

	private readonly Dictionary<TileLayers,TileMapLayer> _allLayers = [];

	[Export] private GroundManager groundManager;

	public override void _Ready()
	{
		Instance = this;

		_allLayers.Add(TileLayers.Ground,groundManager.groundTileMapLayer);
	}

	public override void _ExitTree()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public Dictionary<TileLayers,TileMapLayer> GetAllTileMapLayers()
	{
		return _allLayers;
	}

	public TileMapLayer GetTileMapLayer(TileLayers key)
	{
		_allLayers.TryGetValue(key , out var value);

		return value;
	}
	
	public GroundManager GetGroundManager()
	{
		return groundManager;
	}
}

