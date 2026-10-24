using System.Runtime.CompilerServices;
using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Startup;

namespace ProPresenter.DO.Analytics;

public record StartupScreenConfigMirroredEvent : StartupScreenEventBase
{
	public int Count { get; init; }

	public StartupScreenConfigMirroredEvent(ProScreenType ScreenType, bool ScreenColorEnabled, int Count)
	{
		this.Count = Count;
		base._002Ector(ScreenType, ScreenColorEnabled);
	}

	public static void Publish(ProScreenType screenType, bool screenColorEnabled, int count)
	{
		EventPublisher.Publish(new StartupScreenConfigMirroredEvent(screenType, screenColorEnabled, count));
	}

	public override IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.StartupScreenConfigurationMirroredScreen = new Mirrored
			{
				ScreenType = base.ScreenType.ToProtoScreenType(),
				ScreenColorEnabled = base.ScreenColorEnabled,
				Count = Count
			};
		});
	}

	[CompilerGenerated]
	public void Deconstruct(out ProScreenType ScreenType, out bool ScreenColorEnabled, out int Count)
	{
		ScreenType = base.ScreenType;
		ScreenColorEnabled = base.ScreenColorEnabled;
		Count = this.Count;
	}
}
