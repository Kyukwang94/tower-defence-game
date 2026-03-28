using Godot;

public sealed class EmptyAction : IGridCellAction
{
    
    public bool TryOnCell(Board board, Vector2I cell)
    {
        return true;
    }

    
    public void OnCell(Board board, Vector2I cell)
    {
        
    }
}