using Godot;


[GlobalClass]
public partial class BuildingSection : Resource
{
	[Export] private BuildingResource[] _items;

	public void Accept(IGallery gallery)
	{
		gallery.ClearAll();

		foreach (var item in _items)
		{
			var building = new Building(item);

			gallery.Show(new BuildingExhibit(building));

			GD.Print(item.Name);
		}
	}
}
