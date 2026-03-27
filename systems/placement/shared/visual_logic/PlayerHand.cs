using Godot;
using Game.Placement.NullObject;

public partial class PlayerHand : Node2D
{
	[Export] private Board _board;

	private IHandTool _itemInHand = NoHandItem.Instance;

	[Export] private HandCursor _handCursor;

	private bool _isDragging;
	private Vector2I _dragStartCell;
	private Vector2I _dragEndCell;

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventMouseButton mb && mb.ButtonIndex == MouseButton.Left)
			HandleMouseLeftButton(mb);
		else if (@event is InputEventMouseMotion mouseMotion)
			HandleMouseMotion();
		else if (@event.IsActionPressed("cancel"))
			ClearHand();
	}

	private void HandleMouseLeftButton(InputEventMouseButton mb)
	{
		if (mb.Pressed) StartDragging();
		else EndDragging();

		GetViewport().SetInputAsHandled();
	}
	private void StartDragging()
	{
		_isDragging = true;

		_dragStartCell = CurrentMouseCell();
		_dragEndCell   = _dragStartCell;

		GetViewport().SetInputAsHandled();
		return;
	}
	private void EndDragging()
	{
		if (_isDragging)
		{
			_isDragging = false;
			_dragEndCell = CurrentMouseCell();

			_itemInHand.Act(_board, _dragStartCell, _dragEndCell);

			GetViewport().SetInputAsHandled();
			return;
		}
	}

	private void HandleMouseMotion()
	{
		if (!_isDragging)
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
		_itemInHand.ActPrev(_board, _dragStartCell, _dragEndCell);
	}

	private Vector2I CurrentMouseCell()
	{
		return _board.WorldToCell(GetGlobalMousePosition());
	}

	private void ClearHand()
	{
		_isDragging = false;

		_board.PreviewOff();

		_itemInHand = NoHandItem.Instance;
		_itemInHand.CursorDesign().Apply(_handCursor);

		GetViewport().SetInputAsHandled();

		GD.Print("PlayerHand Released");
	}

	public void Grasp(IHandTool item)
	{
		_itemInHand = item;
		ICursorDesign design = _itemInHand.CursorDesign();
		design.Apply(_handCursor);
	}
}
