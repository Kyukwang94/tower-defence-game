using Godot;
using Godot.Collections;


[GlobalClass]
public partial class GroundDeploymentStrategy : Resource , IDeploymentStrategy
{
	[Export] public Array<DeploymentValidator> Validators {get; set;}

	public void Deploy (Resource item,Vector2 clickedCellPos)
	{	
		if(item is not GroundResource tileItemRes) return;
	
		TileMapLayer targetLayer = WorldManager.Instance.GetTileMapLayer(tileItemRes.TargetLayer);
		Vector2  localPos = targetLayer.ToLocal(clickedCellPos);
		Vector2I gridPos  = targetLayer.LocalToMap(localPos);
		
		targetLayer.SetCell(
			gridPos,
			tileItemRes.SourceId,
			tileItemRes.AtlasCoords,
			tileItemRes.AlternativeTileId
		);

		GD.Print($"{tileItemRes.Name} Deployed");
	}

	public bool CheckValidation()
	{
		foreach(var validator in Validators)
		{
			bool result = validator.CheckValidation();

			if(!result )
				return false;
		}

		return true;	
	}
}
