using System;
public interface IDemolishable
{
	void Demolish(Action<Address> DemolishAction);
	bool CanDemolish();	
	Address Address { get; }
}
