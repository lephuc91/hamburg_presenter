using System;
using System.Globalization;
using Pro.DO.Triggering;
using Pro.UI.Converters;
using ProPresenter.DO.Actions;

namespace ProPresenter.UI.ActionsMenu;

public class ActionDataIsCheckedConverter : MultiValueConverterBase<bool>
{
	protected override bool ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length >= 2 && values[0] is ActionBase action && values[1] != null)
		{
			return action.IsDataSelected(values[1]);
		}
		return false;
	}
}
