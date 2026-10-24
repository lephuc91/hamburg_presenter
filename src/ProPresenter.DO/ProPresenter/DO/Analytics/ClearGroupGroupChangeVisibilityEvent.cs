using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record ClearGroupGroupChangeVisibilityEvent(ChangeVisibilityType Type) : IAnalyticEvent
{
	public static void Publish(ChangeVisibilityType type)
	{
		EventPublisher.Publish(new ClearGroupGroupChangeVisibilityEvent(type));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiClearGroupsChangeVisibility = new ClearGroupsChangeVisibility
			{
				Visibility = Type.ToProto()
			};
		});
	}
}
