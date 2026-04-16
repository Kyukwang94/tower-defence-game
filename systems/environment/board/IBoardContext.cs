public interface IBoardContext
{
	ILayerProvider Layers { get; }
	OccupancyLedger Ledger { get; }
}