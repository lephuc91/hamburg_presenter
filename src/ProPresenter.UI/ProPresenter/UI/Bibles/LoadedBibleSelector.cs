using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.Collections;
using Pro.UI.Utility;
using ProPresenter.DO.Bibles;

namespace ProPresenter.UI.Bibles;

public partial class LoadedBibleSelector : UserControl, IComponentConnector, IStyleConnector
{
	public static readonly DependencyProperty LoadedBiblesProperty = DependencyProperty.Register("LoadedBibles", typeof(LoadedBibleCollection), typeof(LoadedBibleSelector));

	public static readonly DependencyProperty TranslationsProperty = DependencyProperty.Register("Translations", typeof(BibleTranslationCollection), typeof(LoadedBibleSelector));

	public static readonly DependencyProperty CurrentBibleTranslationProperty = DependencyProperty.Register("CurrentBibleTranslation", typeof(BibleTranslation), typeof(LoadedBibleSelector));

	public LoadedBibleCollection? LoadedBibles
	{
		get
		{
			return (LoadedBibleCollection)((DependencyObject)this).GetValue(LoadedBiblesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LoadedBiblesProperty, (object)value);
		}
	}

	public BibleTranslationCollection? Translations
	{
		get
		{
			return (BibleTranslationCollection)((DependencyObject)this).GetValue(TranslationsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TranslationsProperty, (object)value);
		}
	}

	public BibleTranslation? CurrentBibleTranslation
	{
		get
		{
			return (BibleTranslation)((DependencyObject)this).GetValue(CurrentBibleTranslationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CurrentBibleTranslationProperty, (object)value);
		}
	}

	private IEnumerable<BibleTranslation>? CombinedTranslations => Translations?.All.Where((BibleTranslation t) => !string.IsNullOrWhiteSpace(t.Abbreviation));

	public LoadedBibleSelector()
	{
		InitializeComponent();
	}

	private void MenuItem_Click(object? sender, RoutedEventArgs e)
	{
		if ((sender as MenuItem)?.DataContext is BibleBase bibleBase && CurrentBibleTranslation != null)
		{
			CurrentBibleTranslation.Abbreviation = bibleBase.TrackingAbbreviation;
		}
	}

	private void ContextMenu_Opened(object? sender, RoutedEventArgs e)
	{
		if (!(sender is ContextMenu depObj))
		{
			return;
		}
		((DependencyObject)(object)depObj).FindVisualChildren<MenuItem>()?.ForEach(delegate(MenuItem m)
		{
			BibleBase bibleData = m.DataContext as BibleBase;
			m.IsEnabled = !(CombinedTranslations?.Any((BibleTranslation t) => t.Abbreviation?.Equals(bibleData?.TrackingAbbreviation, StringComparison.OrdinalIgnoreCase) ?? false) ?? false);
			m.IsChecked = bibleData?.TrackingAbbreviation.Equals(CurrentBibleTranslation?.Abbreviation, StringComparison.OrdinalIgnoreCase) ?? false;
		});
	}
}
