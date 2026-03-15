using Godot;
using System;
using System.Collections.Generic;

using Game.Placement.Core.Area;
using Game.Action.Validation;
using Game.Enums;

public sealed class GroundTileItem : IButtonInfo , IHandItem
{
	private readonly GroundResource _resource;
	

	public ItemType Type  => _resource.Type;
	public Texture2D Icon => _resource.Icon;
	public string Label   => _resource.Name;

	public GroundTileItem(GroundResource groundResource)
	{
		_resource = groundResource;
	}
	public void DisplayOn(IGallery gallery)
	{
		gallery.Show(this);
	}
	public void Selected(PlayerHand hand)
	{
		GD.Print($"[GroundItem] Selected 호출됨: {Label}");
		hand.Grasp(this);
	}
	public ICursorDesign CursorDesign()
	{
		return new PlayerHandDesign (_resource.Icon);
	}
	
	//occupancyLayer를 Building쪽에서 주입시켜야하는데 ..
	public IGridCellAction PlacementAction(LayerBag layerBag)	
	{
		IGridCellAction action = new GroundPaint(_resource.SourceId , _resource.AtlasCoords);

		//Variant Rules
		if(_resource.SpecificRules != null)
		{
			foreach (var rule in _resource.SpecificRules)
			{
				action = rule.Wrap(action);
			}
		}
		
		//Universal Laws
		action = new OccupancyAction(
			action,
			layerBag.occupancy,
			_resource.MyType,
			_resource.ConflictsWith);

		action = new ExistingFoundationTile (layerBag.ground, action);
		action = new UniqueTilePlacement    (action ,_resource.SourceId , _resource.AtlasCoords);
		
		GD.Print(_resource.Name);

		return action;
	}

	public IEnumerable<Vector2I> OccupiedOffsets()
	{
		yield return new Vector2I(0,0);
	}

	public IGridArea Area(Vector2I start, Vector2I end)
	{
		// 지정된 Shape영역
		// return new ShapeArea(end, OccupiedOffsets());

		//Dragging 되는 모든 영역 가능.
		return new GridArea(start, end);
	}
}
