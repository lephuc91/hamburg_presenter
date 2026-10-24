using System;
using System.Globalization;
using Pro.UI.Converters;
using ProPresenter.UI.ViewModels.TestPattern.Property;

namespace ProPresenter.UI.TestPattern.Properties;

public class NumericPropertyToFormatStringConverter : ValueConverterBase<ITestPatternPropertyVM, string>
{
	protected override string ConvertValue(ITestPatternPropertyVM value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is IDoublePropertyVM doublePropertyVM)
		{
			return "{0:N1} " + doublePropertyVM.Units;
		}
		if (value is IIntPropertyVM intPropertyVM)
		{
			return "{0:N0} " + intPropertyVM.Units;
		}
		return string.Empty;
	}
}
