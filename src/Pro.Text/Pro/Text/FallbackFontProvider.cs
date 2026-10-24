using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Pro.Common.Collections;
using Pro.Common.Strings;

namespace Pro.Text;

public class FallbackFontProvider
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal unsafe delegate nint FallbackFontCallback(uint* codepoints, int length, int attemptCount);

	private class FontData
	{
		public uint RangeStart { get; }

		public uint RangeEnd { get; }

		public Font Font { get; }

		public FontData(uint rangeStart, uint rangeEnd, Font font)
		{
			RangeStart = rangeStart;
			RangeEnd = rangeEnd;
			Font = font;
		}
	}

	private readonly List<Font> _allFonts = new List<Font>();

	private readonly List<FontData> _registeredFonts = new List<FontData>();

	internal FallbackFontCallback ProviderCallback { get; }

	public unsafe FallbackFontProvider()
	{
		ProviderCallback = OnFallbackFontRequested;
	}

	public void RegisterFont(uint rangeStart, uint rangeEnd, Font font)
	{
		if (!_allFonts.Contains(font))
		{
			_allFonts.Add(font);
		}
		_registeredFonts.Add(new FontData(rangeStart, rangeEnd, font));
	}

	public Font? FindFallbackFont(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		int index = Math.Max(0, text.FindIndex(IsValidCharacter));
		return OnFindFallbackFont((uint)char.ConvertToUtf32(text, index), 0);
	}

	private unsafe nint OnFallbackFontRequested(uint* codepoints, int length, int attemptCount)
	{
		if (codepoints == null || length <= 0)
		{
			return IntPtr.Zero;
		}
		int num = 0;
		for (int i = 0; i < length; i++)
		{
			if (char.ConvertFromUtf32((int)codepoints[i]).Any(IsValidCharacter))
			{
				num = i;
				break;
			}
		}
		return OnFindFallbackFont(codepoints[num], attemptCount)?.Handle ?? IntPtr.Zero;
	}

	private static bool IsValidCharacter(char character)
	{
		if (!char.IsPunctuation(character) && !char.IsWhiteSpace(character) && !char.IsControl(character) && character != '\u200b')
		{
			return !StringExtensions.NonBreakingSpaces.Contains(character);
		}
		return false;
	}

	private Font? OnFindFallbackFont(uint codepoint, int attemptCount)
	{
		return _registeredFonts.Where((FontData d) => codepoint >= d.RangeStart && codepoint <= d.RangeEnd).Skip(attemptCount).FirstOrDefault()?.Font;
	}

	internal Font GetFont(nint typefaceHandle)
	{
		return _allFonts.First((Font f) => f.Handle == typefaceHandle);
	}
}
