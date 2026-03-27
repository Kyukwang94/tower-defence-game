using Godot;

[GlobalClass]
public partial class BuildingStandardRule : BuildingInstallationRule
{
	public override IGridCellAction CreateAction(Building bluePrint, LayerBag layerBag)
	{
		return new BuildingStandardPlacement(bluePrint, layerBag);
	}
}