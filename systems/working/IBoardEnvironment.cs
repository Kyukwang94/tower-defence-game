public interface IBoardEnvironment
{
	void ActOn(IGridArea area, IGridCellAction action);
	void ActOn(IBoardAction action);
	T Ask<T>(ILayerQuery<T> query);
}