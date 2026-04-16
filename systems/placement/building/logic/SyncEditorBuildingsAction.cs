using Godot;
using System.Linq;
public sealed class SyncEditorBuildingsAction : IBoardAction
{
	public void Execute(IBoard boardContext)
	{
		new OccupancySync(boardContext).Sync();
	}
}