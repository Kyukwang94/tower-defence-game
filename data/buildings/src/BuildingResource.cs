using Godot;
using System;
using Game.Enums;
using Godot.Collections;
using System.Collections.Generic;

[GlobalClass]
public partial class BuildingResource : Resource 

{
	[Export] public string Name { get; set; }
	[Export] public ItemType Type { get; set; }

	[Export] public Texture2D Icon { get; set; }
	[Export] public PackedScene scene;

	[Export] public OccupancyType MyType;
	[Export] public OccupancyType ConflictsWith;

	[ExportGroup("Shape")]
	[Export] public Array<Vector2I> Shape { get; set; } = new() { new Vector2I(0, 0) };
	[ExportGroup("Placement")]
	[Export] public BuildingInstallationRule InstallationRule;
	
} 
