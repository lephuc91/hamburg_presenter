using System;
using System.Linq;
using System.Windows.Media;
using Pro.Common.Mathematics;

namespace Pro.Common.Utility;

public static class ColorExtensions
{
	private const double RedWeight = 0.299;

	private const double GreenWeight = 0.587;

	private const double BlueWeight = 0.114;

	private const double LuminanceThreshold = 127.0;

	public static float NormalizeComponent(byte v)
	{
		return (float)(int)v / 255f;
	}

	public static double NormalizeComponentDouble(byte v)
	{
		return (double)(int)v / 255.0;
	}

	public static byte ScaleComponent(double v)
	{
		return (byte)Math.Round(v * 255.0).Clamp(0.0, 255.0);
	}

	public static double Luminance(this Color color)
	{
		return (double)(int)color.R * 0.299 + (double)(int)color.G * 0.587 + (double)(int)color.B * 0.114;
	}

	public static bool IsLuminous(this Color color)
	{
		return color.Luminance() > 127.0;
	}

	public static Color InvertColor(this Color color)
	{
		return Color.FromArgb(color.A, (byte)(~color.R), (byte)(~color.G), (byte)(~color.B));
	}

	public static string EncodeColor(this Color color)
	{
		global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = NormalizeComponentDouble(color.R);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = NormalizeComponentDouble(color.G);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = NormalizeComponentDouble(color.B);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = NormalizeComponentDouble(color.A);
		return string.Format("{0} {1} {2} {3}", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4));
	}

	public static Color DecodeColor(this string value)
	{
		Func<string, byte> selector = (string c) => ScaleComponent(double.Parse(c));
		byte[] array = value.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(selector).ToArray();
		if (array.Length != 4)
		{
			return Colors.Transparent;
		}
		return Color.FromArgb(array[3], array[0], array[1], array[2]);
	}

	public static Color Multiply(this Color color, double a)
	{
		return Color.FromArgb(color.A, (byte)((double)(int)color.R * a), (byte)((double)(int)color.G * a), (byte)((double)(int)color.B * a));
	}

	public static Color Blend(this Color bgColor, Color fgColor)
	{
		double num = (double)(int)bgColor.A / 255.0;
		double num2 = (double)(int)fgColor.A / 255.0;
		double num3 = num + num2 - num * num2;
		Color color = bgColor.Multiply(num * (1.0 - num2));
		Color color2 = fgColor.Multiply(num2);
		return Color.FromArgb((byte)Math.Min(num3 * 255.0, 255.0), (byte)Math.Min((double)(color.R + color2.R) / num3, 255.0), (byte)Math.Min((double)(color.G + color2.G) / num3, 255.0), (byte)Math.Min((double)(color.B + color2.B) / num3, 255.0));
	}

	public static Color FromNormalizedRGB(double r, double g, double b)
	{
		return FromNormalizedRGBA(r, g, b, 1.0);
	}

	public static Color FromNormalizedRGBA(double r, double g, double b, double a)
	{
		return Color.FromArgb(ScaleComponent(a), ScaleComponent(r), ScaleComponent(g), ScaleComponent(b));
	}

	public static Color FromCMYKA(double c, double m, double y, double k, double a)
	{
		double num = 1.0 - k;
		return Color.FromArgb(ScaleComponent(a), ScaleComponent((1.0 - c) * num), ScaleComponent((1.0 - m) * num), ScaleComponent((1.0 - y) * num));
	}

	public static Color FromGrayscale(double g, double a)
	{
		byte b = ScaleComponent(g);
		return Color.FromArgb(ScaleComponent(a), b, b, b);
	}

	public static Color? EvaluateColor(this Color? color, Color? value)
	{
		if (!color.HasValue && value.HasValue)
		{
			Color value2 = value.Value;
			value2.A = byte.MaxValue;
			return value2;
		}
		return value;
	}
}
