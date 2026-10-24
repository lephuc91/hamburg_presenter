using System;
using System.Globalization;
using Pro.UI.Converters;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Props;

namespace ProPresenter.UI.Props;

public class SelectEditPropCommandParamConverter : MultiValueConverterBase<Tuple<PropAction?, IPropCue, PropTriggerType>>
{
	protected override Tuple<PropAction?, IPropCue, PropTriggerType>? ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length == 1 && values[0] is IPropCue item)
		{
			return new Tuple<PropAction, IPropCue, PropTriggerType>(null, item, PropTriggerType.Trigger);
		}
		if (values.Length == 3 && values[0] is PropAction item2 && values[1] is IPropCue item3 && values[2] is PropTriggerType item4)
		{
			return new Tuple<PropAction, IPropCue, PropTriggerType>(item2, item3, item4);
		}
		return null;
	}
}
