using Godot;
public interface ILayerProvider
{
	TileMapLayer Building { get; }
	TileMapLayer Ground { get; }
	TileMapLayer Preview { get; }
	TileMapLayer Interaction { get; }
	TileMapLayer Occupancy { get; }

	public sealed class Smart
	{
		ILayerProvider _origin;
		public Smart(ILayerProvider origin) => _origin = origin;
		public void ClearPreview()
		{
			_origin.Preview.Clear();
		}
		public void ClearOccupancy()
		{
			_origin.Occupancy.Clear();
		}
	}
}