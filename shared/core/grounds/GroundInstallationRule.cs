using Godot;

public abstract partial class GroundInstallationRule : Resource 
{
    public abstract IGridCellAction CreateAction(Ground bluePrint, LayerBag layerBag);    
}

