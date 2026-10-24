using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record StageMessageStateEvent(StageMessageStatus State) : IAnalyticEvent
{
	public static void Publish(StageMessageStatus state)
	{
		EventPublisher.Publish(new StageMessageStateEvent(state));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			LowerRightMessagesState lowerRightMessagesState = new LowerRightMessagesState();
			LowerRightMessagesState lowerRightMessagesState2 = lowerRightMessagesState;
			lowerRightMessagesState2.State = State switch
			{
				StageMessageStatus.Show => LowerRightMessagesState.Types.State.Show, 
				StageMessageStatus.Clear => LowerRightMessagesState.Types.State.Clear, 
				_ => LowerRightMessagesState.Types.State.Unknown, 
			};
			e.UiLowerrightMessagesState = lowerRightMessagesState;
		});
	}
}
