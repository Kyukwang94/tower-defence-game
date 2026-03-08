using Godot;
using Game.Enums;
using Game.Action.Validation;


[GlobalClass]
public partial class GroundResource : Resource 
{
	[ExportGroup ("Entity")]
	[Export] public string Name {get; set;}

	[ExportGroup("Ground Info")]
	[Export] public GroundProperties Properties {get; set;}
	[Export] public GroundElement 	 Element{get; set;}
	[Export] public ItemType TargetLayer {get; set;}	


	[ExportGroup ("Visuals")]
	[Export] public Texture2D Icon {get; set;}
	[Export] public int SourceId {get; set;} = 0;
	[Export] public Vector2I AtlasCoords {get; set;}
	[Export] public int AlternativeTileId {get; set;} = 0;

	[ExportGroup("Physical")]
	[Export] public bool IsWalkable     {get; set;} = false;
	[Export] public bool IsDestructible {get; set;} = false;


	[ExportGroup("Placement")]
	[Export] public Godot.Collections.Array<FoundationRuleResource> SpecificRules { get; set; }
	public int deployArea = 1;

	
} 