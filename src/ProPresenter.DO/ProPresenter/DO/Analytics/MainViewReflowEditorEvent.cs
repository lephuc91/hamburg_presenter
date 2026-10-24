using System.Runtime.CompilerServices;
using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record MainViewReflowEditorEvent : MainViewEventBase
{
	public MainViewReflowEditorEvent(MainViewSource Source)
		: base(Source)
	{
	}

	public static void Publish(MainViewSource source)
	{
		EventPublisher.Publish(new MainViewReflowEditorEvent(source));
	}

	public override IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiMainviewReflow = new MainViewReflowEditor
			{
				Source = base.Source.ToProtoMainViewReflowEditorShownSource()
			};
		});
	}

	[CompilerGenerated]
	public new void Deconstruct(out MainViewSource Source)
	{
		Source = base.Source;
	}
}
