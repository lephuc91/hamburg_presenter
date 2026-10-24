using System;
using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public record SlideLabelChangedEvent(int SlidesAffected, SlideLabelChangeSource Source) : IAnalyticEvent
{
	public SlideLabelChangedEvent(int slidesAffected)
		: this(slidesAffected, SlideLabelChangeSource.ContextMenu)
	{
	}

	public SlideLabelChangedEvent(SlideLabelChangeSource source)
		: this(0, source)
	{
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			ShowSlideLabelChange showSlideLabelChange = new ShowSlideLabelChange
			{
				NumberOfSlides = SlidesAffected
			};
			ShowSlideLabelChange showSlideLabelChange2 = showSlideLabelChange;
			showSlideLabelChange2.Source = Source switch
			{
				SlideLabelChangeSource.ContextMenu => ShowSlideLabelChange.Types.Source.ContextMenu, 
				SlideLabelChangeSource.Popover => ShowSlideLabelChange.Types.Source.Popover, 
				_ => throw new NotSupportedException(), 
			};
			e.UiShowSlideLabelChange = showSlideLabelChange;
		});
	}
}
