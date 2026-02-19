using Godot;
using System;
using Game.Enums;

[GlobalClass]
public partial class GroundPropertyValidator : DeploymentValidator
{
	public override bool CheckValidation(Resource item, Vector2I pos)
	{

		if (item is not GroundResource selectedItem) return true;
	
		TileMapLayer targetLayer = WorldManager.Instance.GetTileMapLayer(selectedItem.TargetLayer);
		if(targetLayer.GetCellSourceId(pos) == -1 ) return false;
		
		GroundResource deployedTile = WorldManager.Instance.GetGroundManager().GetGroundResourceAt(pos, targetLayer);
		if(deployedTile == null) return false;

		if (selectedItem.RequiredProperties == GroundProperties.None) return true;

		bool hasRequirement = (deployedTile.Properties & selectedItem.RequiredProperties) == selectedItem.RequiredProperties;
		if(!hasRequirement) return false;
		
		return true;
		
	}
}
