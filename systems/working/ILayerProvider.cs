using Godot;
public interface ILayerProvider
{
	TileMapLayer Building { get; }
	TileMapLayer Ground { get; }
	TileMapLayer Preview { get; }
	TileMapLayer Interaction { get; }
	TileMapLayer Occupancy { get; }
}