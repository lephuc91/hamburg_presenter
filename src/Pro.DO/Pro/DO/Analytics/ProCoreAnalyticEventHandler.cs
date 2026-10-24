using Google.Protobuf;
using Pro.Reporting;
using ProPresenterCore.ProCore.Interop;

namespace Pro.DO.Analytics;

public class ProCoreAnalyticEventHandler : IAnalyticEventHandler
{
	private readonly IEventEncodeStrategy<IMessage> _serializer;

	public ProCoreAnalyticEventHandler(IEventEncodeStrategy<IMessage>? serializer = null)
	{
		ProAnalyticsInstance.ExceptionHandler = Dreamcatcher.ReportUnhandledException;
		_serializer = serializer ?? new ProtoBufSerializer();
	}

	public void Execute(IAnalyticEvent @event)
	{
		IMessage message = _serializer.Encode(@event);
		if (message != null)
		{
			ProAnalyticsInstance.SendEvent(message);
		}
	}
}
