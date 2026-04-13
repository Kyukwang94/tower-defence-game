using Godot;

public sealed record NormalCursorDesign : ICursorDesign
{
	public Texture2D Texture => null;

	public void Apply(ICursorCanvas cursorCanvas)
	{
		cursorCanvas.SetTexture(Texture);
	}
}