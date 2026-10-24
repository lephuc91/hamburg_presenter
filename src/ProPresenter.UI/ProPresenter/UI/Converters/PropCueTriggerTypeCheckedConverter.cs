using System;
using System.Globalization;
using Pro.UI.Converters;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Props;

namespace ProPresenter.UI.Converters;

public class PropCueTriggerTypeCheckedConverter : MultiValueConverterBase<bool>
{
	protected override bool ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length >= 3 && values[0] is PropAction propAction && values[1] is IPropCue propCue && values[2] is PropTriggerType propTriggerType)
		{
			if (propAction.PropTriggerType == propTriggerType)
			{
				return propAction.PropID == propCue.ID;
			}
			return false;
		}
		return false;
	}
}
