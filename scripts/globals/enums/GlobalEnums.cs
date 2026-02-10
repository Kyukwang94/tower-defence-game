using Godot;
using System;


namespace Game.Enums
{
	[Flags]
	public enum DeployableFlags
	{
		GrassGround = 1 << 0,
		MudGround   = 1 << 1,
		StoneGround = 1 << 2,
		LavaGround  = 1 << 4,
	}

	public enum TileType
	{
		GrassGround,
		MudGround,
		StoneGround,

		StoneWall,

		Water,
		Lava,
	}
	
}
