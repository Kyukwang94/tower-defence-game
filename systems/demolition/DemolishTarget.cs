using Godot;

public sealed class DemolishTarget : IBoardQuery<IDemolishable>
{
    private readonly Vector2I _cell;
    public DemolishTarget(Vector2I cell) 
	{
		_cell = cell;
	}

    public IDemolishable Ask(IBoard board)
    {
    	if(board.Ledger.TryGetOccupant(_cell, out IDemolishable target))
		{
			return target;
		}
		target = null;
		return target;
    }
}