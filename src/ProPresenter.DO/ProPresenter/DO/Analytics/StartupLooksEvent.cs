using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Startup;

namespace ProPresenter.DO.Analytics;

public record StartupLooksEvent(int PresetCount) : IAnalyticEvent
{
	public static void Publish(int presetCount)
	{
		EventPublisher.Publish(new StartupLooksEvent(presetCount));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.StartupLooks = new Pro.SerializationInterop.RVProtoData.Analytics.Startup.Looks
			{
				NumberPresets = PresetCount
			};
		});
	}
}
