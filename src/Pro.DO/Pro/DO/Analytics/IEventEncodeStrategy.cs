namespace Pro.DO.Analytics;

public interface IEventEncodeStrategy<T>
{
	T? Encode(IAnalyticEvent @event);
}
