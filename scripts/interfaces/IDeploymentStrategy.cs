using Godot;
using System;

public interface IDeploymentStrategy 
{	
	bool CheckValidation();
	void Deploy(Resource item, Vector2 clickedCellPos);
}
