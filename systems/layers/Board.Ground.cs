using Godot;

public partial class Board
{
	public bool IsGroundMatch(Vector2I cell, Vector2I requiredAtlas)
	{
		return _layerBag.ground.GetCellAtlasCoords(cell) == requiredAtlas;
	}	
	public bool HasFoundation(Vector2I cell)
	{
		if (_layerBag.ground.GetCellSourceId(cell) != -1)
		{
			return true;
		}
		return false;
	}
	public bool CanOverlap(Vector2I cell, int targetSourceId, Vector2I targetCoords)
	{
		int existingSourceId = _layerBag.ground.GetCellSourceId(cell);
		Vector2I existingCoords = _layerBag.ground.GetCellAtlasCoords(cell);

		if (existingSourceId == targetSourceId && existingCoords == targetCoords)
		{
			GD.Print($"{cell}동일한 타일이 설치되어있습니다.");
			return false;
		}
		else
		{
			GD.Print($"{cell} Overlap 통과");
			return true;
		}
	}
}