public interface IBoarNode 
{
	Board Board { get; }
}
public interface IBoardAction
{
	void Execute(IBoard board);
}

