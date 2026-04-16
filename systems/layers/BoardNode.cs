using Godot;
public partial class BoardNode : Node, IBoarNode
{
	[Export] private TileMapLayer _groundLayer;
	[Export] private TileMapLayer _buildingLayer;
	[Export] private TileMapLayer _prevLayer;
	[Export] private TileMapLayer _interactionLayer;
	[Export] private TileMapLayer _occupancyLayer;
	

	private LayerBag _layerBag;
	private OccupancyLedger _occupancyLedger;
	private Board _board;
	public Board Board => _board;


	public override void _Ready()
	{
		_layerBag = new LayerBag(_groundLayer, _occupancyLayer, _buildingLayer, _prevLayer, _interactionLayer);
		_occupancyLedger = new OccupancyLedger(_layerBag.Occupancy);
		_board = new(_occupancyLedger, _layerBag);
		new SyncEditorBuildingsAction().Execute(_board);

		_occupancyLayer.Hide();
	}
}
