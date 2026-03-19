using Godot;
using System;

public sealed class LayerBag
{
	public readonly TileMapLayer ground    ;
	public readonly TileMapLayer occupancy ;
	public readonly TileMapLayer building  ;
	public readonly TileMapLayer preview   ;

	public LayerBag(
		TileMapLayer Ground,
		TileMapLayer Occupancy,
		TileMapLayer Building,
		TileMapLayer Preview)
	{
		ground 	= Ground;
		occupancy  = Occupancy;
		building   = Building;
		preview 	= Preview;

	}
}
