using Godot;
using System;

public partial class GameModeManager : Node
{
	public static GameModeManager Instance {get; private set;}

	public bool IsDevMode {get; private set;} = false;

	[Signal]
	public delegate void DevModeChangedEventHandler(bool isDevMode);

	public override void _Ready()
	{
		Instance = this;
		GD.Print("GameModeManager Ready");
	}

	public void SetDevMode(bool isEnabled)
	{
		if(IsDevMode != isEnabled)
		{
			IsDevMode = isEnabled;
			EmitSignal(SignalName.DevModeChanged, IsDevMode);
			GD.Print($"[GameModeManager] Dev Mode Changed: {IsDevMode}");
		}
	}
}
