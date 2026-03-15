using Godot;
using System;
using Game.Enums;

[GlobalClass]
public partial class BuildingResource : Resource
{
	
	[Export] public string Name          {get; set;}
	[Export] public ItemType Type        {get; set;}	

	[Export] public Texture2D Icon       {get; set;}
	[Export] public int SourceId         {get; set;}
	[Export] public Vector2I AtlasCoords {get; set;}
	
	[Export] public PackedScene scene;
	
	[Export] public OccupancyType MyType;
	[Export] public OccupancyType ConflictsWith;
	
}
