using Godot;
using System;


namespace Game.Enums
{
	[Flags]
	public enum GroundProperties
	{
		None        = 1 << 0,
		Plantable   = 1 << 1,	
		Buildable   = 1 << 2,		
		Walkable    = 1 << 3,
		Liquid      = 1 << 4,
		Hazard      = 1 << 5,
	}
	public enum GroundElement
	{
		Fire,
		Water,
		Nature,
		Tech,
	}

	[Flags]
	public enum TileLayers
	{
		Ground,
		Decoration,
		Object,
		Unit,
	}	
}
