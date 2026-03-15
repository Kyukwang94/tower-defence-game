using Godot;
using System;

public partial class BuildingGalleryBtn : Button
{
	private IExhibition _exhibition;

	public void Setup(IExhibition exhibition)
	{
		GD.Print("[BuildingGalleryBtn] Exhibition Set");
		_exhibition = exhibition;
	}
	public override void _Pressed()
	{
		GD.Print("[BuildingGalleryBtn] Open Exhibition");
		_exhibition.Open();
	}

}
