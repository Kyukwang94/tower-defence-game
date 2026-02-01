using Godot;
using System;

public static class GameUtils
{
	public const int CELL_SIZE = 32;

	public static Vector2I GetSnappedPosition (Vector2 globalPosition)
	{
		 float snappedX = Mathf.Floor(globalPosition.X / CELL_SIZE) * CELL_SIZE;
		 float snappedY = Mathf.Floor(globalPosition.Y / CELL_SIZE) * CELL_SIZE;

		 Vector2 result = new Vector2(snappedX,snappedY);

		 return (Vector2I)result;
	}

	public static Vector2 GetGridCenterPosition(Vector2 globalPosition)
	{
		Vector2 snapped = GetSnappedPosition(globalPosition);
		return snapped + new Vector2(CELL_SIZE / 2f, CELL_SIZE / 2f);
	}
}
