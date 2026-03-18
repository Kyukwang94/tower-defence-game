using Godot;
using System.Collections.Generic;

public partial class PlacementItemsGallery : Node , IGallery
{   
	[Export] private PlayerHand playerHand;

	private readonly HashSet<string> _buttons = [];

	public void Show(IDisplayable item)
	{
		Button mockBtn = new Button();
		
		string label  = item.Label;
		Texture2D img = item.Icon;	

		mockBtn.Icon = img;
		mockBtn.Text = label;
		mockBtn.Pressed += () =>
		{
			GD.Print($"[Gallery] {item.Label} Button Pressed!");
			item.Select(playerHand);
		};
		
		if(!_buttons.Contains(item.Label)) 
		{
			_buttons.Add(item.Label);
			AddChild(mockBtn);	
		}
	}
	public void ClearAll()
    {
        _buttons.Clear();
        
        foreach (Node child in GetChildren())
        {
            if (child is Button)
            {
                child.QueueFree();
            }
        }
    }

}