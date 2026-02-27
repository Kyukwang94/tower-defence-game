using Godot;
using System;
using Game.Enums;
public interface IDeploymentStrategy 
{	
	Type TargetStrategyType { get; }
	bool CheckValidation(Resource item, Vector2I cellPos);
	void Deploy(Resource item, Vector2I cellPos);
}
