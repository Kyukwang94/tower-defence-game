using Godot;
using System;

public partial class ToolUseAction : IGridCellAction
{
	private readonly IToolComponent _tool;
	private readonly Resource 		_item;
	
	public ToolUseAction(IToolComponent tool, Resource item)
	{
		_tool = tool;
		_item = item;
	}
	
	public void OnCell(Vector2I cell)
	{
		_tool.UseTool(_item, cell);
	}

}
