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
		
		foreach (var item in _items)
		{
			var ground = new Ground(item);
			
			gallery.Show(new GroundExhibit(ground));

			GD.Print(item.Name);
		}
	}
}
	