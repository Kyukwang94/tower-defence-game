using Game.Enums;
using Godot;
public sealed class Board : IBoard
{
	private readonly OccupancyLedger _occupancyLedger;
	private readonly ILayerProvider _layerProvider;

	public ILayerProvider Layers => _layerProvider;

	public OccupancyLedger Ledger => _occupancyLedger;

	public Board(OccupancyLedger occupancyLedger, ILayerProvider layerProvider)
	{
		_occupancyLedger = occupancyLedger;
		_layerProvider = layerProvider;
	}
	public void ActOn(IBoardAction action)
	{
		action.Execute(this);
	}
	public T Ask<T>(IBoardQuery<T> query)
	{
		return query.Ask(this);
	}

	public void ActOn(IGridArea area, IGridCellAction action)
	{
		ActOn(new ClearPreviewAction());

		if (area.CanApply(this, action))
		{
			area.ApplyTo(this , action);
		}
		else
		{
			GD.Print("[Board] 설치 불가");
		}
	}
}