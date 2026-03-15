using Godot;
using Game.Enums;


[GlobalClass]
public partial class GameLibrary : Resource 
{
	[Export] private GroundSection   _groundSection;
	[Export] private BuildingSection _buildingSection;

	public void Guide(ItemType type, IGallery visitor)
	{
		if(type == ItemType.Ground)   _groundSection.Accept(visitor);		
		if(type == ItemType.Building) _buildingSection.Accept(visitor);

	}
}
