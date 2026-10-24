using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Logging;

namespace Pro.Text.RTF;

internal class FontTable
{
	private static readonly FontData DefaultFontData = new FontData(null, null, RunSettings.DefaultFont.PSName ?? string.Empty);

	private readonly Dictionary<int, FontData> _fonts = new Dictionary<int, FontData>();

	private readonly Dictionary<FontData, int> _indices = new Dictionary<FontData, int>();

	public IEnumerable<int> Indices => _fonts.Keys;

	public void LoadFont(int? characterSet, int? codePage, string family, int index)
	{
		if (_fonts.ContainsKey(index))
		{
			Log.Error($"{family} font was already defined at index {index}");
		}
		else
		{
			AddFont(new FontData(characterSet, codePage, family), index);
		}
	}

	public int GetIndex(FontData fontData)
	{
		if (!_indices.TryGetValue(fontData, out var value))
		{
			return AddFont(fontData);
		}
		return value;
	}

	public FontData GetFontData(int index)
	{
		if (!_fonts.TryGetValue(index, out FontData value))
		{
			return DefaultFontData;
		}
		return value;
	}

	public void Clear()
	{
		_fonts.Clear();
		_indices.Clear();
	}

	private int AddFont(FontData fontData, int index = -1)
	{
		if (index < 0)
		{
			index = (Indices.Any() ? (Indices.Max() + 1) : 0);
		}
		if (_fonts.ContainsKey(index))
		{
			throw new InvalidOperationException("Font index is already defined");
		}
		_fonts.Add(index, fontData);
		if (!_indices.ContainsKey(fontData))
		{
			_indices.Add(fontData, index);
		}
		return index;
	}
}
