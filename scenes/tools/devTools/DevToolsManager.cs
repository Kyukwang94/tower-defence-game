using Godot;
using System;


public partial class DevToolsManager : Node
{
	public enum ToolType {Paint , Erase}

	[Export] public Node PaintComponentNode;
	[Export] public Node EraseComponentNode;

	private IDevToolComponent _currentTool;
	public override void _Ready()
	{

	}

	public void ChangeTool(ToolType type)
	{
		switch (type)
		{
			case ToolType.Paint:
				if(PaintComponentNode is IDevToolComponent p) _currentTool = p;
				break;
			case ToolType.Erase:
				if(EraseComponentNode is IDevToolComponent e) _currentTool = e;
				break;
		}
		GD.Print($"Current Tool: {type}");
	}
}
