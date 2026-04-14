using Godot;
using System.Linq;
public sealed class SyncEditorBuildingsAction : IBoardAction
{
	public void Execute(BoardEnvironment boardEnv)
	{
		boardEnv.SyncOccupancyBuilding();
	}
}