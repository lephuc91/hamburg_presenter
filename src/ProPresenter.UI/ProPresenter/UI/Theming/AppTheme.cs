using System;
using System.ComponentModel;
using Pro.Common.Utility;
using Pro.UI.Theming;
using ProPresenter.DO.Settings;

namespace ProPresenter.UI.Theming;

public static class AppTheme
{
	private const string DefaultTheme = "dark";

	private static Theme _activeBlock;

	private static IApp? _app;

	public static dynamic Active => _activeBlock;

	public static event Action? ThemeChanged;

	static AppTheme()
	{
		_activeBlock = new Theme("dark");
	}

	public static void Initialize(IApp app)
	{
		_app = app;
		string text = _app.ActiveTheme.GetEnumDescription();
		if (string.IsNullOrWhiteSpace(text))
		{
			text = "dark";
		}
		_activeBlock = new Theme(text);
		_app.PropertyChanged += OnSettingsPropertyChanged;
	}

	private static void OnSettingsPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "ActiveTheme")
		{
			_activeBlock?.ChangeThemeID(_app?.ActiveTheme.GetEnumDescription() ?? string.Empty);
			AppTheme.ThemeChanged?.Invoke();
		}
	}
}
