using Godot;
using System;



[GlobalClass]
public partial class TileResource : Resource
{
	public enum TileType
	{
		GrassFloor,
		MudFloor,
		StoneFloor,

		StoneWall,

		Water,
		Lava,
	}

	
	[Export] public TileType Type {get; set;}

	[ExportCategory("Properties")]
	[Export] public bool IsWalkable     {get; set;} = false;
	[Export] public bool IsDestructible {get; set;} = false;
}
