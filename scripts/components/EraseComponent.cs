using Godot;
using System;

public partial class EraseComponent : Node, IToolComponent, ICursorChangingTool
{
	public DevToolsManager.ToolType TypeId => DevToolsManager.ToolType.Erase;

	public event Action<Texture2D> OnCursorChangeRequested;

	[Export] private Texture2D _iconForItemPreviewCursor;

	public void UseTool(Resource item, Vector2 globalPosition)
	{
		GD.Print($"Erase: {globalPosition} Clicked");
	}

	public void Activate()
	{
		OnCursorChangeRequested?.Invoke(_iconForItemPreviewCursor);
		GD.Print("Erase Tool Activated: Cursor Changed");
	}
	public void Deactivate()
	{
		OnCursorChangeRequested?.Invoke(null);
		GD.Print("Erase Tool Deactivated");
	}

}
