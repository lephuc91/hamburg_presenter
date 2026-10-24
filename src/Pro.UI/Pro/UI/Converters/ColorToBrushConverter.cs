using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using Pro.Common.Cache;

namespace Pro.UI.Converters;

public class ColorToBrushConverter : IValueConverter
{
	private sealed class ColorKey : IEquatable<ColorKey>
	{
		public Color Color { get; }

		public ColorKey(Color color)
		{
			Color = color;
		}

		public override bool Equals(object? obj)
		{
			if (obj is ColorKey other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(ColorKey? other)
		{
			Color color = Color;
			Color? obj = other?.Color;
			return color == obj;
		}

		public override int GetHashCode()
		{
			return Color.GetHashCode();
		}
	}

	private sealed class BrushCache : WeakValueCache<ColorKey, Brush>
	{
		protected override Brush GenerateValue(ColorKey target)
		{
			SolidColorBrush solidColorBrush = new SolidColorBrush(target.Color);
			((Freezable)solidColorBrush).Freeze();
			return solidColorBrush;
		}
	}

	private static readonly BrushCache _brushCache = new BrushCache();

	public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (!(value is Color color))
		{
			return Brushes.Transparent;
		}
		return _brushCache.Get(new ColorKey(color));
	}

	public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
