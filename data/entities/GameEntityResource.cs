using Godot;
using System;
using Game.Enums;

public abstract partial class GameEntityResource : Resource, IResourceItem
{

	[ExportGroup ("Base Info")]
	[Export] public string Name {get; set;}

	[Export] public Texture2D Icon {get; set;}
	[Export] ToolType ToolType {get; set;}

	public ToolType TargetToolType => ToolType;
	public Texture2D ItemIcon => Icon;
	public string ItemName => Name;
}
