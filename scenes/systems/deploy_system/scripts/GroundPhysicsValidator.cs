using Godot;
using System;

[GlobalClass]
public partial class GroundPhysicsValidator : DeploymentValidator
{
	public override bool CheckValidation(Resource item , Vector2I pos)
	{
		if(item is not GroundResource selectedGroundTile) return true;
		
		TileMapLayer targetLayer = WorldManager.Instance.GetTileMapLayer(selectedGroundTile.TargetLayer);
		
		//땅이있는지 체크
		if(targetLayer.GetCellSourceId(pos) == -1 )
		{
			GD.Print($"{targetLayer.Name},{pos},{targetLayer.GetCellSourceId(pos)}");
			GD.Print("Ground Is Not Valid");
			return false;
		}
		//땅이 있다면 클릭된 곳의 땅tile정보 가져오기 
		GroundResource deployedGroundTile = WorldManager.Instance.GetGroundManager().GetGroundResourceAt(pos,targetLayer);
		if(deployedGroundTile == null)
			GD.PushError("deployedGroundTile을 찾지 못했습니다.");
		
		//중복체크
		if( deployedGroundTile.Name == selectedGroundTile.Name)
		{
			GD.Print("동일한 타일이 설치되어있습니다.");
			return false;
		}

		return true;
	}
}
