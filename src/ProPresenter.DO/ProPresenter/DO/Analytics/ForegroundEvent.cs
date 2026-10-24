using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record ForegroundEvent(FillType FillType, SelectionType SelectionType) : IAnalyticEvent
{
	public ForegroundEvent(FillType fillType)
		: this(fillType, SelectionType.Object)
	{
	}

	public ForegroundEvent(SelectionType selectionType)
		: this(FillType.Solid, selectionType)
	{
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiTextinspectorForeground = new TextInspectorForeground
			{
				FillType = FillType.ToFillType(),
				SelectionMode = SelectionType.ToSelectionMode()
			};
		});
	}
}
