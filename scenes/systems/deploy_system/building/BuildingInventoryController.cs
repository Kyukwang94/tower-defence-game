using Godot;

public partial class BuildingInventoryController : Node
{
	[ExportGroup ("Core Features")]
	[Export] public BuildingToolsManager buildingToolsManager;
	[Export] public BuildingItemsContainer itemsContainerUI;
	[Export] public GroundButton groundButton;

	public override void _Ready()
	{
		if(!CheckConnection()) return;

		//Events 
		buildingToolsManager.CursorPreviewRequested += (icon) =>
		{
			if(ItemPreviewCursor.Instance != null)
			{
				if(icon != null)
					ItemPreviewCursor.Instance.SetPreviewSprite(icon);
				else
					ItemPreviewCursor.Instance.Reset();
			}
		};
		groundButton.GroundButtonPressed += itemsContainerUI.ShowItemsInGridContainer;
		itemsContainerUI.OnItemSelected += buildingToolsManager.LoadItem;
		itemsContainerUI.OnItemSelected += (itemData) => ItemPreviewCursor.Instance?.SetPreview(itemData);
	}

	public bool CheckConnection()
	{
		bool isValid = true;
		
		if (buildingToolsManager == null)
		{
			GD.PrintErr("BuildingToolsManager가 연결되지 않았습니다.");
			isValid = false;
		}

		if (itemsContainerUI == null)
		{
			GD.PrintErr("ItemsContainerUI가 연결되지 않았습니다");
			isValid = false;
		}
			
		return isValid;
	}
}
