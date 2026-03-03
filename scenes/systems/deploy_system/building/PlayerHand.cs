using Godot;
using System.Collections.Generic;
using Game.Enums;

//TODO : naming 바꾸기.
public partial class PlayerHand : Node2D
{	
	//자체판단으로 맡겨야함.
	[Export] private TileMapLayer _gridLayer;

	[Signal] public delegate void ActiveItemChangedEventHandler(Texture2D icon);
	[Signal] public delegate void CursorPreviewRequestedEventHandler(Texture2D icon);
	
	private IPlaceable _itemInHand;

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
				_dragEndCell = GetMouseCell();
				
				IGridSelection  selection = new GridSelection(new GridRectangleArea(_dragStartCell, _dragEndCell));				
				IGridCellAction placementAction   = _itemInHand.PlacementAction(_worldLayers, false);
				selection.ApplyTo(placementAction);

				GetViewport().SetInputAsHandled();
				return;
            }
        }

        if (@event is InputEventMouseMotion && _isDragging)
        {
            _dragEndCell = GetMouseCell();
            GetViewport().SetInputAsHandled();
            return;
        }

        // 취소
        if (@event.IsActionPressed("cancel"))
        {
            _isDragging = false;
            CancelTool();
            GetViewport().SetInputAsHandled();
        }
	}

	private Vector2I GetMouseCell()
	{
		Vector2 mouseWorld = GetGlobalMousePosition();
		Vector2 mouseLocal = _gridLayer.ToLocal(mouseWorld);
		
		return _gridLayer.LocalToMap(mouseLocal);
	}
	
	private void CancelTool()
	{
		GD.Print("Tool Canceled");
	}
	
	// 이부분 리팩토링
	public void Grasp(IPlaceable item)
	{
		_itemInHand = item;
	}
}
