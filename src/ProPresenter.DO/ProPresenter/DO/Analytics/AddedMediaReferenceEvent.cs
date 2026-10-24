using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.MediaManagement;

namespace ProPresenter.DO.Analytics;

public record AddedMediaReferenceEvent(uint Width, uint Height) : IAnalyticEvent
{
	public static void Publish(uint width, uint height)
	{
		EventPublisher.Publish(new AddedMediaReferenceEvent(width, height));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.MediaManagementAddedMediaReference = new AddedMediaReference
			{
				Width = (int)Width,
				Height = (int)Height
			};
		});
	}
}
