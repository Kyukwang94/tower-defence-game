using Godot;
using System.Collections.Generic;

using Game.Placement.Core.Area;
using Game.Enums;

public partial class BuildingItem : IHandItem , IButtonInfo
{
	private readonly BuildingResource _buildingResource;

	public ItemType  Type => _buildingResource.Type;
	public Texture2D Icon => _buildingResource.Icon;
	public string    Label  =>  _buildingResource.Name;

	public BuildingItem(BuildingResource buildingResource)
	{
		_buildingResource = buildingResource;
	}

	public IGridArea Area(Vector2I start, Vector2I end)
	{
		return new ShapeArea(end, OccupiedOffsets());
	}

	public ICursorDesign CursorDesign()
	{
		return new PlayerHandDesign(_buildingResource.Icon);
	}

	public void DisplayOn(IGallery gallery)
	{
		gallery.Show(this);
	}
	
	//빌딩마다 다르기때문에 변경해야함.
	public IEnumerable<Vector2I> OccupiedOffsets()
	{
		yield return new Vector2I(0,0);
	}

	public IGridCellAction PlacementAction(LayerBag layerBag)
	{		
		IGridCellAction action = new BuildingSpawnAction(_buildingResource.scene);
						
						action = new OccupancyAction(
							action,
							layerBag.occupancy,
							_buildingResource.MyType,
							_buildingResource.ConflictsWith);
						
						action = new ExistingFoundationTile(layerBag.ground,action);

		return action;
	}

	public void Selected(PlayerHand hand)
	{
		hand.Grasp(this);
	}
}
