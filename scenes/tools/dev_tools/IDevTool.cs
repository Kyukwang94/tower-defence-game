using Godot;
using System;

public partial interface IDevToolComponent
{
	DevToolsManager.ToolType TypeId {get;}


	void UseTool(Resource item, Vector2 globalPosition);
	void Activate();
	void Deactivate();
}
