using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Components;

namespace ProPresenter.UI;

[ContentProperty("Child")]
public partial class DockableContent : UserControl, IDialogDockableContent, IDialogContent, IComponentConnector
{
	public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(DockableContent));

	public static readonly DependencyProperty ChildProperty = DependencyProperty.Register("Child", typeof(UIElement), typeof(DockableContent));

	public static readonly DependencyProperty SubHeaderProperty = DependencyProperty.Register("SubHeader", typeof(UIElement), typeof(DockableContent));

	public static readonly DependencyProperty AdditionalHeaderContentProperty = DependencyProperty.Register("AdditionalHeaderContent", typeof(UIElement), typeof(DockableContent));

	public string? Title
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TitleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TitleProperty, (object)value);
		}
	}

	public UIElement? Child
	{
		get
		{
			return (UIElement)((DependencyObject)this).GetValue(ChildProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ChildProperty, (object)value);
		}
	}

	public UIElement? SubHeader
	{
		get
		{
			return (UIElement)((DependencyObject)this).GetValue(SubHeaderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SubHeaderProperty, (object)value);
		}
	}

	public UIElement? AdditionalHeaderContent
	{
		get
		{
			return (UIElement)((DependencyObject)this).GetValue(AdditionalHeaderContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AdditionalHeaderContentProperty, (object)value);
		}
	}

	public event Action? ToggleDock;

	public event Action? Accept;

	public event Action? Cancel;

	public DockableContent()
	{
		InitializeComponent();
	}

	private void Close_Click(object? sender, RoutedEventArgs e)
	{
		this.Accept?.Invoke();
	}

	private void DockUndock_Click(object? sender, RoutedEventArgs e)
	{
		this.ToggleDock?.Invoke();
	}
}
