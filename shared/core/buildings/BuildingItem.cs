using Godot;
using System.Collections.Generic;

using Game.Placement.Core.Area;
using Game.Enums;

public partial class BuildingItem : IHandItem , IButtonInfo
{
	private readonly BuildingResource _resource;

	public ItemType  Type => 	_resource.Type;
	public Texture2D Icon => 	_resource.Icon;
	public string    Label  =>  _resource.Name;

	public BuildingItem(BuildingResource resource)
	{
		_resource = resource;
	}

	public IGridArea Area(Vector2I start, Vector2I end)
	{
		return new ShapeArea(end, OccupiedOffsets());
	}

	public ICursorDesign CursorDesign()
	{
		return new PlayerHandDesign(_resource.Icon);
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
		IGridCellAction action = new BuildingSpawnAction(_resource.scene);
						
						action = new OccupancyAction(
							action,
							layerBag.occupancy,
							_resource.MyType,
							_resource.ConflictsWith);
						
						action = new ExistingFoundationTile(layerBag.ground,action);

		return action;
	}

	public void Selected(PlayerHand hand)
	{
		hand.Grasp(this);
	}
}
