using System;
using Godot;


namespace Game.Enums
{

	//SpecificGroundRequired

	[Flags]
	public enum GroundProperties
	{
		None = 0,
		Plantable = 1 << 0,
		Buildable = 1 << 1,
		Liquid = 1 << 2,
		Hazard = 1 << 3,
	}



	public enum GroundElement
	{
		Fire,
		Water,
		Nature,
		Tech,
	}



	public enum ItemType
	{
		Ground,
		Decoration,
		Building,
		Unit,
		None,
	}

	[Flags]
	public enum OccupancyType
	{
		None = 0,
		Building = 1 << 0,
		Unit = 1 << 1,
		Terrain = 1 << 2,
		Obstacle = 1 << 3
	}
	public enum LayerType { Ground, Occupancy, Building, Preview, Interaction, None }
}
