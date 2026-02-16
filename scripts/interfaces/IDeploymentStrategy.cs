using Godot;
using System;

public interface IDeploymentStrategy 
{	
	bool CheckValidation(Resource item, Vector2 clickedCellPos);
	void Deploy(Resource item, Vector2 clickedCellPos);
}
