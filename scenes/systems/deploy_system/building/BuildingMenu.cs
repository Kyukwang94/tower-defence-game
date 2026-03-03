using Godot;

public partial class BuildingMenu : Node
{
	[ExportGroup ("Dependencies")]
	[Export] private PlayerHand _playerHand;
	[Export] private BuildingItemsContainer itemsContainerUI;
	[Export] private GroundButton groundButton;
	[Export] private ItemPreviewCursor _previewCursor;
	public override void _Ready()
	{
		groundButton.GroundButtonPressed  += itemsContainerUI.ShowItemsInGridContainer;
		itemsContainerUI.ItemSelected     += _playerHand.Grasp;
		itemsContainerUI.ItemIconSelected += _previewCursor.SetPreviewSprite;
	}
}
