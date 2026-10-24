using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using ProPresenter.DO.PCO;

namespace ProPresenter.UI.PCOLive;

public class FlattenPCOFolderConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		return ((value is PCOFolder pCOFolder) ? ((IEnumerable<PCOObject>)pCOFolder.Folders).Concat((IEnumerable<PCOObject>)pCOFolder.ServiceTypes).ToArray() : null) ?? Array.Empty<PCOObject>();
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
