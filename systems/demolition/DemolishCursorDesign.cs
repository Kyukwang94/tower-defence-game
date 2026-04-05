using Godot;

public sealed record DemolishCursorDesign : ICursorDesign
{
	private readonly Texture2D _mouseTexture;
	
	public DemolishCursorDesign(DemolishResource resource)
	{
		_mouseTexture = resource.MouseTexture;

		GD.Print("[DemolishCursorDesign] cursor Texture Set");
	}
	public void Apply(ICursorCanvas cursorCanvas)
	{
		cursorCanvas.SetColor  (new Color(1,1,1,1.0f));
		cursorCanvas.SetMouseCursor(_mouseTexture);
	}
}