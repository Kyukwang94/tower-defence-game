using Game.Enums;
using Godot;
using System;

public sealed class LayerBag : ILayerProvider
{
	public TileMapLayer Ground 	{get;}
	public TileMapLayer Occupancy {get;}
	public TileMapLayer Building  {get;}
	public TileMapLayer Preview   {get;}
	public TileMapLayer Interaction{get;}
	
	public LayerBag(
		TileMapLayer ground,
		TileMapLayer occupancy,
		TileMapLayer building,
		TileMapLayer preview,
		TileMapLayer interaction)
	{
		Ground 	= ground;
		Occupancy  = occupancy;
		Building   = building;
		Preview 	= preview;
		Interaction = interaction;
	}

}
