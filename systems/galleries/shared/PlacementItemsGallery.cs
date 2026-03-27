using System.Collections.Generic;
using Godot;

public partial class PlacementItemsGallery : Node, IGallery
{
	[Export] private PlayerHand playerHand;

	private readonly HashSet<string> _buttons = [];

	public void Show(IDisplayable item)
	{
		Button btn = new();

		var btnMedia = new ButtonMedia(btn);
		item.RecallDisplayMedia(btnMedia);

		btn.Pressed += () => item.Select(playerHand);

		AddChild(btn);
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
	public sealed class ButtonMedia(Button target) : IDisplayMedia
	{
		public void SetTitle(string text) => target.Text = text;
		public void SetIcon(Texture2D icon) => target.Icon = icon;
	}
}