using Godot;
using System.Collections.Generic;
using Game.Enums;

public interface IHandItem
{
	public ICursorDesign CursorDesign();
	public IPlaceable ToPlaceable();
}
