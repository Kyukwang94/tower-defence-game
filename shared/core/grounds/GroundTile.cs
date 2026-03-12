using Godot;
using System;
using Game.Action.Validation;
using System.Collections.Generic;
using Game.Placement.Core.Area;
using Game.Enums;
public sealed class GroundTile : IButtonInfo , IHandItem
{
	// Ground 받아야함 Resource 를
	private readonly GroundResource _groundResource;
	
	public ItemType Type => ItemType.Ground;
	public Texture2D Icon => _groundResource.Icon;
	public string Label => _groundResource.Name;

	public GroundTile(GroundResource groundResource)
	{
		_groundResource = groundResource;
	}
	public void DisplayOn(IGallery gallery)
	{
		gallery.Show(this);
	}
	public void Selected(PlayerHand hand)
	{
		hand.Grasp(this);
	}
	public ICursorDesign CursorDesign()
	{
		return new PlayerHandDesign (_groundResource.Icon);
	}

	//어디에 속해야 할지를 여기서처리하기 때문에 추후 Building , Unit모두 범용 가능함.
	public IGridCellAction PlacementAction()
	{	

		IGridCellAction action = new TilePaint(_groundResource.SourceId , _groundResource.AtlasCoords);

		
		//Variant Rules
		if(_groundResource.SpecificRules != null)
		{
			foreach (var rule in _groundResource.SpecificRules)
			{
				action = rule.Wrap(action);
			}
		}
		
		//Universal Laws
		action = new ExistingFoundationTile (action);
		action = new UniqueTilePlacement    (action ,_groundResource.SourceId , _groundResource.AtlasCoords);
		
		GD.Print(_groundResource.Name);
		
		return action;
	}

	public IEnumerable<Vector2I> OccupiedOffsets()
	{
		yield return new Vector2I(0,0);
		yield return new Vector2I(-1,0);
	}

	public IGridArea Area(Vector2I start, Vector2I end)
	{
		// 지정된 Shape영역
		// return new ShapeArea(end, OccupiedOffsets());

		//Dragging 되는 모든 영역 가능.
		return new GridArea(start, end);
	}

	public IGridCellAction PreviewAction()
	{
		IGridCellAction action = new PlacementPreviewAction(
			PlacementAction()
		);

		return action;
	}

}
