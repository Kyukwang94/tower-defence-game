public interface IBoard 
{
	BoardEnvironment BoardEnv { get; }
}
public interface IBoardAction
{
	void Execute(BoardEnvironment boardEnv);
}

