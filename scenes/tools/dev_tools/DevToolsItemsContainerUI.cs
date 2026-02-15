using Godot;

public partial class DevToolsItemsContainerUI : Node
{
    [Export] public OptionButton CategoryOptionBtn; // 에디터에서 연결
    

    // 각 카테고리별 데이터베이스 연결
    //[Export] public UnitDatabase UnitDB; 
    //[Export] public BuildingDatabase BuildingDB;

    // 선택된 아이템을 매니저에게 알리는 신호
    [Signal] public delegate void OnItemSelectedEventHandler(Resource itemData);

    public override void _Ready()
    {        
		if(CategoryOptionBtn != null)
			CategoryOptionBtn.ItemSelected += OnCategoryChanged;
		
		CallDeferred(nameof(InitUI));
    }

    public void OnCategoryChanged(long index)
    {
        // 기존 버튼 싹 지우기
        foreach (Button child in this.GetChildren())
        {
			child.QueueFree();	   
        }

        // 선택된 인덱스에 따라 내용 채우기
        switch (index)
        {
            case 0: // Tiles                        
                var groundManager = WorldManager.Instance.GetGroundManager();
                if (groundManager != null)
                {
                    ShowItemsInGridContainer(groundManager.GetAllGroundResources());
                }
                break;
            case 1: // Units
                // ShowItemsInGridContainer(UnitDB.AllUnits); 
                break;
        }
    }

    private void ShowItemsInGridContainer(Resource[] items)
    {
        if (items == null) return;

        foreach (var item in items)
        {
            // 공통 인터페이스(예: IDisplayableItem)나 dynamic, 
            // 혹은 각각의 타입 캐스팅을 통해 아이콘을 가져옵니다.
            Texture2D icon = null;
			string itemName = "";
            if (item is GroundResource tile)
			{
				icon = tile.Icon;	
				itemName = tile.Name.ToString();
			}
			
            //else if (item is UnitResource unit) icon = unit.Icon;

            if (icon == null) continue;

            Button btn = new Button();
            btn.Icon = icon;
			btn.Text = " " + itemName;

			//스타일 설정
            btn.ExpandIcon = true;
			btn.Alignment = HorizontalAlignment.Left;
            btn.CustomMinimumSize = new Vector2(140, 40);
			btn.AddThemeFontSizeOverride("font_size", 12);
			btn.ClipText = true;
			
            
            // 클릭 시 해당 리소스(item)를 실어서 신호 발송
            btn.Pressed += () => EmitSignal(SignalName.OnItemSelected, item);
            
            this.AddChild(btn);
        }
    }
	private void InitUI()
    {
        if (WorldManager.Instance == null)
        {
            GD.PrintErr("WorldManager still null in CallDeferred."); // 여전히 null이면 정말 문제 있는 상황
            return; 
        }

        OnCategoryChanged(0);
    }
}