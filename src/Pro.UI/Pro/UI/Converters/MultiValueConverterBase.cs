using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Pro.UI.Converters;

public abstract class MultiValueConverterBase<TOut> : MarkupExtension, IMultiValueConverter
{
	private bool _convertBackSuccessful = true;

	protected virtual TOut? ValidationFailResult => default(TOut);

	public object? Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		return (!ValidateValues(values) || !ValidateBindingValues(values)) ? ValidationFailResult : ConvertValues(values, targetType, parameter, culture);
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		object[] result = ConvertValuesBack(value, targetTypes, parameter, culture);
		if (!_convertBackSuccessful)
		{
			return Enumerable.Repeat(Binding.DoNothing, targetTypes.Length).ToArray();
		}
		return result;
	}

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		return this;
	}

	protected abstract TOut? ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture);

	protected virtual object[] ConvertValuesBack(object value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		_convertBackSuccessful = false;
		return Enumerable.Repeat(Binding.DoNothing, targetTypes.Length).ToArray();
	}

	protected virtual bool ValidateValues(object?[] values)
	{
		return true;
	}

	private static bool ValidateBindingValues(object?[] values)
	{
		return values.All((object v) => v != DependencyProperty.UnsetValue);
	}
}
