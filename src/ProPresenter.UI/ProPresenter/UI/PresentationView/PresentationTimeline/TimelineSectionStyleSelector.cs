using System;
using System.Windows;
using System.Windows.Controls;
using ProPresenter.DO.Presentation;
using ProPresenter.UI.ViewModels.Timeline;

namespace ProPresenter.UI.PresentationView.PresentationTimeline;

public class TimelineSectionStyleSelector : StyleSelector
{
	public Style? AudioSectionStyle { get; set; }

	public Style? CueSectionStyle { get; set; }

	public Style? MediaSectionStyle { get; set; }

	public Style? OtherActionSectionStyle { get; set; }

	public override Style? SelectStyle(object item, DependencyObject container)
	{
		ITimelineItemVM obj = item as ITimelineItemVM;
		if (obj == null)
		{
			throw new ArgumentNullException();
		}
		return obj.ItemType switch
		{
			TimelineItemType.Slide => CueSectionStyle, 
			TimelineItemType.VisualMedia => MediaSectionStyle, 
			TimelineItemType.Actions => OtherActionSectionStyle, 
			TimelineItemType.AudioMedia => AudioSectionStyle, 
			_ => throw new InvalidOperationException(), 
		};
	}
}
