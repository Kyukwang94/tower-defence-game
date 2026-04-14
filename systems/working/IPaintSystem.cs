using Godot;
public interface IPaintSystem
{
	public void PaintTile(Vector2I cell, int sourceId, Vector2I coords); 
}