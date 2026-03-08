using Godot;
using Game.Enums;


[GlobalClass]
public partial class GameLibrary : Resource 
{
	[Export] private GroundSection _groundSection;

	public void Guide(ItemType type, IGallery visitor)
	{
		if(type == ItemType.Ground)
		{
			_groundSection.Accept(visitor);
		}
	}
}
