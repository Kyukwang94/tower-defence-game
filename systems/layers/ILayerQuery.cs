using System; 
public interface ILayerQuery<out T> 
{
	T Execute(ILayerProvider layerProvider);
}