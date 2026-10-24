using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Startup;

namespace ProPresenter.DO.Analytics;

public record StartupNetworkLinkEvent(bool IsEnabled, uint MemberCount) : IAnalyticEvent
{
	public static void Publish(bool isEnabled, uint memberCount)
	{
		EventPublisher.Publish(new StartupNetworkLinkEvent(isEnabled, memberCount));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.StartupNetworkLink = new Pro.SerializationInterop.RVProtoData.Analytics.Startup.NetworkLink
			{
				Enabled = IsEnabled,
				MemberCount = MemberCount
			};
		});
	}
}
