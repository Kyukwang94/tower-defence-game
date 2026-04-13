public sealed class ClearPreviewAction : IBoardAction
{	
	public void Execute(BoardContext boardContext)
	{
		boardContext.LayerProvider.Preview.Clear();
	}
}