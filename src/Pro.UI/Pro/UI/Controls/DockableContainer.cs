using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.UI.Components;
using Pro.UI.Controls.Windowing;
using Pro.UI.Utility;

namespace Pro.UI.Controls;

[ContentProperty("Child")]
public class DockableContainer : FrameworkElement
{
	private readonly Lazy<ChromedWindow> _breakoutWindow;

	public static readonly DependencyProperty ChildProperty = DependencyProperty.Register("Child", typeof(UIElement), typeof(DockableContainer), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnChildChanged)));

	public static readonly DependencyProperty IsDockedProperty = DependencyProperty.Register("IsDocked", typeof(bool), typeof(DockableContainer), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, new PropertyChangedCallback(OnIsDockedChanged)));

	public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(DockableContainer), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(OnIsOpenChanged)));

	public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(DockableContainer), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)string.Empty));

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

	public bool IsDocked
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsDockedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsDockedProperty, (object)value);
		}
	}

	public bool IsOpen
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsOpenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsOpenProperty, (object)value);
		}
	}

	public string Title
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

	protected override int VisualChildrenCount
	{
		get
		{
			if (Child == null || !IsDocked)
			{
				return 0;
			}
			return 1;
		}
	}

	private ChromedWindow BreakoutWindow => _breakoutWindow.Value;

	private static void OnIsDockedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((DockableContainer)(object)d).IsDockedChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnIsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((DockableContainer)(object)d).UpdateVisibility();
	}

	private static void OnChildChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((DockableContainer)(object)d).OnChildChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as UIElement, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as UIElement);
	}

	public DockableContainer()
	{
		_breakoutWindow = new Lazy<ChromedWindow>(delegate
		{
			ChromedWindow chromedWindow = new ChromedWindow();
			chromedWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			chromedWindow.SetBinding(Window.TitleProperty, new Binding("Title")
			{
				Source = this
			});
			WindowHelper.SetChildOf(chromedWindow, WindowAttachedTo.MainWindow);
			chromedWindow.Closing += OnBreakoutWindowClosing;
			return chromedWindow;
		});
		UpdateVisibility();
	}

	public void ToggleDock()
	{
		((DependencyObject)this).SetValue(IsDockedProperty, (object)(!IsDocked));
	}

	protected override Visual? GetVisualChild(int index)
	{
		if (!IsDocked)
		{
			return null;
		}
		return Child;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		if (IsDocked)
		{
			Child?.Measure(availableSize);
		}
		return base.MeasureOverride(availableSize);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		if (IsDocked)
		{
			Child?.Arrange(new Rect(finalSize));
		}
		return base.ArrangeOverride(finalSize);
	}

	private void IsDockedChanged(bool isDocked)
	{
		if (isDocked)
		{
			BreakoutWindow.Content = null;
			if (Child != null)
			{
				AddVisualChild(Child);
			}
		}
		else
		{
			if (Child != null)
			{
				RemoveVisualChild(Child);
			}
			BreakoutWindow.Content = Child;
		}
		UpdateVisibility();
		InvalidateMeasure();
		InvalidateArrange();
	}

	private void UpdateVisibility()
	{
		if (IsOpen)
		{
			if (!IsDocked)
			{
				ShowBreakout();
				return;
			}
			HideBreakout();
			base.Visibility = Visibility.Visible;
		}
		else
		{
			HideBreakout();
			base.Visibility = Visibility.Collapsed;
		}
	}

	private void ShowBreakout()
	{
		if (!BreakoutWindow.IsVisible)
		{
			BreakoutWindow.MinWidth = base.MinWidth;
			BreakoutWindow.MaxWidth = base.MaxWidth;
			BreakoutWindow.MinHeight = base.MinHeight;
			BreakoutWindow.MaxHeight = base.MaxHeight;
			BreakoutWindow.Show();
		}
	}

	private void HideBreakout()
	{
		if (_breakoutWindow.IsValueCreated && BreakoutWindow.IsVisible)
		{
			BreakoutWindow.Hide();
		}
	}

	private void OnChildChanged(UIElement? oldChild, UIElement? newChild)
	{
		if (oldChild is IDialogDockableContent dialogDockableContent)
		{
			dialogDockableContent.ToggleDock -= ToggleDock;
		}
		if (newChild is IDialogDockableContent dialogDockableContent2)
		{
			dialogDockableContent2.ToggleDock += ToggleDock;
		}
		if (IsDocked)
		{
			if (oldChild != null)
			{
				RemoveVisualChild(oldChild);
			}
			if (newChild != null)
			{
				AddVisualChild(newChild);
			}
		}
		else
		{
			BreakoutWindow.Content = newChild;
		}
	}

	private void OnBreakoutWindowClosing(object? sender, CancelEventArgs e)
	{
		e.Cancel = true;
		IsOpen = false;
	}
}
