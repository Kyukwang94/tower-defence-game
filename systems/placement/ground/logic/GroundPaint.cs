using Godot;

public sealed class GroundPaint : IGridCellAction
{
	private readonly int _sourceId;
	private readonly Vector2I _atlasCoords;
	
	public GroundPaint(int sourceId , Vector2I atlasCoords)
	{
		_sourceId = sourceId;
		_atlasCoords = atlasCoords;
	}

	public bool TryOnCell(BoardContext board, Vector2I cell) => true;
	

	public void OnCell(BoardContext context, Vector2I cell)
	{	

		context.Board.ActOn(new SetTileAction(cell, _sourceId, _atlasCoords));
		GD.Print($"[GroundPaint]{cell}에 Paint 성공!");
	}
	
}
