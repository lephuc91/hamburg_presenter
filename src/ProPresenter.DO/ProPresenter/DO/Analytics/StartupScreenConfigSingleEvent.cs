using System.Runtime.CompilerServices;
using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Startup;

namespace ProPresenter.DO.Analytics;

public record StartupScreenConfigSingleEvent : StartupScreenEventBase
{
	public StartupScreenConfigSingleEvent(ProScreenType ScreenType, bool ScreenColorEnabled)
		: base(ScreenType, ScreenColorEnabled)
	{
	}

	public static void Publish(ProScreenType screenType, bool screenColorEnabled)
	{
		EventPublisher.Publish(new StartupScreenConfigSingleEvent(screenType, screenColorEnabled));
	}

	public override IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.StartupScreenConfigurationSingleScreen = new Single
			{
				ScreenType = base.ScreenType.ToProtoScreenType(),
				ScreenColorEnabled = base.ScreenColorEnabled
			};
		});
	}

	[CompilerGenerated]
	public new void Deconstruct(out ProScreenType ScreenType, out bool ScreenColorEnabled)
	{
		ScreenType = base.ScreenType;
		ScreenColorEnabled = base.ScreenColorEnabled;
	}
}
