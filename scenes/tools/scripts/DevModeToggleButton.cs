using Godot;
using System;

public partial class DevModeToggleButton : CheckButton
{
	[Signal]
	public delegate void DevModeChangedEventHandler(bool isOn);

	public override void _Ready()
	{
		this.Toggled += OnToggled;
	}
	private void OnToggled(bool toggledOn)
	{
		GameModeManager.Instance.SetDevMode(toggledOn);
	}
}
