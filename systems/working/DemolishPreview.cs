using System.ComponentModel.Design.Serialization;
using Godot;

public sealed class DemolitionPreview
{
	private readonly OccupancyLedger _ledger;
	private readonly ILayerProvider _layerProvider; // 미리보기 전용 인터페이스
	private readonly Vector2I _cell;

	private readonly BoardEnvironment _boardEnv;

	public DemolitionPreview(BoardEnvironment boardEnv, OccupancyLedger ledger, ILayerProvider layerProvider, Vector2I cell)
	{
		_boardEnv = boardEnv;
		_ledger = ledger;
		_layerProvider = layerProvider;
		_cell = cell;
	}

	public void Show()
	{
		if (!_ledger.TryGetOccupant(_cell, out IDemolishable target)) return;

		Vector2I atlasCoords = target.CanDemolish() ? Vector2I.Zero : new Vector2I(1, 0);

		foreach (var occupantCell in target.Address.OccupiedCells)
		{
			_boardEnv.ActOn(new SetCellAtPrevAction(occupantCell, 1, atlasCoords));
		}
	}
}