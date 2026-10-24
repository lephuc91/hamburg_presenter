using Google.Protobuf;

namespace Pro.DO.Analytics;

public interface IAnalyticEvent
{
	IMessage Serialize();
}
