using Godot;

[GlobalClass]
public partial class GroundStandardRule : GroundInstallationRule
{
	public override IGridCellAction CreateAction(Ground bluePrint)
	{
		return new GroundStandardPlacement(bluePrint);
	}
}