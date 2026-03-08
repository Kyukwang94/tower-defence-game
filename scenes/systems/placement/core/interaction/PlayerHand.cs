using Godot;

public partial class PlayerHand : Node2D
{	
	//자체판단으로 맡겨야함.
	[Export] private TileMapLayer _groundLayer;
	[Export] private TileMapLayer _placementPreviewLayer;
	
	private IPlaceable   _itemInHand;
	[Export]private HandCursor _handCursor;

	private bool     _isDragging;
    private Vector2I _dragStartCell;
    private Vector2I _dragEndCell;

	[Export] LayerRegistry layerRegistry;
	private ILayerProvider _worldLayers;
	
	public override void _Ready()
	{ 
		_worldLayers = layerRegistry.CreateProvider();
	}
	
	public override void _UnhandledInput(InputEvent @event)
	{
		if(_itemInHand == null) return;
		if (@event is InputEventMouseButton mb && mb.ButtonIndex == MouseButton.Left)
        {
			if (mb.Pressed)
				{
				    _isDragging = true;
				    _dragStartCell = GetMouseCell();
				    _dragEndCell = _dragStartCell;
				    GetViewport().SetInputAsHandled();
				    return;
				}

            if (!mb.Pressed && _isDragging)
            {
				_isDragging = false;
				_placementPreviewLayer.Clear();

				_dragEndCell = GetMouseCell();
				IGridArea area = new GridArea(_dragStartCell, _dragEndCell);				
				IGridCellAction placementAction = _itemInHand.PlacementAction(_worldLayers, false);

				area.ApplyTo(placementAction);

				GetViewport().SetInputAsHandled();
				return;
            }
        }

        if (@event is InputEventMouseMotion && _isDragging)
        { 
            _dragEndCell = GetMouseCell();

			_placementPreviewLayer.Clear();

			IGridArea area = new GridArea(_dragStartCell , _dragEndCell);
			IGridCellAction placementAction = _itemInHand.PlacementAction(_worldLayers, false);
			IGridCellAction previewAction = new PlacementPreviewAction(placementAction, _placementPreviewLayer);

	        area.ApplyTo(previewAction);

            GetViewport().SetInputAsHandled();
            return;
        }

        // 취소
        if (@event.IsActionPressed("cancel"))
        {
            _isDragging = false;
			_placementPreviewLayer.Clear();
            CancelTool();
            GetViewport().SetInputAsHandled();
        }
	}

	private Vector2I GetMouseCell()
	{
	Vector2 mouseWorld = GetGlobalMousePosition();
		Vector2 mouseLocal = _groundLayer.ToLocal(mouseWorld);
		
		return _groundLayer.LocalToMap(mouseLocal);
	}
	
	private void CancelTool()
	{
		GD.Print("Tool Canceled");
	}
	
	
	public void Grasp(IPlaceable item)
	{
		_itemInHand  = item;	
		
		ICursorDesign design = item.CursorDesign();
		_handCursor.ChangeDesign(design);

	}
}
