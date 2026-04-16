using System; 
public interface IBoardQuery<out T> 
{
	T Ask(IBoard board);
}