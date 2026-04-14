
using Godot;

public interface IPreivewSystem
{
	public void ClearPreview();
	public void PaintPreviewTile(Vector2I cell, int sourceId, Vector2I coords);
	public void ShowPreviewForDemolishBuilding(Vector2I cell);
}