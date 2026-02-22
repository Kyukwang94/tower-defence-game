using Godot;
using System;

public abstract partial class GameDataBase : Resource
{
	public abstract GameEntityResource[] GetItems();
}
