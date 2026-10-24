using System.Runtime.CompilerServices;
using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record MainViewPresentationEditorEvent : MainViewEventBase
{
	public MainViewPresentationEditorEvent(MainViewSource Source)
		: base(Source)
	{
	}

	public static void Publish(MainViewSource source)
	{
		EventPublisher.Publish(new MainViewPresentationEditorEvent(source));
	}

	public override IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiMainviewPresentationEditor = new MainViewPresentationEditor
			{
				Source = base.Source.ToProtoMainViewPresentationEditorSource()
			};
		});
	}

	[CompilerGenerated]
	public new void Deconstruct(out MainViewSource Source)
	{
		Source = base.Source;
	}
}
