using Godot;


public partial class BuildingGalleryBtn : Button
{
	private IExhibition _exhibition;
	[Export] PlayerHand playerHand;
	public void Setup(IExhibition exhibition)
	{
		_exhibition = exhibition;
		GD.Print("[BuildingGalleryBtn] Exhibition Set");
	}
	public override void _Pressed()
	{
		_exhibition.Open();

		playerHand.Grasp(NoHandItem.Instance);
		GD.Print("[BuildingGalleryBtn] Open Exhibition");
	}

}
