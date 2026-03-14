using Godot;
using Game.Placement.NullObject;

public partial class PlayerHand : Node2D
{	
	[Export] private Board _board;
	
	private IHandItem _itemInHand = NoPlaceable.Instance;
	
	[Export] private HandCursor _handCursor;

	private bool     _isDragging;
    private Vector2I _dragStartCell;
    private Vector2I _dragEndCell;

	

	public override void _UnhandledInput(InputEvent @event)
	{			
		if 		(@event is InputEventMouseButton mb && mb.ButtonIndex == MouseButton.Left)
			HandleMouseLeftButton(mb);
		else if (@event is InputEventMouseMotion mouseMotion)
			HandleMouseMotion();
        else if (@event.IsActionPressed("cancel"))
        	ClearHand();
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
			_dragEndCell = CurrentMouseCell();

			IGridArea gridArea = _itemInHand.Area(_dragStartCell, _dragEndCell);
			
			_board.ActOn(_itemInHand, gridArea);

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

			UpdatePreview();

            GetViewport().SetInputAsHandled();
            return;
        }
	}
	private void UpdatePreview()
	{
		IGridArea area = _itemInHand.Area(_dragStartCell, _dragEndCell);    
		_board.PreviewOn(_itemInHand, area);
	}
	
	private Vector2I CurrentMouseCell()
	{	
		return _board.WorldToCell(GetGlobalMousePosition());
	}
	
	private void ClearHand()
	{
		_isDragging = false;

		_board.PreviewOff();
		
		_itemInHand = NoPlaceable.Instance; 		
		_itemInHand.CursorDesign().Apply(_handCursor);
		
		GetViewport().SetInputAsHandled();

		GD.Print("PlayerHand Released");
	}
	
	public void Grasp(IHandItem item)
	{
		GD.Print($"[PlayerHand (Grasp)]{_itemInHand.GetType().Name}");
		_itemInHand = item;			
		var design = _itemInHand.CursorDesign();
    	GD.Print($"[Debug] 디자인 객체 타입: {design.GetType().Name}");
		design.Apply(_handCursor);
		
		// _itemInHand.CursorDesign().Apply(_handCursor);
	}
}
