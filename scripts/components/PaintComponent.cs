using Godot;
using System;



public partial class PaintComponent : Node , IDevToolComponent
{
	public DevToolsManager.ToolType TypeId => DevToolsManager.ToolType.Paint;

	private TileMapLayer _groundLayer;

	public void Activate()
	{
		GD.Print("Current Tool: Paint Tool");
	}
	public void Deactivate()
	{
		ItemPreviewCursor.Instance.Reset();
	}
//??  : Unit Building등등 다른것들이 들어올텐데 각각의 검증방법이있을때는 PatternMatching 같은걸 쓸 수 있나 ?? ..
//MEMO : 음 ..  각각의 검증을 IDeployRule같은걸만들고 검증하게만들어야겠네 
//TODO IPaintable을 사용해서 PaintComponent의 UseTool의 PatternMatching 없애기
	public void UseTool(Resource item , Vector2 mouseGlobalPosition)
	{
		if(item is TileResource tileData)
		 	PaintTile(tileData,mouseGlobalPosition);

		//Unit
		//Building
		
		GD.Print($"Paint: {mouseGlobalPosition} Clicked");
	}


	public void PaintTile(TileResource tileData , Vector2 mouseGlobalPosition)
	{
		if(_groundLayer == null)
		{
			FindTargetLayer();
		}

		if(_groundLayer == null)
		{
			GD.PrintErr("Target Layer가 연결되지 않았습니다.");
			return;
		}

		Vector2 localPos = _groundLayer.ToLocal(mouseGlobalPosition);
        Vector2I gridCoord = _groundLayer.LocalToMap(localPos);
		
		_groundLayer.SetCell(
			gridCoord,
			tileData.SourceId,
			tileData.AtlasCoords,
			tileData.AlternativeTileId
		);
	}
	public void PaintUnit()
	{
		
	}
	public void PaintBuilding()
	{

	}
	//TODO : TileMapLayer도 System에서 찾아서 주입해주는 방식으로 바꿔야함.
	//MEMO : UseTool할때 FindTargetLayer Signal을 상위시스템에서 해주는게 좋은건가
	private void FindTargetLayer()
	{
		var foundNode = GetTree().GetFirstNodeInGroup("MapLayers");


		if (foundNode is IMapProvider mapProvider)
		{
			_groundLayer = mapProvider.GroundLayer;
			GD.Print("Map Provider 연결 성공");
		}
		else
		{
			GD.PrintErr("MapLayers 그룹에 있는 노드가 IMapProvider를 구현하지 않았습니다");
		}
	}
}

