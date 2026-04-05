using Godot;

[GlobalClass]
public partial class StandardDemolitionResource : Resource, IDemolitionPolicy
{
	public bool CanDemolish()
	{
		return true;
	}

	public void Execute(BuildingNode node)
	{
		node.QueueFree();
	}
}