using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record TimersEditEvent(EditField Field) : IAnalyticEvent
{
	public static void Publish(EditField field)
	{
		EventPublisher.Publish(new TimersEditEvent(field));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiLowerrightTimersEdit = new LowerRightTimersEdit
			{
				Field = Field.ToProtoField()
			};
		});
	}
}
