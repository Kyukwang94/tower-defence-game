using Godot;

[GlobalClass]
public partial class BuildingStandardRule : BuildingInstallationRule
{
	public override IGridCellAction CreateAction(Building bluePrint)
	{
		return new BuildingStandardPlacement(bluePrint);
	}
}