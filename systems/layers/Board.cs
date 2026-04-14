using Godot;
public partial class Board : Node, IBoard
{

	[Export] private TileMapLayer _groundLayer;
	[Export] private TileMapLayer _buildingLayer;
	[Export] private TileMapLayer _prevLayer;
	[Export] private TileMapLayer _interactionLayer;
	[Export] private TileMapLayer _occupancyLayer;
	

	private LayerBag _layerBag;
	private OccupancyLedger _occupancyLedger;
	private BoardEnvironment _boardEnv;
	public BoardEnvironment BoardEnv => _boardEnv;


	public override void _Ready()
	{
		_layerBag = new LayerBag(_groundLayer, _occupancyLayer, _buildingLayer, _prevLayer, _interactionLayer);
		_occupancyLedger = new OccupancyLedger(_layerBag.Occupancy);
		_boardEnv = new(_occupancyLedger, _layerBag);
		_boardEnv.ActOn(new SyncEditorBuildingsAction());

		_occupancyLayer.Hide();
	}
}
