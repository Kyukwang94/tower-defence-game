using Godot;
using System;
using System.Linq;

[GlobalClass]
public partial class BuildingSection : Resource
{
	[Export] private BuildingResource[] _items;

	public void Accept(IGallery gallery)
	{
		gallery.ClearAll();

		foreach (var item in _items)
		{
			GD.Print(item.Name);
			new BuildingBluePrint(item).ToDisplayableItem().DisplayOn(gallery);
		}
	}
}
