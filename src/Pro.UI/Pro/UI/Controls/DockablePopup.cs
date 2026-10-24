using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using Pro.Common.Mathematics;
using Pro.UI.Components;
using Pro.UI.Controls.Windowing;
using Pro.UI.Utility;

namespace Pro.UI.Controls;

public class DockablePopup : ProxyPopup<AnchoredPopup>
{
	private Vector2<double> _lastContentSize = new Vector2<double>(double.NaN);

	private readonly Lazy<Window> _breakoutWindow;

	public static readonly DependencyProperty IsDockedProperty;

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

	internal Window BreakoutWindow => _breakoutWindow.Value;

	private static void OnIsDockedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((DockablePopup)(object)d).IsDockedChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnChildChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((DockablePopup)(object)d).ChildChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as UIElement, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as UIElement);
	}

	private static void OnIsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((DockablePopup)(object)d).IsOpenChanged();
	}

	static DockablePopup()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		IsDockedProperty = DependencyProperty.Register("IsDocked", typeof(bool), typeof(DockablePopup), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, new PropertyChangedCallback(OnIsDockedChanged)));
		ProxyPopup<AnchoredPopup>.ChildProperty.OverrideMetadata(typeof(DockablePopup), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnChildChanged)));
		ProxyPopup<AnchoredPopup>.IsOpenProperty.OverrideMetadata(typeof(DockablePopup), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(OnIsOpenChanged)));
	}

	public DockablePopup()
	{
		_breakoutWindow = new Lazy<Window>(delegate
		{
			ChromedWindow obj = new ChromedWindow
			{
				WindowStartupLocation = WindowStartupLocation.CenterOwner
			};
			WindowHelper.SetChildOf(obj, WindowAttachedTo.MainWindow);
			WindowHelper.SetSendKeyEventsToMainWindow(obj, value: true);
			obj.Closing += OnBreakoutWindowClosing;
			return obj;
		});
	}

	public void ToggleDock()
	{
		((DependencyObject)this).SetValue(IsDockedProperty, (object)(!IsDocked));
	}

	protected override bool AllowBind(DependencyProperty dp)
	{
		return dp != Popup.IsOpenProperty;
	}

	private void IsDockedChanged(bool isDocked)
	{
		if (isDocked)
		{
			_lastContentSize.X = BreakoutWindow.ActualWidth;
			_lastContentSize.Y = BreakoutWindow.ActualHeight;
			UIElement child = BreakoutWindow.Content as UIElement;
			BreakoutWindow.Content = null;
			base.Child = child;
			base.PopupControl.ParentWindow?.Activate();
		}
		else
		{
			_lastContentSize.X = (base.Width.IsReal() ? base.Width : ((base.Child as FrameworkElement)?.ActualWidth ?? double.NaN));
			_lastContentSize.Y = (base.Height.IsReal() ? base.Height : ((base.Child as FrameworkElement)?.ActualHeight ?? double.NaN));
			UIElement child2 = base.Child;
			base.Child = null;
			BreakoutWindow.Content = child2;
		}
		UpdateVisibility();
	}

	private void IsOpenChanged()
	{
		UpdateVisibility();
	}

	private void UpdateVisibility()
	{
		if (base.IsOpen)
		{
			if (!IsDocked)
			{
				base.PopupControl.IsOpen = false;
				ShowBreakout();
			}
			else
			{
				HideBreakout();
				base.PopupControl.IsOpen = true;
			}
		}
		else
		{
			HideBreakout();
			base.PopupControl.IsOpen = false;
		}
	}

	private void ShowBreakout()
	{
		if (!BreakoutWindow.IsVisible)
		{
			if (BreakoutWindow.Visibility == Visibility.Collapsed)
			{
				BreakoutWindow.Owner = base.PopupControl.ParentWindow ?? Application.Current?.MainWindow;
			}
			BreakoutWindow.MinWidth = base.MinWidth;
			BreakoutWindow.MaxWidth = base.MaxWidth;
			BreakoutWindow.MinHeight = base.MinHeight;
			BreakoutWindow.MaxHeight = base.MaxHeight;
			BreakoutWindow.Width = _lastContentSize.X;
			BreakoutWindow.Height = _lastContentSize.Y;
			BreakoutWindow.Show();
		}
	}

	private void HideBreakout()
	{
		if (BreakoutWindow.IsVisible)
		{
			BreakoutWindow.Hide();
			base.Width = _lastContentSize.X;
			base.Height = _lastContentSize.Y;
		}
	}

	private void OnBreakoutWindowClosing(object? sender, CancelEventArgs e)
	{
		e.Cancel = true;
		((DependencyObject)this).SetCurrentValue(ProxyPopup<AnchoredPopup>.IsOpenProperty, (object)false);
	}

	internal void ChildChanged(UIElement? oldChild, UIElement? newChild)
	{
		if (oldChild is IDialogDockableContent dialogDockableContent)
		{
			dialogDockableContent.ToggleDock -= ToggleDock;
		}
		if (newChild is IDialogDockableContent dialogDockableContent2)
		{
			dialogDockableContent2.ToggleDock += ToggleDock;
		}
	}
}
