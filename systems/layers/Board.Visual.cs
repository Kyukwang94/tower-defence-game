using Godot;

public partial class Board
{

	public void PreviewOff()
	{
		_prevLayer.Clear();
	}

	public void PreviewOn(IGridArea area, IGridCellAction action)
	{
		_prevLayer.Clear();

		area.ApplyTo(this, action);
	}

	public void SetCellAtPrev(Vector2I cell, int sourceId, Vector2I coords)
	{
		_layerBag.preview.SetCell(cell, sourceId, coords);
	}


	public void SetTile(Vector2I cell, int sourceId, Vector2I atlasCoords)
	{
		_layerBag.ground.SetCell(cell, sourceId, atlasCoords);
	}
}