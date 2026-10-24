using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.ProContent;

namespace ProPresenter.DO.Analytics.Events.ProContent;

public record ProContentDownloadRetryEvent : IAnalyticEvent
{
	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.ProcontentDownloadRetry = new DownloadRetry();
		});
	}
}
