using System.Windows;
using System.Windows.Controls;
using ProPresenter.UI.ViewModels.Welcome;

namespace ProPresenter.UI.Welcome;

internal class IntroPageSlideDataTemplateSelector : DataTemplateSelector
{
	public override DataTemplate? SelectTemplate(object? item, DependencyObject container)
	{
		if (container is FrameworkElement frameworkElement && item != null && item is IIntroContent { Type: var type })
		{
			switch (type)
			{
			case ContentType.Image:
				return frameworkElement.FindResource("ImageTemplate") as DataTemplate;
			case ContentType.Video:
				return frameworkElement.FindResource("VideoTemplate") as DataTemplate;
			}
		}
		return null;
	}
}
