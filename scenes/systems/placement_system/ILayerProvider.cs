using Game.Enums;
using Godot;
using System;

public interface ILayerProvider
{
	TileMapLayer GetLayer(ItemType itemType);
}
