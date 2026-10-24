using System.Runtime.CompilerServices;
using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record MainViewShownEvent : MainViewEventBase
{
	public MainViewShownEvent(MainViewSource Source)
		: base(Source)
	{
	}

	public static void Publish(MainViewSource source)
	{
		EventPublisher.Publish(new MainViewShownEvent(source));
	}

	public override IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiMainviewShow = new MainViewShow
			{
				Source = base.Source.ToProtoMainViewShownSource()
			};
		});
	}

	[CompilerGenerated]
	public new void Deconstruct(out MainViewSource Source)
	{
		Source = base.Source;
	}
}
