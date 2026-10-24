using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Startup;

namespace ProPresenter.DO.Analytics;

public record StartupScreenConfigSummaryEvent(int AudienceScreenCount, int StageScreenCount) : IAnalyticEvent
{
	public static void Publish(int audienceScreenCount, int stageScreenCount)
	{
		EventPublisher.Publish(new StartupScreenConfigSummaryEvent(audienceScreenCount, stageScreenCount));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.StartupScreenConfiguration = new Summary
			{
				TotalScreens = AudienceScreenCount + StageScreenCount,
				AudienceScreenCount = AudienceScreenCount,
				StageScreenCount = StageScreenCount
			};
		});
	}
}
