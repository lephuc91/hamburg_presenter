using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Startup;

namespace ProPresenter.DO.Analytics;

public record StartupClearGroupEvent(int GroupCount, int HiddenGroupCount, int DefaultIconCount, int CustomIconCount, int IconTintCount) : IAnalyticEvent
{
	public static void Publish(int groupCount, int hiddenGroupCount, int defaultIconCount, int customIconCount, int iconTintCount)
	{
		EventPublisher.Publish(new StartupClearGroupEvent(groupCount, hiddenGroupCount, defaultIconCount, customIconCount, iconTintCount));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.StartupClearGroup = new ClearGroup
			{
				ClearGroupCount = GroupCount,
				HiddenClearGroupCount = HiddenGroupCount,
				DefaultIconCount = DefaultIconCount,
				CustomIconCount = CustomIconCount,
				IconTintCount = IconTintCount
			};
		});
	}
}
