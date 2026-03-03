using Godot;
using System;
using Game.Action.Validation;

[GlobalClass]
public partial class FoundationRuleResource : Resource
{
	[Export] public Vector2I RequiredCoords {get; set;}

	public IGridCellAction Wrap(IGridCellAction origin, TileMapLayer map)
	{
		return new SpecificFoundationRequired(origin, map, RequiredCoords);
	}
}
