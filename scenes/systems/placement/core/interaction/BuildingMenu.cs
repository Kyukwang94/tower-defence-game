using Godot;

public partial class BuildingMenu : Node
{
	[ExportGroup ("Dependencies")]
	[Export] private PlayerHand		      _playerHand;
	[Export] private BuildingItemsGallery _buildingItemsGallery;
	[Export] private GroundGalleryBtn 	  _groundGalleryButton;
	[Export] private GameLibrary 		  _gameLibrary;
	
	public override void _Ready()
	{
		_groundGalleryButton.Setup(new GroundExhibition(_gameLibrary, _buildingItemsGallery));
	}
}