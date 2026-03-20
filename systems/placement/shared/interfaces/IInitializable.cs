using Godot;
using System;

public interface IInitializable
{
	//Runtime
	void Initialize(Address address, BuildingResource resource, LayerBag layerBag);
	//Editor
	void Initialize(LayerBag layerBag);
}
