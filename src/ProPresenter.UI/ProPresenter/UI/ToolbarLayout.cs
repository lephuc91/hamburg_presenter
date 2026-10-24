using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using Pro.UI.DependencyInjection;
using ProPresenter.DO.Analytics;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI;

public partial class ToolbarLayout : UserControl, IComponentConnector
{
	public static readonly DependencyProperty CaptureViewModelProperty = DependencyProperty.Register("CaptureViewModel", typeof(ICaptureVM), typeof(ToolbarLayout));

	public static readonly DependencyProperty RightColumnWidthProperty = DependencyProperty.Register("RightColumnWidth", typeof(GridLength), typeof(ToolbarLayout));

	public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(IToolBarVM), typeof(ToolbarLayout));

	private readonly IThemeAnalyiticEvents _themeAnalytics;

	public ICaptureVM? CaptureViewModel
	{
		get
		{
			return (ICaptureVM)((DependencyObject)this).GetValue(CaptureViewModelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CaptureViewModelProperty, (object)value);
		}
	}

	public GridLength RightColumnWidth
	{
		get
		{
			return (GridLength)((DependencyObject)this).GetValue(RightColumnWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RightColumnWidthProperty, (object)value);
		}
	}

	public IToolBarVM ViewModel
	{
		get
		{
			return (IToolBarVM)((DependencyObject)this).GetValue(ViewModelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ViewModelProperty, (object)value);
		}
	}

	public ToolbarLayout()
	{
		InitializeComponent();
		_themeAnalytics = UIServiceProvider.GetService<IThemeAnalyiticEvents>();
	}

	private void MainView_Unchecked(object? sender, RoutedEventArgs e)
	{
		if (sender is ToggleButton toggleButton)
		{
			toggleButton.GetBindingExpression(ToggleButton.IsCheckedProperty)?.UpdateTarget();
		}
	}

	private void OnOpenQuickSearchClick(object? sender, RoutedEventArgs e)
	{
		QuickSearchShownEvent.Publish(QuickSearchShownSource.ApplicationMenu);
	}

	private void OnOpenToolbarThemeMenu(object? sender, RoutedEventArgs e)
	{
		_themeAnalytics?.Shown();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
