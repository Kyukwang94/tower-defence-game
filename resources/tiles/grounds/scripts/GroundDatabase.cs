using Godot;
using System;

[GlobalClass]
public partial class GroundDatabase : Resource
{
	[Export] public GroundResource[] AllGroundResources {get; private set;}
}
