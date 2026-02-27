using Godot;
using System.Collections.Generic;
using Game.Enums;

//아이템이 선택되었을때 선택된 아이템을 저장 및 현재 선택된 아이템의 Tool 사용.
public partial class BuildingToolsManager : Node2D
{	
	[Signal] public delegate void ActiveItemChangedEventHandler(Texture2D icon);
	[Signal] public delegate void CursorPreviewRequestedEventHandler(Texture2D icon);
	

	private readonly Dictionary<ToolType, IToolComponent> _tools = [];

	private IToolComponent _currentTool;
	private Resource _currentItem;

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
		if(_currentTool == null) return;
		
		if (@event.IsActionPressed("click"))
		{
			_currentTool.UseTool(_currentItem,GetGlobalMousePosition());
			GetViewport().SetInputAsHandled();
		}

		if (@event.IsActionPressed("cancel"))
		{
			CancelTool();
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
