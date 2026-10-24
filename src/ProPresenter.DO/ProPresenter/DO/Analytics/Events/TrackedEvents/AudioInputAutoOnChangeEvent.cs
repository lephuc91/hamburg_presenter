using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public record AudioInputAutoOnChangeEvent(uint InputCount) : IAnalyticEvent
{
	public static void Publish(uint inputCount)
	{
		EventPublisher.Publish(new AudioInputAutoOnChangeEvent(inputCount));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.AudioInputAutoOnChange = new AudioInputAutoOnChange
			{
				InputCount = InputCount
			};
		});
	}
}
