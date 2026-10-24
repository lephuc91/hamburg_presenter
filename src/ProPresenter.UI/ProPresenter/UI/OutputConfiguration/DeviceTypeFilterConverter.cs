using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public class DeviceTypeFilterConverter : IValueConverter
{
	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is IEnumerable<IDevice> source && parameter is DeviceType)
		{
			DeviceType deviceTypeParameter = (DeviceType)parameter;
			return source.Where((IDevice d) => d.DeviceType == deviceTypeParameter).Distinct();
		}
		return null;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
