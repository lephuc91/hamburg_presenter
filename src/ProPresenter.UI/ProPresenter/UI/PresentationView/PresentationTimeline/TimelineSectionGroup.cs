using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProPresenter.UI.PresentationView.PresentationTimeline;

public class TimelineSectionGroup : TimelineSection
{
	public static readonly DependencyProperty GroupNameProperty;

	public string GroupName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(GroupNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GroupNameProperty, (object)value);
		}
	}

	static TimelineSectionGroup()
	{
		GroupNameProperty = DependencyProperty.Register("GroupName", typeof(string), typeof(TimelineSectionGroup));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(TimelineSectionGroup), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(TimelineSectionGroup)));
		Control.BackgroundProperty.OverrideMetadata(typeof(TimelineSectionGroup), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.CornflowerBlue));
		TimelineSection.AllowMoveProperty.OverrideMetadata(typeof(TimelineSectionGroup), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
	}
}
