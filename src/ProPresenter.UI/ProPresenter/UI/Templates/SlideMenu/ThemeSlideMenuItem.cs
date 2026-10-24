using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Collections;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.Templates.SlideMenu;

public partial class ThemeSlideMenuItem : MenuItem, IComponentConnector
{
	private const string WithThemesKey = "WithThemes";

	private const string NoThemesKey = "NoThemes";

	private bool _dataLoaded;

	public static readonly DependencyProperty FetchRecentlyAppliedThemeDataCommandProperty = DependencyProperty.Register("FetchRecentlyAppliedThemeDataCommand", typeof(ICommand), typeof(ThemeSlideMenuItem), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty FetchMediaActionEnabledCommandProperty = DependencyProperty.Register("FetchMediaActionEnabledCommand", typeof(ICommand<ThemePickerGroup>), typeof(ThemeSlideMenuItem), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty ContextGroupProperty = DependencyProperty.Register("ContextGroup", typeof(ThemePickerGroup), typeof(ThemeSlideMenuItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)ThemePickerGroup.Presentation));

	public static readonly DependencyProperty RecentThemesProperty = DependencyProperty.Register("RecentThemes", typeof(ObservableCollection<Theme>), typeof(ThemeSlideMenuItem), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty SelectTemplateCommandProperty = DependencyProperty.Register("SelectTemplateCommand", typeof(ICommand<TemplateSlide>), typeof(ThemeSlideMenuItem));

	public static readonly DependencyProperty ThemeTreeProperty = DependencyProperty.Register("ThemeTree", typeof(ThemeContainer), typeof(ThemeSlideMenuItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(ThemeTreePropertyChanged)));

	private static readonly DependencyProperty ThemesProperty = DependencyProperty.Register("Themes", typeof(IEnumerable<ThemeContainer>), typeof(ThemeSlideMenuItem));

	private static readonly DependencyProperty SubFoldersProperty = DependencyProperty.Register("SubFolders", typeof(IEnumerable<ThemeContainer>), typeof(ThemeSlideMenuItem));

	public static readonly DependencyProperty CanAddNewThemeProperty = DependencyProperty.Register("CanAddNewTheme", typeof(bool), typeof(ThemeSlideMenuItem), new PropertyMetadata((object)true));

	public ICommand<TemplateSlide> SelectTemplateCommand
	{
		get
		{
			return (ICommand<TemplateSlide>)((DependencyObject)this).GetValue(SelectTemplateCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectTemplateCommandProperty, (object)value);
		}
	}

	public ThemeContainer ThemeTree
	{
		get
		{
			return (ThemeContainer)((DependencyObject)this).GetValue(ThemeTreeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThemeTreeProperty, (object)value);
		}
	}

	private IEnumerable<ThemeContainer> Themes
	{
		get
		{
			return (IEnumerable<ThemeContainer>)((DependencyObject)this).GetValue(ThemesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThemesProperty, (object)value);
		}
	}

	private IEnumerable<ThemeContainer> SubFolders
	{
		get
		{
			return (IEnumerable<ThemeContainer>)((DependencyObject)this).GetValue(SubFoldersProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SubFoldersProperty, (object)value);
		}
	}

	public ObservableCollection<Theme> RecentThemes
	{
		get
		{
			return (ObservableCollection<Theme>)((DependencyObject)this).GetValue(RecentThemesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RecentThemesProperty, (object)value);
		}
	}

	public ICommand FetchRecentlyAppliedThemeDataCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(FetchRecentlyAppliedThemeDataCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FetchRecentlyAppliedThemeDataCommandProperty, (object)value);
		}
	}

	public ICommand<ThemePickerGroup> FetchMediaActionEnabledCommand
	{
		get
		{
			return (ICommand<ThemePickerGroup>)((DependencyObject)this).GetValue(FetchMediaActionEnabledCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FetchMediaActionEnabledCommandProperty, (object)value);
		}
	}

	public ThemePickerGroup ContextGroup
	{
		get
		{
			return (ThemePickerGroup)((DependencyObject)this).GetValue(ContextGroupProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ContextGroupProperty, (object)value);
		}
	}

	public bool CanAddNewTheme
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanAddNewThemeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanAddNewThemeProperty, (object)value);
		}
	}

	private static void ThemeTreePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (!(d is ThemeSlideMenuItem themeSlideMenuItem))
		{
			return;
		}
		ThemeContainer themeContainer = (ThemeContainer)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		if (themeContainer.Children.Empty())
		{
			themeSlideMenuItem.ItemsSource = (CompositeCollection)themeSlideMenuItem.Resources["NoThemes"];
			((DependencyObject)themeSlideMenuItem).SetCurrentValue(ThemesProperty, (object)Array.Empty<ThemeContainer>());
			((DependencyObject)themeSlideMenuItem).SetCurrentValue(SubFoldersProperty, (object)Array.Empty<ThemeContainer>());
			return;
		}
		themeSlideMenuItem.ItemsSource = (CompositeCollection)themeSlideMenuItem.Resources["WithThemes"];
		((DependencyObject)themeSlideMenuItem).SetCurrentValue(ThemesProperty, (object)themeContainer?.Children.Where((ThemeContainer c) => c.Children.Empty()).ToArray());
		((DependencyObject)themeSlideMenuItem).SetCurrentValue(SubFoldersProperty, (object)themeContainer?.Children.Where((ThemeContainer c) => !c.Children.Empty()).ToArray());
	}

	public ThemeSlideMenuItem()
	{
		InitializeComponent();
		RecentThemes = new ObservableCollection<Theme>();
		((DependencyObject?)(object)this).Bind(ThemeTreeProperty, base.DataContext, "ThemeTree");
		((DependencyObject?)(object)this).Bind(RecentThemesProperty, base.DataContext, "RecentThemes");
		((DependencyObject?)(object)this).Bind(FetchRecentlyAppliedThemeDataCommandProperty, base.DataContext, "FetchRecentlyAppliedThemeDataCommand");
		((DependencyObject?)(object)this).Bind(FetchMediaActionEnabledCommandProperty, base.DataContext, "FetchMediaActionEnabledCommand");
		base.SubmenuOpened += OnMenuOpened;
		base.SubmenuClosed += OnMenuClosed;
	}

	private void OnMenuClosed(object? sender, RoutedEventArgs e)
	{
		if (e.Source == e.OriginalSource)
		{
			_dataLoaded = false;
		}
	}

	private void OnMenuOpened(object? sender, RoutedEventArgs e)
	{
		if (!_dataLoaded)
		{
			FetchRecentlyAppliedThemeDataCommand?.Invoke();
			FetchMediaActionEnabledCommand?.Invoke(ContextGroup);
			_dataLoaded = true;
		}
	}
}
