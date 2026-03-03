using Godot;
using Game.Enums;
using System.Linq;
using System;

public partial class BuildingItemsContainer : Node
{   
	[Export] GameDataManager DataManager;

    // 선택된 아이템을 매니저에게 알리는 신호
    public event Action<IPlaceable> ItemSelected;
	public event Action<Texture2D>  ItemIconSelected;

    public override void _Ready()
    {        
		CallDeferred(nameof(InitUI));
    }

	//Main 기능
    public void ShowItemsInGridContainer(int itemType)
    {
		Resource[] itemDataList = DataManager.GetItemDataList((ItemType)itemType);

		if(itemDataList == null || itemDataList.Length == 0) return;

		foreach (Button child in GetChildren().Cast<Button>())
        {
			child.QueueFree();	   
        }
		foreach (var itemData in itemDataList)
		{
			if (itemData is not GameEntityResource gameItem) continue;
			Button btn = new Button
			{
				Icon = gameItem.Icon,
				ExpandIcon = true,
				Alignment = HorizontalAlignment.Left,
				CustomMinimumSize = new Vector2(40,40),
			};

			if(itemData is IPlaceable placeableItem)
			{
				btn.Pressed += () =>
				{
					ItemSelected?.Invoke(placeableItem);
					ItemIconSelected?.Invoke(gameItem.Icon);
				}
				;
			}
			this.AddChild(btn);
        }
	}       

	private void InitUI()
    {
		ShowItemsInGridContainer((int)ItemType.Ground);
    }
}