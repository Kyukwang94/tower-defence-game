using Godot;
using Game.Enums;

public class TileDeploymentStrategy : IDeploymentStrategy
{
	public void Deploy (DeployComponent runner, Resource item, Vector2I clickedCellPos)
	{	
		if(item is not TileResource tileItemRes) return;
			
		runner.GroundLayer.SetCell(
			clickedCellPos,
			tileItemRes.SourceId,
			tileItemRes.AtlasCoords,
			tileItemRes.AlternativeTileId
		);

		GD.Print($"{tileItemRes.Type} Deployed");
	}

	public bool IsValidPosition(DeployComponent runner , Resource item, Vector2I curCellPos)
	{
		if(item is not TileResource tileItemRes) return false;
		var layer = runner.GroundLayer;
		if(layer == null) return false;

		if(layer.GetCellSourceId(curCellPos) == -1)  return false;

		TileResource clickedFloorTile = MapManager.Instance.GetTileResourceAt(curCellPos, layer);
		DeployableFlags floorTileFlag = DeploymentUtils.ConvertTypeToFlag(clickedFloorTile.Type);

		//내가 선택한 TileItem의 CanDeployOnBigFlags에 클릭한Tile이 포함되느냐를 판별
		 return (tileItemRes.CanDeployOn & floorTileFlag) != 0;
	}
}
