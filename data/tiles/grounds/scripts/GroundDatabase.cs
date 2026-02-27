using Godot;
using System;

[GlobalClass]
public partial class GroundDatabase : GameDataBase
{
	[Export] public GroundResource[] AllGroundResources {get; private set;}

	public override GameEntityResource[] GetItems()
	{
		return AllGroundResources;
	}
}
