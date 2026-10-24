using System.Runtime.CompilerServices;
using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record MainViewThemeEditorEvent : MainViewEventBase
{
	public MainViewThemeEditorEvent(MainViewSource Source)
		: base(Source)
	{
	}

	public static void Publish(MainViewSource source)
	{
		EventPublisher.Publish(new MainViewThemeEditorEvent(source));
	}

	public override IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiMainviewThemeEditor = new MainViewThemeEditor
			{
				Source = base.Source.ToProtoMainViewThemeEditorSource()
			};
		});
	}

	[CompilerGenerated]
	public new void Deconstruct(out MainViewSource Source)
	{
		Source = base.Source;
	}
}
