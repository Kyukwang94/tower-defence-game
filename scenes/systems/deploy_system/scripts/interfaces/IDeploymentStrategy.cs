using Godot;
using System;
using Game.Enums;
public interface IDeploymentStrategy 
{	
	Type TargetStrategyType { get; }
	bool CheckValidation(Resource item, Vector2 clickedCellPos);
	void Deploy(Resource item, Vector2 clickedCellPos);
}
