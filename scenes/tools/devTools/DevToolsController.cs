using Godot;
using System;

public partial class DevToolsController : CanvasLayer
{
	[Export] public DevToolsManager devToolsManager;
	[Export] public BaseButton paintBtn;
	[Export] public BaseButton eraseBtn;

	public override void _Ready()
	{
		this.Visible = false;

		if (paintBtn != null) 
        	paintBtn.Pressed += () => devToolsManager.ChangeTool(DevToolsManager.ToolType.Paint);
        
        if (eraseBtn != null) 
            eraseBtn.Pressed += () => devToolsManager.ChangeTool(DevToolsManager.ToolType.Erase);
	}
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("toggle_devtool"))
		{
			this.Visible = !this.Visible;

			GetViewport().SetInputAsHandled();
		}
	}
	
}
