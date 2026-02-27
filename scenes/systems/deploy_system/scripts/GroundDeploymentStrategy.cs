using System;
using Godot;
using Godot.Collections;


[GlobalClass]
public partial class GroundDeploymentStrategy : Resource , IDeploymentStrategy
{
	
	[Export] public Array<DeploymentValidator> Validators_DEV {get; set;}
	[Export] public Array<DeploymentValidator> Validators {get; set;}

	public Type TargetStrategyType => typeof(GroundResource);


	public void Deploy (Resource item,Vector2I cellPos)
	{	
		if(item is not GroundResource tileItemRes) return;
	
		TileMapLayer targetLayer = WorldManager.Instance.GetTileMapLayer(tileItemRes.TargetLayer);
		
		targetLayer.SetCell(
			cellPos,
			tileItemRes.SourceId, 
			tileItemRes.AtlasCoords,
			tileItemRes.AlternativeTileId
		);

		GD.Print($"{tileItemRes.Name} Deployed");
	}

	public bool CheckValidation(Resource item , Vector2I cellPos)
	{
		if(item is not GroundResource tileItemRes) return false;

		
		TileMapLayer targetLayer = WorldManager.Instance.GetTileMapLayer(tileItemRes.TargetLayer);		
		int sourceId = targetLayer.GetCellSourceId(cellPos);
    	GD.Print($"[GroundValidator] layer={targetLayer.Name}, pos={cellPos}, sourceId={sourceId}");

		bool isDevMode = GameModeManager.Instance.IsDevMode;
		var currentValidator = isDevMode ? Validators_DEV : Validators;

		foreach(var validator in currentValidator)
		{
			bool result = validator.CheckValidation(item, cellPos);

			if(!result )
				return false;
		}

		return true;	
	}
}
