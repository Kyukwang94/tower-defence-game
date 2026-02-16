using Godot;
using System;
using Game.Enums;



[GlobalClass]
public partial class GroundResource : TileEntityResource
{
	[ExportGroup("Ground Info")]
	[Export] public GroundProperties GroundProperties {get; set;}
	[Export] public GroundElement GroundElement{get; set;}

	
	[ExportGroup("Deploy Rule")]
	[Export] public GroundProperties RequiredGroundProperties{get; set;}	
}