using Godot;
using System;
using Game.Enums;
public sealed class BuildingExhibition : IExhibition
{
	private readonly GameLibrary _library;
	private readonly IGallery _gallery;

	public BuildingExhibition(GameLibrary library, IGallery gallery)
	{
		_library = library;
		_gallery = gallery;

	}
	public void Open()
	{
		_library.Guide(ItemType.Building, _gallery);
	}

}
