using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Startup;

namespace ProPresenter.DO.Analytics;

public record MacrosStartupEvent : IAnalyticEvent
{
	public static void Publish()
	{
		EventPublisher.Publish(new MacrosStartupEvent());
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.StartupMacro = new Macro();
		});
	}
}
