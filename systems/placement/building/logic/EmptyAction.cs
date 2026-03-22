using Godot;

public sealed class EmptyAction : IGridCellAction
{
    
    public bool TryOnCell(TileMapLayer layer, Vector2I cell)
    {
        return true;
    }

    
    public void OnCell(TileMapLayer layer, Vector2I cell)
    {
        
    }
}