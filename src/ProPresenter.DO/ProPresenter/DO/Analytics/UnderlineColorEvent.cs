using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record UnderlineColorEvent(bool IsEnabled, SelectionType SelectionType) : IAnalyticEvent
{
	public UnderlineColorEvent(bool isEnabled)
		: this(isEnabled, SelectionType.Object)
	{
	}

	public UnderlineColorEvent(SelectionType selectionType)
		: this(IsEnabled: false, selectionType)
	{
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiTextinspectorUnderlineColor = new TextInspectorUnderlineColor
			{
				IsEnabled = IsEnabled,
				SelectionMode = SelectionType.ToSelectionMode()
			};
		});
	}
}
