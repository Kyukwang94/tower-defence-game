using Godot;
using System;
using Game.Enums;

public abstract partial class TileEntityResource : GameEntityResource
{
	[Export] public ItemType TargetLayer {get; set;}	

	[ExportGroup("GamePlay Logic")]
	[Export] public bool IsWalkable     {get; set;} = false;
	[Export] public bool IsDestructible {get; set;} = false;

	[ExportGroup ("Atlas Info")]
	[Export] public int SourceId {get; set;} = 0;
	[Export] public Vector2I AtlasCoords {get; set;}
	[Export] public int AlternativeTileId {get; set;} = 0;
}
