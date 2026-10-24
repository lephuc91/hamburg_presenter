using System;
using System.Globalization;
using System.Windows.Data;
using Pro.UI.Components;

namespace ProPresenter.UI.Converters;

public class PopupTypeToIsOpenConverter : DataConverterBase<PopupType>
{
	public override object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is PopupType popupType && parameter is PopupType popupType2)
		{
			return popupType.HasFlag(popupType2);
		}
		return false;
	}

	public override object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is bool flag && parameter is PopupType popupType)
		{
			PopupType data = base.Data;
			if (!flag && data.HasFlag(popupType))
			{
				return data & ~popupType;
			}
			return data;
		}
		return Binding.DoNothing;
	}
}
