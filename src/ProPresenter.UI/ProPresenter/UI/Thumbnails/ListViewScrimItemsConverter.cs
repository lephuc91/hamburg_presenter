using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Pro.UI.Converters;
using ProPresenter.DO;

namespace ProPresenter.UI.Thumbnails;

public class ListViewScrimItemsConverter : ValueConverterBase<IEnumerable<IScrimSource>, IEnumerable<IScrimSource>>
{
	protected override IEnumerable<IScrimSource> ConvertValue(IEnumerable<IScrimSource> value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (parameter is ListViewType)
		{
			ListViewType listViewType = (ListViewType)parameter;
			return value.Where((IScrimSource i) => i.ListViewType == listViewType);
		}
		return Enumerable.Empty<IScrimSource>();
	}
}
