using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Common.Mathematics;
using Pro.UI.Components;

namespace Pro.UI.Converters;

public abstract class Vector2ConverterBase<T> : DataConverterBase<Vector2<T>>
{
	public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		bool flag = parameter is bool && (bool)parameter;
		if (value is Vector2<T> vector)
		{
			if (flag)
			{
				return vector.X;
			}
			return vector.Y;
		}
		return Binding.DoNothing;
	}

	public override object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		bool flag = default(bool);
		int num;
		if (parameter is bool)
		{
			flag = (bool)parameter;
			num = 1;
		}
		else
		{
			num = 0;
		}
		bool flag2 = (byte)((uint)num & (flag ? 1u : 0u)) != 0;
		if (value is T val)
		{
			Vector2<T> data = base.Data;
			if (flag2)
			{
				data.X = val;
			}
			else
			{
				data.Y = val;
			}
			return data;
		}
		return base.Data;
	}
}
