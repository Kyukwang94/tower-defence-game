using Godot;
using System;

public interface IDeploymentStrategy 
{	
	bool IsValidPosition( DeployComponent runner, Resource item, Vector2I curCellPos );
	void Deploy(DeployComponent runner , Resource item, Vector2I clickedCellPos);
}
