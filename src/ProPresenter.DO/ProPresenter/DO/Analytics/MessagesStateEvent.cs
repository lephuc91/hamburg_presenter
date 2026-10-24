using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record MessagesStateEvent(MessageState State) : IAnalyticEvent
{
	public static void Publish(MessageState state)
	{
		EventPublisher.Publish(new MessagesStateEvent(state));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiLowerrightMessagesState = new LowerRightMessagesState
			{
				State = State.ToProtoState()
			};
		});
	}
}
