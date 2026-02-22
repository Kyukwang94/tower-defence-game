using Godot;

public partial class BuildingInventoryController : Node
{
	[ExportGroup ("Core Features")]
	[Export] public DevToolsManager devToolsManager;
	[Export] public BuildingItemsContainer itemsContainerUI;
	[Export] public GroundButton groundButton;

	public override void _Ready()
	{
		if(!CheckConnection()) return;

		//Events 
		devToolsManager.CursorPreviewRequested += (icon) =>
		{
			if(ItemPreviewCursor.Instance != null)
			{
				if(icon != null)
					ItemPreviewCursor.Instance.SetPreviewSprite(icon);
				else
					ItemPreviewCursor.Instance.Reset();
			}
		};
		groundButton.GroundButtonPressed += (itemType) => itemsContainerUI.ShowItemsInGridContainer(itemType);
		itemsContainerUI.OnItemSelected += devToolsManager.LoadItem;
		itemsContainerUI.OnItemSelected += (itemData) => ItemPreviewCursor.Instance?.SetPreview(itemData);
	}

	public bool CheckConnection()
	{
		bool isValid = true;
		if (devToolsManager == null)
		{
			GD.PrintErr("DevToolsManager가 연결되지 않았습니다.");
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
