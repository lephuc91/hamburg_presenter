using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Markup;
using Pro.UI.Components;
using Pro.UI.Controls.Windowing;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.Templates;

public partial class NewThemeDialog : ChromedWindow, IComponentConnector
{
	private static readonly DependencyProperty ThemesProperty = DependencyProperty.Register("Themes", typeof(IEnumerable<string>), typeof(NewThemeDialog));

	private static readonly DependencyProperty SaveNewThemeCommandProperty = DependencyProperty.Register("SaveNewThemeCommand", typeof(ICommand<string>), typeof(NewThemeDialog));

	private IEnumerable<string> Themes
	{
		get
		{
			return (IEnumerable<string>)((DependencyObject)this).GetValue(ThemesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThemesProperty, (object)value);
		}
	}

	private ICommand<string> SaveNewThemeCommand
	{
		get
		{
			return (ICommand<string>)((DependencyObject)this).GetValue(SaveNewThemeCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SaveNewThemeCommandProperty, (object)value);
		}
	}

	public NewThemeDialog(ThemeCollection themes, ICommand<string> saveCommand)
	{
		Themes = themes.Select((Theme t) => t.Name).ToArray();
		SaveNewThemeCommand = saveCommand;
		InitializeComponent();
		base.Loaded += delegate
		{
			themeSelector.Focus();
		};
	}

	private void Save_Click(object? sender, RoutedEventArgs e)
	{
		base.DialogResult = true;
	}
}
