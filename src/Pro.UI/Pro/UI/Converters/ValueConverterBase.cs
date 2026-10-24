using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Pro.UI.Converters;

public abstract class ValueConverterBase<VIn, VOut> : MarkupExtension, IValueConverter
{
	private bool _convertBackSuccessful = true;

	protected virtual VOut? ValidationFailResult => default(VOut);

	public virtual object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		return (VOut)((!ValidateValue(value) || !ValidateBindingValue(value)) ? ((object)ValidationFailResult) : ((object)ConvertValue((VIn)value, targetType, parameter, culture)));
	}

	public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		VIn val = ConvertValueBack((VOut)value, targetType, parameter, culture);
		if (!_convertBackSuccessful)
		{
			return Binding.DoNothing;
		}
		return val;
	}

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		return this;
	}

	protected abstract VOut ConvertValue(VIn value, Type targetType, object? parameter, CultureInfo culture);

	protected virtual VIn? ConvertValueBack(VOut value, Type targetType, object? parameter, CultureInfo culture)
	{
		_convertBackSuccessful = false;
		return default(VIn);
	}

	protected virtual bool ValidateValue(object? value)
	{
		return value is VIn;
	}

	private static bool ValidateBindingValue(object? value)
	{
		return value != DependencyProperty.UnsetValue;
	}
}
