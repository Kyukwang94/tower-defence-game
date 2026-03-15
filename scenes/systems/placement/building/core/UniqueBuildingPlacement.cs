using Godot;
using System;

public sealed class UniqueBuildingPlacement : IGridCellAction
{

	public UniqueBuildingPlacement(IGridCellAction origin)
	{
		
	}
	public void OnCell(Godot.TileMapLayer layer, Vector2I cell)
	{
		//	BuildingLayer 좌표관리에 빌딩이 설치되어있다고 설정해야함
		// 	설치.
		
	}

	public bool TryOnCell(Godot.TileMapLayer layer, Vector2I cell)
	{
		//	해당 cell에  FoundationTile말고 설치되어있는게 없어야함.
		//	
		return true;
	}

}
