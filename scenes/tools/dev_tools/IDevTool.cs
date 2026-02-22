using Godot;
using System;

public partial interface IToolComponent
{
	BuildingToolsManager.ToolType TypeId {get;}


	void UseTool(Resource item, Vector2 globalPosition);
	void Activate();
	void Deactivate();
}
