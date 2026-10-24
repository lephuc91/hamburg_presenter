using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Pro.UI.Converters;
using ProPresenter.DO.Actions;

namespace ProPresenter.UI.ClearGroups;

public class HighLightClearButtonConverter : MultiValueConverterBase<bool>
{
	protected override bool ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length == 2 && values[0] is IReadOnlyCollection<ClearType> source)
		{
			object obj = values[1];
			IReadOnlyCollection<ClearType> activeLayers = obj as IReadOnlyCollection<ClearType>;
			if (activeLayers != null)
			{
				return source.Any((ClearType c) => activeLayers.Contains(c));
			}
		}
		return false;
	}
}
