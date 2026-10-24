using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record BackgroundColorEvent(ColorType ColorType, SelectionType SelectionType) : IAnalyticEvent
{
	public BackgroundColorEvent(ColorType colorType)
		: this(colorType, SelectionType.Object)
	{
	}

	public BackgroundColorEvent(SelectionType selectionType)
		: this(ColorType.Clear, selectionType)
	{
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiTextinspectorBackgroundColor = new TextInspectorBackgroundColor
			{
				ColorType = ColorType.ToColorType(),
				SelectionMode = SelectionType.ToSelectionMode()
			};
		});
	}
}
