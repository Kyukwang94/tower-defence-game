using Godot;
using System.Collections.Generic;
using System;
public interface IDemolishable
{
	void Demolish(Action<Address, IEnumerable<Vector2I>> DemolishAction);
	bool CanDemolish();
	Address Address { get; }
}
