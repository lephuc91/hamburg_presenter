using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Startup;

namespace ProPresenter.DO.Analytics.Events.Startup;

public record StartupVersioningEvent(string HighestVersion) : IAnalyticEvent
{
	public static void Publish(string highestVersion)
	{
		EventPublisher.Publish(new StartupVersioningEvent(highestVersion));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.StartupVersioning = new Versioning
			{
				HighestVersion = HighestVersion
			};
		});
	}
}
