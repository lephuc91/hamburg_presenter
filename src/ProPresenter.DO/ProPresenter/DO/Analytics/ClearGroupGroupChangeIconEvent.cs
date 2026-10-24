using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record ClearGroupGroupChangeIconEvent(ChangeIconType Type, bool IsTinted) : IAnalyticEvent
{
	public static void Publish(ChangeIconType type, bool isTinted)
	{
		EventPublisher.Publish(new ClearGroupGroupChangeIconEvent(type, isTinted));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiClearGroupsChangeIcon = new ClearGroupsChangeIcon
			{
				IconType = Type.ToProto(),
				IsTinted = IsTinted
			};
		});
	}
}
