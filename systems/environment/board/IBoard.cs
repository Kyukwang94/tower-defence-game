public interface IBoard : IBoardContext
{
	void ActOn(IGridArea area, IGridCellAction action);
	void ActOn(IBoardAction action);
	T Ask<T>(IBoardQuery<T> query);
}