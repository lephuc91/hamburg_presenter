namespace Pro.DO.Analytics;

public interface IAnalyticEventHandler
{
	void Execute(IAnalyticEvent @event);
}
