using Godot;
using Game.Enums;



[GlobalClass]
public partial class GroundResource : TileEntityResource , IPlaceable
{
	[ExportGroup("Ground Info")]
	[Export] public GroundProperties Properties {get; set;}
	[Export] public GroundElement 	 Element{get; set;}

	
	[ExportGroup("Deploy Rule")]
	[Export] public GroundProperties RequiredProperties{get; set;}	
	public int deployArea = 1;


	public IGridCellAction Validated(IGridCellAction origin, ILayerProvider mapProvider, bool isDevmode)
	{
		TileMapLayer mapLayer = mapProvider.GetLayer(this.TargetLayer);
		IGridCellAction safeAction = origin;

		if (isDevmode)
		{
			safeAction = new Vacancy(origin , mapLayer);
		}
		else
		{
			//TODO : 조건들 추가.
			safeAction = new Vacancy(origin , mapLayer);
		}

		return safeAction;
	}

	public void BuildOn(ILayerProvider mapProvider, Vector2I cell)
	{
		TileMapLayer myLayer = mapProvider.GetLayer(this.TargetLayer);

		int mySourceId = this.SourceId;
		Vector2I myCoords = this.AtlasCoords;

		GD.Print($"[BuildOn] 칠하기 시도! ➡️ 좌표: {cell}, SourceID: {mySourceId}, Coords: {myCoords}");

		myLayer.SetCell(cell, mySourceId, myCoords);
	}


	

}