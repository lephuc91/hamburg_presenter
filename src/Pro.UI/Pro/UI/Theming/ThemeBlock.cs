using System;
using System.IO;
using System.Windows.Media;
using Pro.Common.DataStore;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.Common.Utility;

namespace Pro.UI.Theming;

internal class ThemeBlock : StoreBase
{
	private const string ThemesFolder = "themes";

	private const string ThemeExtension = ".theme";

	private const char RGBAKeyFragment = '#';

	private const char LinkKeyFragment = '$';

	private const char PaletteFragment = '*';

	private const char InvertMarker = '~';

	private const char BlendMarker = '+';

	private const char AlphaMarker = '@';

	private GlobalPaletteProviderDelegate _paletteProvider;

	private GlobalColorProviderDelegate _colorProvider;

	public ThemeBlock(string themeID, GlobalPaletteProviderDelegate paletteProvider, GlobalColorProviderDelegate colorProvider)
		: base(Path.Combine("themes", themeID + ".theme"), allowWriting: false)
	{
		_paletteProvider = paletteProvider;
		_colorProvider = colorProvider;
		RegisterCustomType(delegate
		{
			throw new NotSupportedException();
		}, LoadColor);
	}

	private Color? LoadColor(string colorData)
	{
		if (colorData.NullableIsNullOrEmpty())
		{
			return null;
		}
		Color? result = null;
		string[] array = colorData.Split(new char[1] { '+' }, StringSplitOptions.RemoveEmptyEntries);
		foreach (string colorData2 in array)
		{
			Color? color = ParseColor(colorData2);
			if (color.HasValue)
			{
				result = (result.HasValue ? new Color?(result.Value.Blend(color.Value)) : color);
			}
		}
		return result;
	}

	private Color? ParseColor(string colorData)
	{
		bool flag = colorData[0] == '~';
		if (flag)
		{
			if (colorData.Length <= 1)
			{
				return null;
			}
			colorData = colorData.Substring(1);
		}
		Color? result = null;
		switch (colorData[0])
		{
		case '#':
			result = ParseRawColor(colorData, (string p) => (Color)ColorConverter.ConvertFromString(p));
			break;
		case '$':
			result = ParseRawColor(colorData, (string p) => GetColor(p.Substring(1)));
			break;
		}
		if (flag && result.HasValue)
		{
			result = result.Value.InvertColor();
		}
		return result;
	}

	private Color? ParseRawColor(string colorData, Func<string, Color?> colorProvider)
	{
		string[] array = colorData.Split(new char[1] { '@' }, 2, StringSplitOptions.RemoveEmptyEntries);
		Color? result = colorProvider(array[0]);
		if (result.HasValue && array.Length == 2 && int.TryParse(array[1], out var result2))
		{
			Color value = result.Value;
			value.A = (byte)(((double)result2 / 100.0).Clamp(0.0, 1.0) * (double)(int)value.A);
			return value;
		}
		return result;
	}

	private StatePalette? LoadPalette(string paletteKey, string? paletteData)
	{
		if (paletteData.NullableIsNullOrEmpty())
		{
			return null;
		}
		if (paletteData[0] == '*')
		{
			return ParsePalette(paletteKey, paletteData.Substring(1));
		}
		return null;
	}

	private StatePalette ParsePalette(string paletteKey, string paletteData)
	{
		StatePalette basePalette = ((!string.IsNullOrEmpty(paletteData)) ? _paletteProvider(paletteData) : null);
		return new StatePalette(paletteKey, basePalette, _colorProvider);
	}

	public Color? GetColor(string key)
	{
		return GetValue<Color?>(key, null);
	}

	public StatePalette? GetPalette(string key)
	{
		return LoadPalette(key, GetValue<string>(key));
	}
}
