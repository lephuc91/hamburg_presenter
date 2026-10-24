using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record MessagesEditEvent(MessageEditAction Action) : IAnalyticEvent
{
	public static void Publish(MessageEditAction action)
	{
		EventPublisher.Publish(new MessagesEditEvent(action));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiLowerrightMessagesEdit = new LowerRightMessagesEdit
			{
				Action = Action.ToProtoAction()
			};
		});
	}
}
