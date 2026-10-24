using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Pro.Common.Collections;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.UI.SlideEditor.Inspectors;

public class TextLinkTypeToEnableConverter : IMultiValueConverter
{
	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length == 3 && values[0] is CompositeCollection compositeCollection && values[1] is IEnumerable<ClosedBezierPath> source)
		{
			object obj = values[2];
			if (obj is LinkedTextType)
			{
				if ((LinkedTextType)obj == LinkedTextType.CCLITemplate)
				{
					return true;
				}
				return !compositeCollection.Contains(LinkedTextType.CCLITemplate) || (from p in source
					where p.TextLink.IsEnabled
					select p into t
					select t.TextLink.LinkedObject).NonNull().Any((ILinkedTextObject t) => t.LinkedTextType == LinkedTextType.CCLITemplate);
			}
		}
		return true;
	}

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
