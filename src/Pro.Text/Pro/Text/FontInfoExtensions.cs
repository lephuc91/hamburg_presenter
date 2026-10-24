using System;
using System.Windows;
using Pro.Common.Utility;

namespace Pro.Text;

public static class FontInfoExtensions
{
	public static string Encode(FontInfo font)
	{
		global::_003C_003Ey__InlineArray9<object> buffer = default(global::_003C_003Ey__InlineArray9<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray9<object>, object>(ref buffer, 0) = font.SystemFamilyName;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray9<object>, object>(ref buffer, 1) = font.SystemFaceName;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray9<object>, object>(ref buffer, 2) = font.DisplayFamilyName;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray9<object>, object>(ref buffer, 3) = font.DisplayFaceName;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray9<object>, object>(ref buffer, 4) = font.FullName;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray9<object>, object>(ref buffer, 5) = font.PSName;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray9<object>, object>(ref buffer, 6) = font.Weight.ToOpenTypeWeight();
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray9<object>, object>(ref buffer, 7) = font.Stretch.ToOpenTypeStretch();
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray9<object>, object>(ref buffer, 8) = font.IsItalic;
		return string.Join(",", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray9<object>, object>(in buffer, 9));
	}

	public static FontInfo Decode(string value)
	{
		string[] array = value.Split(',');
		return new FontInfo(array[0], array[1], array[2], array[3], array[4], array[5], FontWeight.FromOpenTypeWeight(int.Parse(array[6])), FontStretch.FromOpenTypeStretch(int.Parse(array[7])), BooleanExtensions.Decode(array[8]));
	}

	public static int GetMatchWeight(this FontInfo fontInfo, FontInfo candidate)
	{
		int num = 0;
		if (string.Equals(candidate.SystemFaceName, fontInfo.SystemFaceName, StringComparison.OrdinalIgnoreCase))
		{
			num++;
		}
		if (candidate.Stretch == fontInfo.Stretch)
		{
			num += 2;
		}
		if (candidate.Weight == fontInfo.Weight)
		{
			num += 3;
		}
		if (candidate.IsItalic == fontInfo.IsItalic)
		{
			num += 3;
		}
		return num;
	}
}
