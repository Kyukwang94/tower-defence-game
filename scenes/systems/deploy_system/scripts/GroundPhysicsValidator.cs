using Godot;
using System;

[GlobalClass]
public partial class GroundPhysicsValidator : DeploymentValidator
{
	public override bool CheckValidation(Resource item , Vector2I pos)
	{
		if(item is not GroundResource selectedGroundTile) return true;
		
		TileMapLayer targetLayer = WorldManager.Instance.GetTileMapLayer(selectedGroundTile.TargetLayer);
		
		GroundResource deployedGroundTile = WorldManager.Instance.GetGroundManager().GetGroundResourceAt(pos,targetLayer);
		if(deployedGroundTile == null)
		{
			GD.PushError("deployedGroundTile을 찾지 못했습니다.");
		}

		if(targetLayer.GetCellSourceId(pos) == -1 )
		{
			GD.Print("Ground Is Not Valid");
			return false;
		}
		if( deployedGroundTile.Name == selectedGroundTile.Name)
		{
			GD.Print("동일한 타일이 설치되어있습니다.");
			return false;
		}

		return true;
	}
}
