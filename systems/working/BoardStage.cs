using Game.Enums;
using Godot;
// public interface IBoardCommand : IPlacementSystem, IBoardEnvironment, IOccupancy, IPreivewSystem, IPaintSystem { }
public sealed class BoardEnvironment : IBoardEnvironment,IPlacementSystem,IOccupancy,IPreivewSystem,IPaintSystem
{
	private readonly OccupancyLedger _occupancyLedger;
	private readonly ILayerProvider _layerProvider;	

	public BoardEnvironment(OccupancyLedger occupancyLedger, ILayerProvider layerProvider)
	{
		_occupancyLedger = occupancyLedger;
		_layerProvider = layerProvider;
	}
	public void ActOn(IBoardAction action)
	{
		action.Execute(this);
	}
	public T Ask<T>(ILayerQuery<T> query)
	{
		return query.Execute(_layerProvider);
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

	//Placement
	public void InstallBuilding(BuildingNode node, Vector2I cell) => new BuildingInstallation(_layerProvider, _occupancyLedger, node, node.Resource, cell).Install();
	public void DemolishBuilding(Vector2I cell) => new BuildingDemolition(this, _occupancyLedger, cell).Demolish();
	
	
	//Ground
	public void PaintTile(Vector2I cell, int sourceId, Vector2I coords) => new PaintTileInstallation(cell, sourceId, coords).Paint(_layerProvider);
	
	//Occupancy 
	public void MarkCell(Vector2I cell, OccupancyType myType) => _occupancyLedger.MarkCell(cell, myType);
	public void MarkShape(Address address, OccupancyType myType) => _occupancyLedger.MarkShape(address, myType);
	public void RegisterOccupant(BuildingNode node, BuildingResource res, Vector2I cell) => _occupancyLedger.RegisterOccupant(node, res, cell);
	public void UnRegisterOccupant(Address address) => _occupancyLedger.UnRegisterOccupant(address);
	public void ClearOccupancy() => _occupancyLedger.Clear();
	public void SyncOccupancyBuilding()	 => new OccupancySync(this, _layerProvider).Sync();
	
	//Preview
	public void ClearPreview() => _layerProvider.Preview.Clear();
	public void PaintPreviewTile(Vector2I cell, int sourceId, Vector2I coords) => new PrevTileInstallation(cell, sourceId, coords).Paint(_layerProvider);
	public void ShowPreviewForDemolishBuilding(Vector2I cell) => new DemolitionPreview(this, _occupancyLedger, _layerProvider, cell).Show();
}