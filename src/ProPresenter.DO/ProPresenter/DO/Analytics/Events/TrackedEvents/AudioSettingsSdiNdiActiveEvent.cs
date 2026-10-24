using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public record AudioSettingsSdiNdiActiveEvent(bool Value) : IAnalyticEvent
{
	public static void Publish(bool value)
	{
		EventPublisher.Publish(new AudioSettingsSdiNdiActiveEvent(value));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.AudioSettingsSdiNdiActive = new AudioSettingsSdiNdiActive
			{
				Value = Value
			};
		});
	}
}
