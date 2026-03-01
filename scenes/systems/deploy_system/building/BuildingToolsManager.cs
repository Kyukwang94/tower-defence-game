using Godot;
using System.Collections.Generic;
using Game.Enums;

//TODO : <<Elegant Objects>>책 방식으로 Refactoring 해보기.
public partial class BuildingToolsManager : Node2D
{	
	//자체판단으로 맡겨야함.
	[Export] private TileMapLayer _gridLayer;

	[Signal] public delegate void ActiveItemChangedEventHandler(Texture2D icon);
	[Signal] public delegate void CursorPreviewRequestedEventHandler(Texture2D icon);
	

	private readonly Dictionary<ToolType, IToolBox> _tools = [];
	private IToolBox _currentToolBox;
	private IPlaceable _currentItem;

	private bool     _isDragging;
    private Vector2I _dragStartCell;
    private Vector2I _dragEndCell;

	[Export] LayerRegistry registry;
	private ILayerProvider _worldLayers;
	public override void _Ready()
	{ 
		foreach (Node child in GetChildren())
		{
			if (child is IToolBox tool)
			{
				RegisterTool(tool);
			}
		}

		_worldLayers = registry.CreateProvider();
	}
	
	public override void _UnhandledInput(InputEvent @event)
	{
		if(_currentToolBox == null || _currentItem == null) return;

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
				
				IGridCellAction tool = _currentToolBox.MakeAction(_currentItem, _worldLayers);
				IGridCellAction safeAction = _currentItem.Validated(tool, _worldLayers, false);
				IGridSelection  selection = new GridSelection(new GridRectangleArea(_dragStartCell, _dragEndCell));
				selection.ApplyTo(safeAction);
				GetViewport().SetInputAsHandled();
				return;
            }
        }

    	// 드래그 중 현재 끝점 갱신
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
// 이거 고쳐야함.
	public void ActivateTool(ToolType type)
	{	
		if(_tools.TryGetValue(type, out var newTool))
		{
			if(_currentToolBox != null && _currentToolBox != newTool)
			{
				_currentToolBox.Deactivate();
			}
			
			_currentToolBox = newTool;
			_currentToolBox.Activate();
		}
		else
		{
			CancelTool();
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
		_currentToolBox?.Deactivate();
		_currentToolBox = null;

		EmitSignal(SignalName.ActiveItemChanged, (Texture2D)null);
	
		GD.Print("Tool Canceled");
	}
	
	//currentItem 할당
	public void LoadItem(Resource item)
	{
		if(item is not IPlaceable placeableItem) return;
		_currentItem = placeableItem;
		
		if(placeableItem is IResourceItem toolableItem)
		{
			GD.Print($"Selected Item : {toolableItem.ItemName} - Switching to {toolableItem.TargetToolType}");	
			ActivateTool(toolableItem.TargetToolType);	
		}
		else
		{
			GD.PushWarning($"Manager: Resource '{item.ResourceName}' does not implement IResourceItem. Cannot determine tool type.");
            // 기본값으로 설정하거나 리턴
            CancelTool();
		}
	}

	private void RegisterTool(IToolBox tool)
	{
		_tools[tool.TypeId] = tool;

		if(tool is ICursorChangingTool cursorTool)
		{
			cursorTool.OnCursorChangeRequested += (texture) =>
			{
				EmitSignal(SignalName.CursorPreviewRequested, texture);
			};
		}

		GD.Print($"DevTool Registered: {tool.TypeId}");
	}
}
