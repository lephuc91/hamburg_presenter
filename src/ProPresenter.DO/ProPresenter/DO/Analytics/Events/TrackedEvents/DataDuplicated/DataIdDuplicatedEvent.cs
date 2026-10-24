using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;
using ProPresenter.DO.Analytics.Events.TrackedEvents.DataIdDuplicated;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents.DataDuplicated;

public class DataIdDuplicatedEvent(DataType _type, int _count) : IAnalyticEvent
{
	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.DataIdDuplicated = new Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.DataIdDuplicated
			{
				NumberDuplicates = _count,
				Type = _type.ToProtoDataType()
			};
		});
	}
}
