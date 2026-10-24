using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics.Events.Capture;

public record OpenCaptureSettingsEvent(CaptureShownSource Source) : IAnalyticEvent
{
	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiCaptureShown = new Pro.SerializationInterop.RVProtoData.Analytics.UI.Capture
			{
				Source = Source.ToProto()
			};
		});
	}
}
