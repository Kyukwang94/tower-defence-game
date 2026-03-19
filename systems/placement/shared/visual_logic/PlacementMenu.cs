using Godot;

public partial class PlacementMenu : Node
{
	[ExportGroup ("Dependencies")]
	[Export] private PlayerHand		       _playerHand;
	[Export] private PlacementItemsGallery _placementGallery;
	[Export] private GroundGalleryBtn 	   _groundSectionGalleryBtn;
	[Export] private BuildingGalleryBtn    _buildingSectionGalleryBtn;
	[Export] private GameLibrary 		  _gameLibraryResource;
	
	public override void _Ready()
	{
		_groundSectionGalleryBtn  .Setup(new GroundExhibition  (_gameLibraryResource, _placementGallery));
		_buildingSectionGalleryBtn.Setup(new BuildingExhibition(_gameLibraryResource, _placementGallery));
	}
}