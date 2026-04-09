using Godot;
public partial class Board
{
	public Vector2I WorldToCell(Vector2 worldPosition)
	{
		Vector2 boardPos = _interactionLayer.ToLocal(worldPosition);
		return _interactionLayer.LocalToMap(boardPos);
	}
}