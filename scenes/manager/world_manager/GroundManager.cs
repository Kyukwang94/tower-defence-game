using Godot;
using System;
using System.Collections.Generic;
using Game.Enums;

public partial class GroundManager : Node
{

	[Export] private GroundDatabase _groundDataBase;
	[Export] public  TileMapLayer   groundTileMapLayer;
	
	
	private readonly Dictionary<string, GroundResource> _groundTileLookup = [];

	public override void _Ready()
	{
		if (_groundDataBase == null)
        {
            GD.PrintErr("GroundManager: GroundDatabase reference is missing!");
            return;
        }
		
		LoadResources();
	}
	

	public Resource[] GetAllGroundResources()
	{
		return _groundDataBase.AllGroundResources;
	}

	public GroundResource GetGroundResourceAt(Vector2I cellPos , TileMapLayer targetLayer)
	{
		TileData godotTileData = targetLayer.GetCellTileData(cellPos);

		if(godotTileData == null) return null;

		string typeKey = (string)godotTileData.GetCustomData("Name");

		if(typeKey != null && _groundTileLookup.ContainsKey(typeKey))
		{
			return _groundTileLookup[typeKey];
		}

		return null;
	}

	private void LoadResources()
	{	
		foreach (var res in _groundDataBase.AllGroundResources)
		{
			string key = res.Name.ToString();

			if (!_groundTileLookup.ContainsKey(key))
			{
				_groundTileLookup.Add(key, res);
			}
		}	
	}
}
