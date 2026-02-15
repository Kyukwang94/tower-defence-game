using Godot;
using System;
using Game.Enums;


//TODO : 추상클래스 GameEntityResource를 만들어서 공통 데이터 묶어주기
[GlobalClass]
public partial class GroundResource : Resource , IResourceItem 
{
	[ExportGroup ("Info")]
	[Export] public string Name {get; set;}
	[Export] public TileLayers TargetLayer {get; set;}
	[Export] public GroundProperties TileProperties {get; set;}
	[Export] public GroundElement TileElement{get; set;}
	

	[ExportGroup ("Visuals")]
	[Export] public Texture2D Icon {get; set;}
	[Export] public int AlternativeTileId {get; set;} = 0;
	
	[ExportGroup ("TileMapLayer Info")]
	[Export] public int SourceId {get; set;} = 0;
	[Export] public Vector2I AtlasCoords {get; set;}

	[ExportGroup("GamePlay Logic")]
	[Export] public bool IsWalkable     {get; set;} = false;
	[Export] public bool IsDestructible {get; set;} = false;
	
	[ExportGroup("Deploy Rule")]
	[Export] public GroundProperties RequiredGroundProperties{get; set;}
	

	public Texture2D ItemIcon => Icon;
	public string    ItemName => Name;
}