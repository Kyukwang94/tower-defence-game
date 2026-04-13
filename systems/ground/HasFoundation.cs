using Godot;
public sealed class HasFoundation : ILayerQuery<bool>
{
	private readonly Vector2I _cell;

	public HasFoundation(Vector2I cell)
	{
		_cell = cell;
	}
	public bool Execute(ILayerProvider layerProvider)
	{
		if (layerProvider.Ground.GetCellSourceId(_cell) != -1)
		{
			return true;
		}
		return false;
	}
}