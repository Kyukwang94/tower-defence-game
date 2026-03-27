using Godot;

public abstract partial class BuildingInstallationRule : Resource 
{
    public abstract IGridCellAction CreateAction(Building bluePrint, LayerBag layerBag);    
}

