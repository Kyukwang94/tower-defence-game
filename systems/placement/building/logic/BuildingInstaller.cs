using Godot;
public sealed class BuildingInstallation
{
    private readonly ILayerProvider _layers;
    private readonly OccupancyLedger _ledger;
    private readonly BuildingNode _node;
    private readonly BuildingResource _resource;
    private readonly Vector2I _cell;

    public BuildingInstallation(ILayerProvider layers, OccupancyLedger ledger, BuildingNode node, BuildingResource resource, Vector2I cell)
    {
        _layers = layers;
        _ledger = ledger;
        _node = node;	
        _resource = resource;
        _cell = cell;
    }

    public void Install()
    {
        // 1. 노드 배치 (View)
        if (_node.GetParent() == null) _layers.Building.AddChild(_node);

        Vector2 centerPos = _layers.Building.MapToLocal(_cell);
        Vector2 finalPos = centerPos - new Vector2(16, 16); // 오프셋 계산

        Address address = new(_cell, _resource.Shape.Duplicate());
        _node.Setup(address, _resource, finalPos);

        // 2. 점유 데이터 갱신 (Model/Logic)
        _ledger.MarkShape(_node.Address, _resource.MyType);
        _ledger.RegisterOccupant(_node, _resource, _cell);
    }
}