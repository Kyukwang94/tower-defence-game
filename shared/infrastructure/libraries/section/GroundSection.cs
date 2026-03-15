using Godot;
using System.Linq;
using System.Collections.Generic;

[GlobalClass]
public partial class GroundSection : Resource
{
	[Export] private GroundResource[] _items;

	public void Accept(IGallery gallery)
	{
		gallery.ClearAll();

		_items.Select(item => new GroundTileItem(item))
			.ToList()
			.ForEach(tile => tile.DisplayOn(gallery));
		
	}
}
	