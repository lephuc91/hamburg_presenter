using System;
using System.Globalization;
using System.Windows.Data;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.SlideEditor.Inspectors.Links;

public class CheckVisibilityLinkObjectConverter : IMultiValueConverter
{
	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length == 2 && values[0] is ILinkedVisibilityObject linkedVisibilityObject && values[1] != null)
		{
			if (linkedVisibilityObject.Type == VisibilityLinkType.SlideObject && values[1] is SlideElementBase slideElementBase)
			{
				return ((ElementLinkedVisibilityObject)linkedVisibilityObject).Element == slideElementBase;
			}
			if (linkedVisibilityObject.Type == VisibilityLinkType.Timer && values[1] is TimerData timerData)
			{
				return ((TimerLinkedVisibilityObject)linkedVisibilityObject).TimerData == timerData;
			}
			return false;
		}
		return false;
	}

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
