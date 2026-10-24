using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Pro.Common.Collections;
using Pro.UI.Converters;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.Templates.SlideMenu;

public class ThemeContainerToChildrenConverter : ValueConverterBase<ThemeContainer, IEnumerable<ThemeContainer>>
{
	protected override IEnumerable<ThemeContainer> ConvertValue(ThemeContainer value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value == null)
		{
			return Array.Empty<ThemeContainer>();
		}
		IEnumerable<ThemeContainer> children = value.Children;
		bool flag = false;
		if (parameter is bool)
		{
			flag = (bool)parameter;
		}
		if (!flag)
		{
			return children.Where((ThemeContainer c) => c.Children.Empty());
		}
		return children.Where((ThemeContainer c) => !c.Children.Empty());
	}
}
