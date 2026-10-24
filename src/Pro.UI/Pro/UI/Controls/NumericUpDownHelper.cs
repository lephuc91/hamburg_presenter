using System;
using System.Reflection;
using Xceed.Wpf.Toolkit;

namespace Pro.UI.Controls;

internal static class NumericUpDownHelper<T> where T : struct, IFormattable, IComparable<T>
{
	private delegate bool HandleNullSpinDelegate(CommonNumericUpDown<T> instance);

	private delegate T? CoerceValueMinMaxDelegate(CommonNumericUpDown<T> instance, T value);

	private delegate T? ConvertTextToValueDelegate(CommonNumericUpDown<T> instance, string text);

	private static readonly HandleNullSpinDelegate? _handleNullSpin;

	private static readonly CoerceValueMinMaxDelegate? _coerceValueMinMax;

	private static readonly ConvertTextToValueDelegate? _convertTextToValue;

	static NumericUpDownHelper()
	{
		MethodInfo method = typeof(CommonNumericUpDown<T>).GetMethod("HandleNullSpin", BindingFlags.Instance | BindingFlags.NonPublic);
		if (method != null)
		{
			_handleNullSpin = (HandleNullSpinDelegate)Delegate.CreateDelegate(typeof(HandleNullSpinDelegate), method);
		}
		MethodInfo method2 = typeof(CommonNumericUpDown<T>).GetMethod("CoerceValueMinMax", BindingFlags.Instance | BindingFlags.NonPublic);
		if (method2 != null)
		{
			_coerceValueMinMax = (CoerceValueMinMaxDelegate)Delegate.CreateDelegate(typeof(CoerceValueMinMaxDelegate), method2);
		}
		MethodInfo method3 = typeof(CommonNumericUpDown<T>).GetMethod("ConvertTextToValue", BindingFlags.Instance | BindingFlags.NonPublic);
		if (method3 != null)
		{
			_convertTextToValue = (ConvertTextToValueDelegate)Delegate.CreateDelegate(typeof(ConvertTextToValueDelegate), method3);
		}
	}

	public static bool HandleNullSpin(CommonNumericUpDown<T> instance)
	{
		return _handleNullSpin?.Invoke(instance) ?? false;
	}

	public static T? CoerceValueMinMax(CommonNumericUpDown<T> instance, T value)
	{
		return _coerceValueMinMax?.Invoke(instance, value);
	}

	public static T? ConvertTextToValue(CommonNumericUpDown<T> instance, string text)
	{
		return _convertTextToValue?.Invoke(instance, text);
	}
}
