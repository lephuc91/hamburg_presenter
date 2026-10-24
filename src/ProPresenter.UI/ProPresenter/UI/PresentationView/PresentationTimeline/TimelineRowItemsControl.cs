using System.Windows;
using System.Windows.Controls;

namespace ProPresenter.UI.PresentationView.PresentationTimeline;

public class TimelineRowItemsControl : ItemsControl
{
	protected override DependencyObject GetContainerForItemOverride()
	{
		return (DependencyObject)(object)new ContentPresenter();
	}

	protected override bool IsItemItsOwnContainerOverride(object item)
	{
		return item is ContentPresenter;
	}
}
