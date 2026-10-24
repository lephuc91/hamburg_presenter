using System;
using System.Globalization;
using Pro.DO.Triggering;
using Pro.UI.Converters;

namespace ProPresenter.UI.ActionsMenu;

public class ActionDataCommandParameterConverter : MultiValueConverterBase<ActionDataParameter?>
{
	protected override ActionDataParameter? ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length == 2 && values[0] is ActionBase action && values[1] != null)
		{
			return new ActionDataParameter(action, values[1]);
		}
		return null;
	}
}
