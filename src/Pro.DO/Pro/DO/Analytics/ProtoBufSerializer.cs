using System;
using Google.Protobuf;
using Pro.Common.Logging;

namespace Pro.DO.Analytics;

public class ProtoBufSerializer : IEventEncodeStrategy<IMessage>
{
	public IMessage? Encode(IAnalyticEvent @event)
	{
		try
		{
			return @event.Serialize();
		}
		catch (Exception ex)
		{
			Log.Error("Failed to serialize analytic event {0}", ex);
			return null;
		}
	}
}
