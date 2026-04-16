public sealed class ClearPreviewAction : IBoardAction
{	
	public void Execute(IBoard board)
	{
		new ILayerProvider.Smart(board.Layers).ClearPreview();
	}
}