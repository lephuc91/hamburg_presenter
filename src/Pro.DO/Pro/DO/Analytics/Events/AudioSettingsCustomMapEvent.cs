using Google.Protobuf;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace Pro.DO.Analytics.Events;

public record AudioSettingsCustomMapEvent(bool Value) : IAnalyticEvent
{
	public static void Publish(bool value)
	{
		EventPublisher.Publish(new AudioSettingsCustomMapEvent(value));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.AudioSettingsCustomMap = new AudioSettingsCustomMap
			{
				Value = Value
			};
		});
	}
}
