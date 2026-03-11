using Godot;
using System;
using Game.Enums;

public sealed class GroundExhibition : IExhibition
{
	private readonly GameLibrary _library;
	private readonly IGallery _gallery;

	public GroundExhibition(GameLibrary library, IGallery gallery)
	{
		_library = library;
		_gallery = gallery;
	}
	
	public void Open()
	{
		_library.Guide(ItemType.Ground, _gallery);
	}
}
