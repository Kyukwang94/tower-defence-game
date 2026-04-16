using Godot;

public sealed class EmptyAction : IGridCellAction
{
    
    public bool TryOnCell(IBoard board, Vector2I cell)
    {
        return true;
    }

    
    public void OnCell(IBoard board, Vector2I cell)
    {
        
    }
}