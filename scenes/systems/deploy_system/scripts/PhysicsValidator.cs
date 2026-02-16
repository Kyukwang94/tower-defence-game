using Godot;
using System;

[GlobalClass]
public partial class PhysicsValidator : DeploymentValidator
{
	public override bool CheckValidation(Resource item , Vector2I pos)
	{
		//item의 Target Layer Tileenttiy 중복으로 설치되지 않아야함.
		if(item is not TileEntityResource tileItemRes) return false;

		TileMapLayer targetLayer = WorldManager.Instance.GetTileMapLayer(tileItemRes.TargetLayer);
		//1,1곳에 어떤게 있느냐를 체크해야함. 음 .. 이걸 추후에 관리할때 어떻게 해야할지 ;; 
		
		return true;
	}

}
