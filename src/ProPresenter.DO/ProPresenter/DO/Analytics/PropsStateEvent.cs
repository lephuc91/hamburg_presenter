using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record PropsStateEvent(PropsState State) : IAnalyticEvent
{
	public static void Publish(PropsState state)
	{
		EventPublisher.Publish(new PropsStateEvent(state));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiLowerrightPropsState = new LowerRightPropsState
			{
				State = State.ToProtoPropsState()
			};
		});
	}
}
