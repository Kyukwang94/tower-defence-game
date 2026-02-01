using Godot;
using System;

[GlobalClass]
public partial class TileDatabase : Resource
{
	[Export] public TileResource[] AllTiles {get; set;} 
}
