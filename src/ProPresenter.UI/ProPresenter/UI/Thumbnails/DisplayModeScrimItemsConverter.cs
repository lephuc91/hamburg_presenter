using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Pro.UI.Converters;
using ProPresenter.DO;

namespace ProPresenter.UI.Thumbnails;

public class DisplayModeScrimItemsConverter : ValueConverterBase<IEnumerable<IScrimSource>, IEnumerable<IScrimSource>>
{
	protected override IEnumerable<IScrimSource> ConvertValue(IEnumerable<IScrimSource> value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (parameter is DisplayMode)
		{
			DisplayMode displayMode = (DisplayMode)parameter;
			return value.Where((IScrimSource i) => i.DisplayMode == displayMode);
		}
		return Enumerable.Empty<IScrimSource>();
	}
}
