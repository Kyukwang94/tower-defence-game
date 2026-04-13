using Godot;

public sealed class EmptyAction : IGridCellAction
{
    
    public bool TryOnCell(BoardContext context, Vector2I cell)
    {
        return true;
    }

    
    public void OnCell(BoardContext context, Vector2I cell)
    {
        
    }
}