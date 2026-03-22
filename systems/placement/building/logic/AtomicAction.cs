using Godot;

public sealed class AtomicAction : IGridCellAction
{
    private readonly IGridCellAction _validator; // 모든 칸을 검사/실행할 녀석 (ShapeIntegrity)
    private readonly IGridCellAction _executor;  // 딱 한 번만 실행할 녀석 (Spawn)

    public AtomicAction(IGridCellAction validator, IGridCellAction executor)
    {
        _validator = validator;
        _executor = executor;
    }

    public bool TryOnCell(TileMapLayer layer, Vector2I pivot) 
        => _validator.TryOnCell(layer, pivot); // 전체가 무결한지 확인

    public void OnCell(TileMapLayer layer, Vector2I pivot)
    {
        _validator.OnCell(layer, pivot); // 타일 점유 등 반복 작업 수행
        _executor.OnCell(layer, pivot);  // 건물 소환 딱 한 번 수행
    }
}