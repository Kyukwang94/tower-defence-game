using Godot;
using Game.Placement.Core.Area;

//REFACTORING : 더 간단하게 만들기
public partial class PlayerHand : Node2D
{	
	//자체판단으로 맡겨야함.
	[Export] private TileMapLayer _groundLayer;
	[Export] private TileMapLayer _placementPreviewLayer;
	
	private IPlaceable _itemInHand = NoPlaceable.Empty;
	
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
		if 		(@event is InputEventMouseButton mb && mb.ButtonIndex == MouseButton.Left)
			HandleMouseLeftButton(mb);
		else if (@event is InputEventMouseMotion mouseMotion)
			HandleMouseMotion();
        else if (@event.IsActionPressed("cancel"))
        	Release();
	}
	
	private void HandleMouseLeftButton(InputEventMouseButton mb)
	{
		if(mb.Pressed) StartDragging();
		else EndDragging();
		GetViewport().SetInputAsHandled();
	}
	private void StartDragging ()
	{
		_isDragging = true;
		_dragStartCell = GetMouseCell();
		_dragEndCell = _dragStartCell;
		
		GetViewport().SetInputAsHandled();
		return;
	}
	private void EndDragging()
	{
		if (_isDragging)
		{
			_isDragging = false;
			_placementPreviewLayer.Clear();
			_dragEndCell = GetMouseCell();

			IGridArea placementArea = _itemInHand.Area(_dragStartCell, _dragEndCell);
			IGridCellAction placementAction = _itemInHand.PlacementAction(_worldLayers);
			
			placementArea.ApplyTo(placementAction);

			GetViewport().SetInputAsHandled();
			return;
		}
	}
	private void HandleMouseMotion()
	{			
		if (!_isDragging )
		{
			_dragEndCell = GetMouseCell();
			_dragStartCell = _dragEndCell;

			UpdatePreview();
		}
		else if (_isDragging)
        { 
            _dragEndCell = GetMouseCell();

			_placementPreviewLayer.Clear();

			UpdatePreview();

            GetViewport().SetInputAsHandled();
            return;
        }
	}
	private void UpdatePreview()
	{
		_placementPreviewLayer.Clear();

		IGridArea area = _itemInHand.Area(_dragStartCell, _dragEndCell);

		var action = new PlacementPreviewAction(
			_itemInHand.PlacementAction(_worldLayers),
			_placementPreviewLayer
		);

		area.ApplyTo(action);
	}
	private Vector2I GetMouseCell()
	{
		Vector2 mouseWorld = GetGlobalMousePosition();
		Vector2 mouseLocal = _groundLayer.ToLocal(mouseWorld);
		
		return _groundLayer.LocalToMap(mouseLocal);
	}
	
	private void Release()
	{
		_isDragging = false;
		_placementPreviewLayer.Clear();
		_itemInHand = NoPlaceable.Empty;
		ICursorDesign cursorDesign = new DefaultPlayerHandDesign();
		_handCursor.ChangeDesign(cursorDesign);
		
		GetViewport().SetInputAsHandled();
		GD.Print("PlayerHand Released");
	}
	
	public void Grasp(IPlaceable item)
	{
		_itemInHand  = item;	
		
		ICursorDesign cursorDesign = item.CursorDesign();
		_handCursor.ChangeDesign(cursorDesign);
	}
}
