using Godot;
using System.Collections.Generic;
using Game.Enums;

//TODO : <<Elegant Objects>>책 방식으로 Refactoring 해보기.
public partial class BuildingToolsManager : Node2D
{	

	[Export] private TileMapLayer _gridLayer;

	[Signal] public delegate void ActiveItemChangedEventHandler(Texture2D icon);
	[Signal] public delegate void CursorPreviewRequestedEventHandler(Texture2D icon);
	

	private readonly Dictionary<ToolType, IToolComponent> _tools = [];
	private IToolComponent _currentTool;
	private Resource _currentItem;

	private bool     _isDragging;
    private Vector2I _dragStartCell;
    private Vector2I _dragEndCell;

	public override void _Ready()
	{ 
		foreach (Node child in GetChildren())
		{
			if (child is IToolComponent tool)
			{
				RegisterTool(tool);
			}
		}
	}
	
	public override void _UnhandledInput(InputEvent @event)
	{
		if(_currentTool == null || _currentItem == null) return;

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

                IGridSelection selection = new GridSelection(_dragStartCell, _dragEndCell);
                UseSelection(selection);

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

	public void ActivateTool(ToolType type)
	{	
		if(_tools.TryGetValue(type, out var newTool))
		{
			if(_currentTool != null && _currentTool != newTool)
			{
				_currentTool.Deactivate();
			}
			
			_currentTool = newTool;
			_currentTool.Activate();
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
	private void UseSelection(IGridSelection selection)
	{
		foreach (var cell in selection.Cells())
		{
			_currentTool.UseTool(_currentItem, cell);
		}
	}
	private void CancelTool()
	{
		_currentTool?.Deactivate();
		_currentTool = null;

		EmitSignal(SignalName.ActiveItemChanged, (Texture2D)null);
	
		GD.Print("Tool Canceled");
	}
	
	//currentItem 할당
	public void LoadItem(Resource item)
	{
		_currentItem = item;
		
		if(item is IResourceItem toolableItem)
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

	private void RegisterTool(IToolComponent tool)
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
