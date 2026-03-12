using Godot;
using Game.Placement.Core.Area;
using Game.Placement.NullObject;

public partial class PlayerHand : Node2D
{	
	//자체판단으로 맡겨야함.
	[Export] private TileMapLayer _groundLayer;
	[Export] private TileMapLayer _placementPreviewLayer;
	
	private IHandItem _itemInHand = NoPlaceable.Instance;
	
	[Export] private HandCursor _handCursor;

	private bool     _isDragging;
    private Vector2I _dragStartCell;
    private Vector2I _dragEndCell;

	[Export] private Stage _stage;
	private ILayerProvider _worldLayers;

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
		_dragStartCell = CurrentMouseCell();
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
			_dragEndCell = CurrentMouseCell();

			IGridArea gridArea = _itemInHand.Area(_dragStartCell, _dragEndCell);
			IGridCellAction placementAction = _itemInHand.PlacementAction();
			
			_stage.ActOn(_itemInHand.Type, gridArea, placementAction);

			GetViewport().SetInputAsHandled();
			return;
		}
	}

	private void HandleMouseMotion()
	{			
		if (!_isDragging )
		{
			_dragEndCell = CurrentMouseCell();
			_dragStartCell = _dragEndCell;

			UpdatePreview();
		}
		else if (_isDragging)
        { 
            _dragEndCell = CurrentMouseCell();

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

		IGridCellAction action = _itemInHand.PreviewAction();

		//Prev전용으로바꾸기
		_stage.PreviewOn(area, action);
	}
	private Vector2I CurrentMouseCell()
	{
		Vector2 mouseWorld = GetGlobalMousePosition();
		Vector2 mouseLocal = _groundLayer.ToLocal(mouseWorld);
		
		return _groundLayer.LocalToMap(mouseLocal);
	}
	
	private void Release()
	{
		_isDragging = false;
		_placementPreviewLayer.Clear();
		
		_itemInHand = NoPlaceable.Instance; 		
		
		_itemInHand.CursorDesign().Apply(_handCursor);
		
		GetViewport().SetInputAsHandled();
		GD.Print("PlayerHand Released");
	}
	
	public void Grasp(IHandItem item)
	{
		_itemInHand = item;	
		
		_itemInHand.CursorDesign().Apply(_handCursor);

	}
}
