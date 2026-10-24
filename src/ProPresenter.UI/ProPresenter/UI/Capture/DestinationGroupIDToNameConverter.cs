using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Pro.Localization;
using ProPresenter.DO.Resi;

namespace ProPresenter.UI.Capture;

public class DestinationGroupIDToNameConverter : IMultiValueConverter
{
	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length == 2)
		{
			object obj = values[0];
			if (obj is Guid)
			{
				Guid id = (Guid)obj;
				if (values[1] is IEnumerable<IDestinationGroup> source)
				{
					return source.FirstOrDefault((IDestinationGroup g) => g.ID == id)?.Name ?? LocalizedStrings.Get("RECORDING_WINDOW_RESI_SELECT_GROUP_label");
				}
			}
		}
		return string.Empty;
	}

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
