using Godot;
using System;
using Game.Enums;
public partial class EraseComponent : Node, IToolComponent, ICursorChangingTool
{
	public ToolType TypeId => ToolType.Erase;

	public event Action<Texture2D> OnCursorChangeRequested;

	[Export] private Texture2D _iconForItemPreviewCursor;

	public void UseTool(Resource item, Vector2I globalPosition)
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
