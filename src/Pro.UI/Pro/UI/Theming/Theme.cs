using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Pro.Common.Cache;
using Pro.Common.Collections;

namespace Pro.UI.Theming;

public class Theme : DynamicObject, INotifyPropertyChanged
{
	private class BrushCache : Cache<string, Brush>
	{
		private readonly Theme _colorBlock;

		public BrushCache(Theme colorBlock)
		{
			_colorBlock = colorBlock;
		}

		protected override Brush GenerateValue(string target)
		{
			SolidColorBrush obj = new SolidColorBrush
			{
				Color = _colorBlock.GetColor(target, null)
			};
			((Freezable)obj).Freeze();
			return obj;
		}
	}

	private class PaletteCache : Cache<string, StatePalette>
	{
		private readonly Theme _colorBlock;

		public PaletteCache(Theme colorBlock)
		{
			_colorBlock = colorBlock;
		}

		protected override StatePalette GenerateValue(string target)
		{
			return _colorBlock.GetPalette(target) ?? new StatePalette(target, null, (string k, Color? f) => MissingColor);
		}
	}

	private const string FallbackThemeID = "dark";

	private const string ColorKeyFragment = "_COLOR";

	private const string PaletteKeyFragment = "_PALETTE";

	private static readonly Color MissingColor = Color.FromRgb(250, 17, 237);

	private ThemeBlock? _primaryTheme;

	private ThemeBlock? _fallbackTheme;

	private readonly BrushCache _brushes;

	private readonly PaletteCache _palettes;

	private readonly HashSet<string> _boundKeys = new HashSet<string>();

	public event PropertyChangedEventHandler? PropertyChanged;

	public Theme(string themeID)
	{
		LoadThemeBlocks(themeID);
		_brushes = new BrushCache(this);
		_palettes = new PaletteCache(this);
	}

	private void LoadThemeBlocks(string themeID)
	{
		_primaryTheme = new ThemeBlock(themeID, GetPalette, GetColor);
		_fallbackTheme = ((!themeID.Equals("dark", StringComparison.OrdinalIgnoreCase)) ? new ThemeBlock("dark", GetPalette, GetColor) : null);
	}

	private void OnPropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	public override bool TryGetMember(GetMemberBinder binder, out object result)
	{
		string name = binder.Name;
		if (name.EndsWith("_COLOR", StringComparison.OrdinalIgnoreCase))
		{
			result = GetColor(name.Substring(0, name.Length - "_COLOR".Length), null);
		}
		else if (name.EndsWith("_PALETTE", StringComparison.OrdinalIgnoreCase))
		{
			result = _palettes.Get(name.Substring(0, name.Length - "_PALETTE".Length));
		}
		else
		{
			result = _brushes.Get(name);
		}
		if (!_boundKeys.Contains(name))
		{
			_boundKeys.Add(name);
		}
		return true;
	}

	private Color GetColor(string key, Color? fallbackColor = null)
	{
		return _primaryTheme?.GetColor(key) ?? _fallbackTheme?.GetColor(key) ?? fallbackColor ?? MissingColor;
	}

	private StatePalette? GetPalette(string key)
	{
		object obj = _primaryTheme?.GetPalette(key);
		if (obj == null)
		{
			ThemeBlock? fallbackTheme = _fallbackTheme;
			if (fallbackTheme == null)
			{
				return null;
			}
			obj = fallbackTheme.GetPalette(key);
		}
		return (StatePalette?)obj;
	}

	public void ChangeThemeID(string themeID)
	{
		string[] source = _boundKeys.ToArray();
		LoadThemeBlocks(themeID);
		_brushes.Clear();
		_boundKeys.Clear();
		source.ForEach(OnPropertyChanged);
	}
}
