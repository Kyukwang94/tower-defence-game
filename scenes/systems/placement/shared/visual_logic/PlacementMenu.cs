using Godot;

public partial class PlacementMenu : Node
{
	[ExportGroup ("Dependencies")]
	[Export] private PlayerHand		       _playerHand;
	[Export] private PlacementItemsGallery _placementGallery;
	[Export] private GroundGalleryBtn 	   _groundSectionGalleryBtn;
	[Export] private BuildingGalleryBtn    _buildingSectionGalleryBtn;
	[Export] private GameLibrary 		  _gameLibrary;
	
	public override void _Ready()
	{
		_groundSectionGalleryBtn  .Setup(new GroundExhibition  (_gameLibrary, _placementGallery));
		_buildingSectionGalleryBtn.Setup(new BuildingExhibition(_gameLibrary, _placementGallery));
	}
}