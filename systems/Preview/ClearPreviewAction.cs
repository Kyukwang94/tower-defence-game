public sealed class ClearPreviewAction : IBoardAction
{	
	public void Execute(BoardEnvironment boardEnv)
	{
		boardEnv.ClearPreview();
	}
}