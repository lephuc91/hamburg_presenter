using System;
using System.Globalization;
using Pro.UI.Converters;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Props;

namespace ProPresenter.UI.Props;

public class SelectAddPropCommandParamConverter : MultiValueConverterBase<Tuple<IPropCue, PropTriggerType>>
{
	protected override Tuple<IPropCue, PropTriggerType>? ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length == 1 && values[0] is IPropCue item)
		{
			return new Tuple<IPropCue, PropTriggerType>(item, PropTriggerType.Trigger);
		}
		if (values.Length == 2 && values[0] is IPropCue item2 && values[1] is PropTriggerType item3)
		{
			return new Tuple<IPropCue, PropTriggerType>(item2, item3);
		}
		return null;
	}
}
