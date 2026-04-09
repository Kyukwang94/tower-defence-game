using Game.Enums;
using Godot;

public sealed class OccupancyRegister : IOccupancyAction
{
	public LayerType TargetLayer => LayerType.Occupancy;

	private readonly BuildingNode _node;
	private readonly BuildingResource _resource;
	private readonly Vector2I _cell;
	public OccupancyRegister(BuildingNode node, BuildingResource resource,Vector2I cell )
	{
		_node = node;
		_resource = resource;
		_cell = cell;
	}
	public void Execute(OccupancyLedger ledger)
	{
		ledger.RegisterOccupant(_node, _resource, _cell);
	}
}