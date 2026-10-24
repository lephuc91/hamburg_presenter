using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Utility;
using ProPresenter.DO.Bibles;
using ProPresenter.UI.ViewModels.Bibles;

namespace ProPresenter.UI.Bibles;

public partial class BiblesViewerHeader : UserControl, IComponentConnector, IStyleConnector
{
	private const int ProgressControlMaxWidth = 250;

	private Book? _currentBook;

	private Chapter? _currentChapter;

	public static readonly DependencyProperty ReferenceTextProperty = DependencyProperty.Register("ReferenceText", typeof(string), typeof(BiblesViewerHeader), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)string.Empty, new PropertyChangedCallback(OnReferenceTextChanged)));

	public string? ReferenceText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(ReferenceTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ReferenceTextProperty, (object)value);
		}
	}

	private IBiblesVM? BibleVM => base.DataContext as IBiblesVM;

	private static void OnReferenceTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((BiblesViewerHeader)(object)d).ReferenceTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateTarget();
	}

	public BiblesViewerHeader()
	{
		InitializeComponent();
	}

	private void SearchTextBox_PreviewKeyDown(object? sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)e.Key == 6)
		{
			SearchResultsPopup.IsOpen = true;
			BibleVM?.SearchKeywordCommand?.Execute(SearchTextBox.Text);
		}
	}

	private void ReferenceText_KeyDown(object? sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)e.Key == 6)
		{
			BibleVM?.UpdateReferenceTextCommand?.Invoke(ReferenceTextBox.Text);
		}
	}

	private void Book_PreviewClick(object? sender, MouseButtonEventArgs e)
	{
		if (sender is MenuItem { DataContext: Book dataContext })
		{
			_currentBook = dataContext;
		}
		if (e.OriginalSource is FrameworkElement frameworkElement && frameworkElement.DataContext is Book)
		{
			BibleVM?.SelectBookCommand?.Invoke(new SelectBibleReferenceCommandParameter(_currentBook, null, null));
		}
	}

	private void Chapter_PreviewClick(object? sender, MouseButtonEventArgs e)
	{
		if (sender is MenuItem { DataContext: Chapter dataContext })
		{
			_currentChapter = dataContext;
		}
		if (e.OriginalSource is FrameworkElement frameworkElement && frameworkElement.DataContext is Chapter)
		{
			BibleVM?.SelectChapterCommand?.Invoke(new SelectBibleReferenceCommandParameter(_currentBook, _currentChapter, null));
		}
	}

	private void Verse_PreviewClick(object? sender, MouseButtonEventArgs e)
	{
		Verse verse = null;
		if (sender is MenuItem { DataContext: Verse dataContext })
		{
			verse = dataContext;
		}
		if (e.OriginalSource is FrameworkElement frameworkElement && frameworkElement.DataContext is Verse)
		{
			BibleVM?.SelectVerseCommand?.Invoke(new SelectBibleReferenceCommandParameter(_currentBook, _currentChapter, verse));
		}
	}

	private void ReferenceTextBox_PreviewKeyDown(object? sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)e.Key == 3)
		{
			SearchTextBox.Focus();
			e.Handled = true;
		}
	}

	private void MainGrid_SizeChanged(object? sender, SizeChangedEventArgs e)
	{
		double num = ProgressColumn.ActualWidth - SearchTextBox.Margin.Right;
		ProgressControl.Width = ((num > 250.0) ? 250.0 : num);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
