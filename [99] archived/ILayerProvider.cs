using Game.Enums;
using Godot;
using System;

public interface ILayerProvider
{
	Godot.TileMapLayer GetLayer(ItemType itemType);
}
