using Godot;
using System;

public partial class DevToolsController : CanvasLayer
{
	[Export] public BaseButton eraseBtn;

	public override void _Ready()
	{
		this.Visible = false;	
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
