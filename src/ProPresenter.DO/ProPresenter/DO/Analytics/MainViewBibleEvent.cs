using System.Runtime.CompilerServices;
using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record MainViewBibleEvent : MainViewEventBase
{
	public MainViewBibleEvent(MainViewSource Source)
		: base(Source)
	{
	}

	public static void Publish(MainViewSource source)
	{
		EventPublisher.Publish(new MainViewBibleEvent(source));
	}

	public override IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiMainviewBible = new MainViewBible
			{
				Source = base.Source.ToProtoMainViewBibleShownSource()
			};
		});
	}

	[CompilerGenerated]
	public new void Deconstruct(out MainViewSource Source)
	{
		Source = base.Source;
	}
}
