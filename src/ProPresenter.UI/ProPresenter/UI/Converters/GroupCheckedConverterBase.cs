using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Pro.Common.Components;
using Pro.DO.Triggering;
using Pro.UI.Converters;

namespace ProPresenter.UI.Converters;

public abstract class GroupCheckedConverterBase<L, I> : MultiValueConverterBase<bool> where L : IEnumerable<I> where I : IIdentifiable
{
	protected override bool ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length >= 2 && values[0] is L val)
		{
			if (values[1] is I value)
			{
				return val.Contains(value);
			}
			object obj = values[1];
			ActionBase action = obj as ActionBase;
			if (action != null)
			{
				return val.Any((I m) => DoesGroupContainActionItem(m, action));
			}
			obj = values[1];
			if (obj is Guid)
			{
				Guid macroID = (Guid)obj;
				return val.Any((I m) => m.ID == macroID);
			}
		}
		return false;
	}

	public abstract bool DoesGroupContainActionItem(I item, ActionBase action);
}
