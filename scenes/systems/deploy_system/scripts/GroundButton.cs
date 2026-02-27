using Godot;
using System;
using Game.Enums;

public partial class GroundButton : Button
{
	[Signal]
	public delegate void GroundButtonPressedEventHandler(int itemType);
	
	public override void _Pressed()
	{
		EmitSignal(SignalName.GroundButtonPressed, (int)ItemType.Ground);
	}	
}
