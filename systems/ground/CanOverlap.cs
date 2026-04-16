using Godot;
public sealed class CanOverlap : IBoardQuery<bool>
{
	
	private readonly Vector2I _cell;
	private readonly int _targetSourceId;
	private readonly Vector2I _targetCoords;
	public CanOverlap(
		Vector2I cell,
		int targetSourceId,
		 Vector2I targetCoords)
	{
		
		_cell = cell;
		_targetSourceId = targetSourceId;
		_targetCoords = targetCoords;
	}
	public bool Ask(IBoard board)
	{
		int existingSourceId = board.Layers.Ground.GetCellSourceId(_cell);
		Vector2I existingCoords = board.Layers.Ground.GetCellAtlasCoords(_cell);

		if (existingSourceId == _targetSourceId && existingCoords == _targetCoords)
		{
			GD.Print($"{_cell}동일한 타일이 설치되어있습니다.");
			return false;
		}
		else
		{
			GD.Print($"{_cell} Overlap 통과");
			return true;
		}
	}
}