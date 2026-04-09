using Godot;

public partial class GroundGalleryBtn : Button 
{
	private IExhibition _exhibition;
	[Export] PlayerHand playerHand;

	public	void Setup(IExhibition exhibition)
	{
		_exhibition = exhibition;
		
		GD.Print("[GroundGalleryBtn] Exhibition Set");
	}

	public override void _Pressed()
	{
		_exhibition.Open();

		playerHand.Grasp(NoHandItem.Instance);
		GD.Print("[GroundGalleryBtn] Open Exhibition");
	}
}
