using Godot;
using System;

public interface IInitializable
{
	//Runtime
	void Finalize(Address address, BuildingResource resource,Vector2 pos);
	//Editor	
	void InitializeForEditor(Board board);
}
