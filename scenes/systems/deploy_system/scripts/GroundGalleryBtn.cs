using Godot;

public partial class GroundGalleryBtn : Button 
{
	private IExhibition _exhibition;

	public	void Setup(IExhibition exhibition)
	{
		GD.Print("[GroundGalleryBtn] Exhibition Set");
		_exhibition = exhibition;
	}

	public override void _Pressed()
	{
		GD.Print("[GroundGalleryBtn] OPen Exhibition");
		_exhibition.Open();
	}	
}
