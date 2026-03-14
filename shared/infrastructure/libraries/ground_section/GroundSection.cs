using Godot;
using System;
using System.Linq;
using System.Collections.Generic;
using Game.Enums;

[GlobalClass]
public partial class GroundSection : Resource
{
	[Export] private GroundResource[] _items;

	public void Accept(IGallery gallery)
	{
		foreach (var item in _items)
		{
			GD.Print(item.Name , item.AtlasCoords);
			new GroundTileItem(item).DisplayOn(gallery);
		}
	}
}
