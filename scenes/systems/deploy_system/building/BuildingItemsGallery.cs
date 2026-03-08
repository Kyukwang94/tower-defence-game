using Godot;
using System.Collections.Generic;

public partial class BuildingItemsGallery : Node , IGallery
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

		if(_buttons.Add(item.Label))
		{
			item.Selected(playerHand);
			AddChild(mockBtn);	
		}

		 
	}
}