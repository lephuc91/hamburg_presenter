using System.Collections.Generic;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Utility;

namespace Pro.Text.RTF;

internal class ColorTable
{
	public static readonly Color DefaultColor = Colors.Black;

	private int _loadIndex;

	private readonly List<Color> _colors = new List<Color>();

	public int EntryCount => _colors.Count;

	public void LoadDefaultColor()
	{
		if (_loadIndex < _colors.Count)
		{
			_loadIndex++;
		}
		else
		{
			AddColor(DefaultColor);
		}
	}

	public void LoadRGBAColor(byte r, byte g, byte b, byte a)
	{
		LoadColor(Color.FromArgb(a, r, g, b));
	}

	public void LoadNormalizedRGBAColor(double r, double g, double b, double a)
	{
		LoadColor(ColorExtensions.FromNormalizedRGBA(r, g, b, a));
	}

	public void LoadGrayscaleColor(double g, double a)
	{
		LoadColor(ColorExtensions.FromGrayscale(g, a));
	}

	public void LoadCMYKAColor(double c, double m, double y, double k, double a)
	{
		LoadColor(ColorExtensions.FromCMYKA(c, m, y, k, a));
	}

	private void LoadColor(Color color)
	{
		if (_loadIndex < _colors.Count)
		{
			_colors[_loadIndex++] = color;
		}
		else
		{
			AddColor(color);
		}
	}

	public void ResetLoadIndex()
	{
		_loadIndex = 0;
	}

	public int GetIndex(Color color, bool allowIndexZero = false)
	{
		if (!allowIndexZero && _colors.Empty())
		{
			LoadDefaultColor();
		}
		int num = _colors.IndexOf(color);
		if (num < ((!allowIndexZero) ? 1 : 0))
		{
			return AddColor(color);
		}
		return num;
	}

	public Color GetColor(int index)
	{
		if (index < 0 || index >= _colors.Count)
		{
			return DefaultColor;
		}
		return _colors[index];
	}

	public void Clear()
	{
		_colors.Clear();
		_loadIndex = 0;
	}

	private int AddColor(Color color)
	{
		_colors.Add(color);
		_loadIndex++;
		return _colors.Count - 1;
	}
}
