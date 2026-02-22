using Godot;
using Game.Enums;
using System.Linq;

public partial class BuildingItemsContainer : Node
{   
	[Export] GameDataManager DataManager;

    // 선택된 아이템을 매니저에게 알리는 신호
    [Signal] public delegate void OnItemSelectedEventHandler(Resource itemData);

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
            Texture2D icon = null;
			string itemName = "";
        
			if (itemData is GameEntityResource gameItem)
			{
				
				icon = gameItem.Icon;	
				itemName = gameItem.Name.ToString();
				
			}
			
            if (icon == null) continue;


			Button btn = new Button
			{
				Icon = icon,

				//스타일 설정
				ExpandIcon = true,
				Alignment = HorizontalAlignment.Left,
				CustomMinimumSize = new Vector2(40, 40)
			};

			btn.AddThemeFontSizeOverride("font_size", 8);
			btn.ClipText = true;
	
		
            // 클릭 시 해당 리소스(item)를 실어서 신호 발송
            btn.Pressed += () => EmitSignal(SignalName.OnItemSelected, itemData);
            
            this.AddChild(btn);
        }
    }

	private void InitUI()
    {
		ShowItemsInGridContainer((int)ItemType.Ground);
    }
}