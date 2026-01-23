using Godot;
using System;
using System.Collections.Generic;

public partial class MapManager : Node
{
	public static MapManager Instance {get; private set;}

	[Export] private TileMapLayer   _tileMapLayer;
	[Export] private TileResource[] _allTileResources;

	private Dictionary<string, TileResource> _tileLookup = new Dictionary<string, TileResource>();


	public override void _Ready()
	{
		Instance = this;
			
		foreach (var res in _allTileResources)
		{
			string key = res.Type.ToString();

			if (!_tileLookup.ContainsKey(key))
			{
				_tileLookup.Add(key, res);
			}
		}
	}
	public override void _ExitTree()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}


	public TileResource GetTileResourceAt(Vector2I gridPos)
	{
		TileData godotTileData = _tileMapLayer.GetCellTileData(gridPos);

		if(godotTileData == null) return null;

		string typeKey = (string)godotTileData.GetCustomData("Type");

		if(typeKey != null && _tileLookup.ContainsKey(typeKey))
		{
			return _tileLookup[typeKey];
		}

		return null;
	}
}
