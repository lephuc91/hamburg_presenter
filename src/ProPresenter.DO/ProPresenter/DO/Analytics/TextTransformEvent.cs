using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record TextTransformEvent(TextTransformType TextTransformType) : IAnalyticEvent
{
	public static void Publish(TextTransformType textTransformType)
	{
		EventPublisher.Publish(new TextTransformEvent(textTransformType));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiTextinspectorLineTransform = new TextInspectorLineTransform
			{
				TransformType = TextTransformType.ToLineTransformType()
			};
		});
	}
}
