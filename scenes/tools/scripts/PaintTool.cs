using Godot;
using System;
using Game.Enums;
public partial class PaintTool : Node, IToolComponent
{
	public ToolType TypeId => ToolType.Paint;
	
	[Export] public DeployComponent deployer;

	public void Activate()
	{
		GD.Print("Paint Tool Activated");
	}

	public void Deactivate()
	{
		ItemPreviewCursor.Instance.Reset();
	}
	
	public void UseTool(Resource item, Vector2I cellPos)
	{
		if(deployer != null)
		{
			deployer.TryDeploy(item, cellPos);
		}
		else
		{
			GD.PrintErr("PaintTool: DeployComponent를 찾을 수 없습니다.");
		}
	}

}
