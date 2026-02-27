using Godot;
using System;
using Game.Enums;
public partial interface IToolComponent
{
	ToolType TypeId {get;}

	void UseTool(Resource item, Vector2I globalPosition);
	void Activate();
	void Deactivate();
}
