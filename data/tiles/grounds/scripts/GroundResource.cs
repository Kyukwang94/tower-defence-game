using Godot;
using Game.Enums;
using Game.Action.Validation;


[GlobalClass]
public partial class GroundResource : TileEntityResource , IPlaceable
{	
	[ExportGroup("Ground Info")]
	[Export] public GroundProperties Properties {get; set;}
	[Export] public GroundElement 	 Element{get; set;}

	[ExportGroup("Deploy Rule")]
	[Export] public Godot.Collections.Array<FoundationRuleResource> SpecificRules { get; set; }
	public int deployArea = 1;


	public IGridCellAction PlacementAction(ILayerProvider mapProvider, bool isDevmode)
	{
		TileMapLayer mapLayer = mapProvider.GetLayer(this.TargetLayer);
		
		IGridCellAction action = new TilePaint(mapLayer, this.SourceId , this.AtlasCoords);

		if (isDevmode) return action;
		
		//Variant Rules
		if(SpecificRules != null)
		{
			foreach (var rule in SpecificRules)
			{
				action = rule.Wrap(action, mapLayer);
			}
		}

		//Universal Laws
		action = new ExistingFoundationTile(action , mapLayer);
		action = new UniqueTilePlacement(action , mapLayer, this.SourceId , this.AtlasCoords);
			
		return action;
	}
}