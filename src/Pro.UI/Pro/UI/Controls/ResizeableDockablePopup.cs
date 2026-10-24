using System;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Pro.UI.Controls;

public class ResizeableDockablePopup : ResizeablePopup<DockablePopup>
{
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

	private static void OnChildChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ResizeableDockablePopup)(object)d).PopupControl.ChildChanged((UIElement)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (UIElement)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	static ResizeableDockablePopup()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		IsDockedProperty = DependencyProperty.Register("IsDocked", typeof(bool), typeof(ResizeableDockablePopup), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		ProxyPopup<DockablePopup>.ChildProperty.OverrideMetadata(typeof(ResizeableDockablePopup), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnChildChanged)));
	}

	public ResizeableDockablePopup()
	{
		SetupBinding(DockablePopup.IsDockedProperty);
	}

	public void ToggleDock()
	{
		base.PopupControl.ToggleDock();
	}

	protected override void OnContentResized(DragDeltaEventArgs e)
	{
		if (IsDocked || !base.PopupControl.BreakoutWindow.IsVisible)
		{
			base.OnContentResized(e);
			return;
		}
		Window breakoutWindow = base.PopupControl.BreakoutWindow;
		breakoutWindow.Width = Math.Max(breakoutWindow.Width + e.HorizontalChange, 0.0);
		breakoutWindow.Height = Math.Max(breakoutWindow.Height + e.VerticalChange, 0.0);
	}
}
