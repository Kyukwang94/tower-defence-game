using Godot;
using System.Collections.Generic;

public partial class PlacementItemsGallery : Node , IGallery
{   
	[Export] private PlayerHand playerHand;

	private readonly HashSet<string> _buttons = [];

	public void Show(IButtonInfo item)
	{
		Button mockBtn = new Button();
		
		string label  = item.Label;
		Texture2D img = item.Icon;	

		mockBtn.Icon = img;
		mockBtn.Text = label;
		mockBtn.Pressed += () =>
		{
			GD.Print($"[Gallery] {item.Label} Button Pressed!");
			item.Selected(playerHand);
		};
		
		if(!_buttons.Contains(item.Label)) 
		{
			_buttons.Add(item.Label);
			AddChild(mockBtn);	
		}
	}
	public void ClearAll()
    {
        // HashSet 초기화
        _buttons.Clear();
        // 모든 자식 노드를 순회하며 제거
        foreach (Node child in GetChildren())
        {
            // Button 타입인 경우에만 안전하게 삭제
            if (child is Button)
            {
                child.QueueFree();
            }
        }
    }
}