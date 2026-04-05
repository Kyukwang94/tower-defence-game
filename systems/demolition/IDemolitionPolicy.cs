public interface IDemolitionPolicy
{
	bool CanDemolish();
	void Execute(BuildingNode node);
}	
