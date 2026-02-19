using Godot;
using Godot.Collections;


[GlobalClass]
public partial class GroundDeploymentStrategy : Resource , IDeploymentStrategy
{
	[Export] public Array<DeploymentValidator> Validators_DEV {get; set;}
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

	public bool CheckValidation(Resource item , Vector2 clickedCellPos)
	{
		
		if(item is not GroundResource tileItemRes) return false;

		TileMapLayer targetLayer = WorldManager.Instance.GetTileMapLayer(tileItemRes.TargetLayer);
		Vector2  localPos = targetLayer.ToLocal(clickedCellPos);
		Vector2I gridPos  = targetLayer.LocalToMap(localPos);

		bool isDevMode = GameModeManager.Instance.IsDevMode;
		var currentValidator = isDevMode ? Validators_DEV : Validators;

		foreach(var validator in currentValidator)
		{
			bool result = validator.CheckValidation(item, gridPos);

			if(!result )
				return false;
		}

		return true;	
	}
}
