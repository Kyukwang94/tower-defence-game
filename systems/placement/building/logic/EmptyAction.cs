using Godot;

public sealed class EmptyAction : IGridCellAction
{
    
    public bool TryOnCell(BoardEnvironment boardEnv, Vector2I cell)
    {
        return true;
    }

    
    public void OnCell(BoardEnvironment boardEnv, Vector2I cell)
    {
        
    }
}