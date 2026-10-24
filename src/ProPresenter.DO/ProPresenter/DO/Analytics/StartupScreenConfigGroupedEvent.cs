using System.Runtime.CompilerServices;
using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Startup;

namespace ProPresenter.DO.Analytics;

public record StartupScreenConfigGroupedEvent : StartupScreenEventBase
{
	public int Columns { get; init; }

	public int Rows { get; init; }

	public StartupScreenConfigGroupedEvent(ProScreenType ScreenType, bool ScreenColorEnabled, int Columns, int Rows)
	{
		this.Columns = Columns;
		this.Rows = Rows;
		base._002Ector(ScreenType, ScreenColorEnabled);
	}

	public static void Publish(ProScreenType screenType, bool screenColorEnabled, int columns, int rows)
	{
		EventPublisher.Publish(new StartupScreenConfigGroupedEvent(screenType, screenColorEnabled, columns, rows));
	}

	public override IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.StartupScreenConfigurationGroupedScreen = new Grouped
			{
				ScreenType = base.ScreenType.ToProtoScreenType(),
				ScreenColorEnabled = base.ScreenColorEnabled,
				Columns = Columns,
				Rows = Rows
			};
		});
	}

	[CompilerGenerated]
	public void Deconstruct(out ProScreenType ScreenType, out bool ScreenColorEnabled, out int Columns, out int Rows)
	{
		ScreenType = base.ScreenType;
		ScreenColorEnabled = base.ScreenColorEnabled;
		Columns = this.Columns;
		Rows = this.Rows;
	}
}
