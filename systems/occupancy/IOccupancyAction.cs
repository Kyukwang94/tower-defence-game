using Game.Enums;
using Godot;
public interface IOccupancyAction
{
	LayerType TargetLayer {get;}
	void Execute(OccupancyLedger legder);
}