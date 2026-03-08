using Godot;
using System;
using Game.Action.Validation;

public sealed class Ground : IDisplayable , IButtonInfo , IPlaceable
{
	// Ground 받아야함 Resource 를
	private readonly GroundResource _groundResource;
	
	public Texture2D Icon => _groundResource.Icon;
	public string Label => _groundResource.Name;

	public Ground(GroundResource groundResource)
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
	
	public IGridCellAction PlacementAction(ILayerProvider mapProvider, bool isDevmode)
	{
		TileMapLayer mapLayer = mapProvider.GetLayer(_groundResource.TargetLayer);
		
		IGridCellAction action = new TilePaint(mapLayer, _groundResource.SourceId , _groundResource.AtlasCoords);

		if (isDevmode) return action;
		
		//Variant Rules
		if(_groundResource.SpecificRules != null)
		{
			foreach (var rule in _groundResource.SpecificRules)
			{
				action = rule.Wrap(action, mapLayer);
			}
		}
		//Universal Laws
		action = new ExistingFoundationTile (action , mapLayer);
		action = new UniqueTilePlacement    (action , mapLayer, _groundResource.SourceId , _groundResource.AtlasCoords);
		

		GD.Print(_groundResource.Name);
		return action;
	}

	public ICursorDesign CursorDesign()
	{
		return new PlayerHandDesign (_groundResource.Icon);
	}

}
