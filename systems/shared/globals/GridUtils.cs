using Godot;
public static class GridUtils
{
	public static readonly Vector2I TileSize = new(32, 32);

	public static Vector2I WorldToCell(Vector2 worldPosition)
	{
		return new Vector2I(
			Mathf.FloorToInt(worldPosition.X / TileSize.X),
			Mathf.FloorToInt(worldPosition.Y / TileSize.Y)
		);
	}
}