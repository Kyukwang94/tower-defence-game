
using Godot;

[GlobalClass]
public partial class NoDemolitionResource : Resource, IDemolitionPolicy
{
	public bool CanDemolish()
	{
		return false;
	}

	public void Execute(BuildingNode node)
	{
		
	}
}