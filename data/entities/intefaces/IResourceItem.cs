using Godot;
using System;
using Game.Enums;
public interface IResourceItem 
{
	Texture2D ItemIcon { get; }
	string ItemName { get; }
	
	ToolType TargetToolType {get;}
	
}
