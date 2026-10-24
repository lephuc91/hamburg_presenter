using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.ProContent;

namespace ProPresenter.DO.Analytics.Events.ProContent;

public record ProContentViewMediaBinEvent : IAnalyticEvent
{
	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.ProcontentMediabinView = new MediaBinView();
		});
	}
}
