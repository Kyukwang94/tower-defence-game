using Godot;
using System;
using System.Collections.Generic;

//Handle User Input and routes it to the active tool 
public partial class BuildingToolsManager : Node2D
{	
	[Signal] public delegate void ActiveItemChangedEventHandler(Texture2D icon);
	[Signal] public delegate void CursorPreviewRequestedEventHandler(Texture2D icon);
	public enum ToolType {Paint , Erase}

	private Dictionary<ToolType, IToolComponent> _tools = [];

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
	
	//Query
	//itemsContainerUI.OnItemSelected
	public void LoadItem(Resource item)
	{
		_currentItem = item;
		GD.Print($"Selected Item : {GetItemName(item)} - ready to paint");

		ActivateTool(ToolType.Paint);	
	}
	//Query
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

	//helper
	private string GetItemName (Resource item)
	{
		if(item is IResourceItem resourceItem)
		{
			return resourceItem.ItemName;
		}

		GD.PushWarning("DevTools: Resource does not implement IResourceItem. Cannot retrieve name.");	
		return "Unknown";
	}
}
