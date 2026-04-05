using Godot;
using System;

public sealed class PlayerHandDesign : ICursorDesign
{
	private readonly Texture2D _itemTexture;
	
	public PlayerHandDesign(Texture2D itemTexture) 
	{
		_itemTexture = itemTexture;
	}

	public void Apply(ICursorCanvas cursorCanvas)
	{
		cursorCanvas.SetColor(new Color(1,1,1,0.7f));
		cursorCanvas.SetTexture(_itemTexture);
	}
}
