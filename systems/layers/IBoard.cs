using Godot;
// public record BoardContext(IBoard Board, OccupancyLedger OccupancyLedger, ILayerProvider LayerProvider);

public sealed class BoardContext
{
	private readonly IBoard _board;
	private readonly OccupancyLedger _occupancyLedger;
	private readonly ILayerProvider _layerProvider;

	public BoardContext(IBoard board, OccupancyLedger occupancyLedger, ILayerProvider layerProvider)
	{
		_board = board;
		_occupancyLedger = occupancyLedger;
		_layerProvider = layerProvider;
	}

	
}
public interface ILayerProvider
{
	TileMapLayer Building { get;}
	TileMapLayer Ground { get;}
	TileMapLayer Preview { get;}
	TileMapLayer Interaction {get;}
	TileMapLayer Occupancy {get;}
}
public interface IBoardAction
{
	void Execute(BoardContext boardContext);
}

public interface IBoard
{
	ILayerProvider LayerProvider {get;}

	T Ask<T>(ILayerQuery<T> query);
	
	void ActOn(IGridArea area, IGridCellAction action);
	void ActOn(IBoardAction action);
}
