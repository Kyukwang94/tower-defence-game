using Godot;
using System;



public partial class DevToolsSystem : Node
{
	[ExportGroup ("Core Features")]
	[Export] public DevToolsManager devToolsManager;
	[Export] public DevToolsController devToolsController;
	[Export] public DevToolsItemsContainerUI itemsContainerUI;

	public override void _Ready()
	{
		if(!CheckConnection()) return;

		//Events 
		devToolsController.eraseBtn.Pressed += () => devToolsManager.ActivateTool(DevToolsManager.ToolType.Erase);
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
			
		if (devToolsController == null)
		{
			GD.PrintErr("DevToolsController가 연결되지 않았습니다");
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
