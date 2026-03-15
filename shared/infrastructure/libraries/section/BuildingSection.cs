using Godot;
using System;

[GlobalClass]
public partial class BuildingSection : Resource
{
	[Export] private BuildingResource[] _items;

	public void Accept(IGallery gallery)
	{
		gallery.ClearAll();
		
		foreach (var item in _items)
		{
			GD.Print(item.Name, item.AtlasCoords);
			new BuildingItem(item).DisplayOn(gallery);
		}
	}
}
