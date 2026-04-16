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

	public bool TryOnCell(IBoard boardContext, Vector2I cell) => true;
	

	public void OnCell(IBoard boardContext, Vector2I cell)
	{	
		new SetTileAction(cell, _sourceId, _atlasCoords).Execute(boardContext);
		GD.Print($"[GroundPaint]{cell}에 Paint 성공!");
	}
	
}
