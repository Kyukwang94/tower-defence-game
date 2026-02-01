using Godot;
using System;

public interface IResourceItem 
{
	Texture2D ItemIcon { get; }
	string ItemName { get; }
}
