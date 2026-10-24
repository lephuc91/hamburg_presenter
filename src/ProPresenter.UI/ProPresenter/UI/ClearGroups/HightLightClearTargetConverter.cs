using System;
using System.Globalization;
using System.Linq;
using Pro.UI.Converters;
using ProPresenter.DO.Actions;
using ProPresenter.DO.ClearGroups;

namespace ProPresenter.UI.ClearGroups;

public class HightLightClearTargetConverter : MultiValueConverterBase<bool>
{
	protected override bool ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length == 2 && values[0] is ClearType value && values[1] is ClearGroup clearGroup)
		{
			return clearGroup.ClearTargets.Contains(value);
		}
		return false;
	}
}
