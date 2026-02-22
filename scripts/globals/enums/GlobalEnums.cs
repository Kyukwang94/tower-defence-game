using Godot;
using System;


namespace Game.Enums
{
	[Flags]
	public enum GroundProperties
	{
		None        = 0,
		Plantable   = 1 << 0,	
		Buildable   = 1 << 1,		
		Liquid      = 1 << 2,
		Hazard      = 1 << 3,
	}
	public enum GroundElement
	{
		Fire,
		Water,
		Nature,
		Tech,
	}

	[Flags]
	public enum ItemType
	{
		Ground,
		Decoration,
		Object,
		Unit,
	}	
}
