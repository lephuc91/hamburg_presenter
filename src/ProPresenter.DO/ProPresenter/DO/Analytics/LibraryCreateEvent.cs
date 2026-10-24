using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Create;

namespace ProPresenter.DO.Analytics;

public record LibraryCreateEvent(LibraryCreateSource Source) : IAnalyticEvent
{
	public static void Publish(LibraryCreateSource source)
	{
		EventPublisher.Publish(new LibraryCreateEvent(source));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.CreateLibrary = new Library();
		});
	}
}
