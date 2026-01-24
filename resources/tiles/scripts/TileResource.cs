using Godot;
using System;



[GlobalClass]
public partial class TileResource : Resource
{
	public enum TileType
	{
		GrassGround,
		MudGround,
		StoneGround,

		StoneWall,

		Water,
		Lava,
	}
	[ExportGroup ("NAME")]
	[Export] public TileType Type {get; set;}

	[ExportGroup ("Visuals")]
	[Export] public Texture2D Icon {get; set;}
	[Export] public int AlternativeTileId {get; set;} = 0;
	
	[ExportGroup ("TileMapLayer Info")]
	[Export] public int SourceId {get; set;} = 0;
	[Export] public Vector2I AtlasCoords {get; set;}

	
	
	[ExportGroup("GamePlay Logic")]
	[Export] public bool IsWalkable     {get; set;} = false;
	[Export] public bool IsDestructible {get; set;} = false;
}
