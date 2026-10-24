using System;
using Xceed.Wpf.Toolkit;

namespace Pro.UI.Controls;

internal static class CommonNumericUpDownExtensions
{
	public static bool HandleNullSpin<T>(this CommonNumericUpDown<T> instance) where T : struct, IFormattable, IComparable<T>
	{
		return NumericUpDownHelper<T>.HandleNullSpin(instance);
	}

	public static T? CoerceValueMinMax<T>(this CommonNumericUpDown<T> instance, T value) where T : struct, IFormattable, IComparable<T>
	{
		return NumericUpDownHelper<T>.CoerceValueMinMax(instance, value);
	}

	public static bool TryConvertText<T>(this CommonNumericUpDown<T> instance, string text, out T value) where T : struct, IFormattable, IComparable<T>
	{
		value = default(T);
		try
		{
			T? val = NumericUpDownHelper<T>.ConvertTextToValue(instance, text);
			if (val.HasValue)
			{
				value = val.Value;
			}
			return val.HasValue;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static void StepValue<T>(this CommonNumericUpDown<T> instance, string text, Action baseAction, Func<T, T> stepValue) where T : struct, IFormattable, IComparable<T>
	{
		T value;
		if (!instance.UpdateValueOnEnterKey)
		{
			baseAction();
		}
		else if (!instance.HandleNullSpin() && instance.TryConvertText(text, out value))
		{
			instance.Value = instance.CoerceValueMinMax(stepValue(value));
		}
	}
}
