using Godot;
using Game.Enums;



[GlobalClass]
public partial class GroundResource : TileEntityResource
{
	[ExportGroup("Ground Info")]
	[Export] public GroundProperties Properties {get; set;}
	[Export] public GroundElement 	 Element{get; set;}

	
	[ExportGroup("Deploy Rule")]
	[Export] public GroundProperties RequiredProperties{get; set;}	
}