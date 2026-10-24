using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Create;

namespace ProPresenter.DO.Analytics;

public record PresentationCreateEvent(PresentationCreateSource Source) : IAnalyticEvent
{
	public static void Publish(PresentationCreateSource source)
	{
		EventPublisher.Publish(new PresentationCreateEvent(source));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.CreatePresentation = new Pro.SerializationInterop.RVProtoData.Analytics.Create.Presentation
			{
				Source = Source.ToProto()
			};
		});
	}
}
