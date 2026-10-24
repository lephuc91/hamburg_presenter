using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public record AudioInputStartUpEvent(uint TotalInputCount, uint OnInputCount, uint OffInputCount, uint AutoOnInputCount, uint AutoOffInputCount) : IAnalyticEvent
{
	public static void Publish(uint totalInputCount, uint onInputCount, uint offInputCount, uint autoOnInputCount, uint autoOffInputCount)
	{
		EventPublisher.Publish(new AudioInputStartUpEvent(totalInputCount, onInputCount, offInputCount, autoOnInputCount, autoOffInputCount));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.AudioInputStartUp = new AudioInputStartUp
			{
				TotalInputCount = TotalInputCount,
				OnInputCount = OnInputCount,
				OffInputCount = OffInputCount,
				AutoOnInputCount = AutoOnInputCount,
				AutoOffInputCount = AutoOffInputCount
			};
		});
	}
}
