using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Markup;
using Pro.Common.Utility;

namespace Pro.UI.Controls;

[ContentProperty("Child")]
public class ProxyPopup<T> : FrameworkElement, IPopup where T : FrameworkElement, IPopup, new()
{
	private readonly T _popup = new T();

	public static readonly DependencyProperty ChildProperty = DependencyProperty.Register("Child", typeof(UIElement), typeof(ProxyPopup<T>));

	public static readonly DependencyProperty AllowsTransparencyProperty = DependencyProperty.Register("AllowsTransparency", typeof(bool), typeof(ProxyPopup<T>));

	public static readonly DependencyProperty HorizontalOffsetProperty = DependencyProperty.Register("HorizontalOffset", typeof(double), typeof(ProxyPopup<T>));

	public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(ProxyPopup<T>));

	public static readonly DependencyProperty PlacementProperty = DependencyProperty.Register("Placement", typeof(PlacementMode), typeof(ProxyPopup<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)PlacementMode.Bottom));

	public static readonly DependencyProperty PlacementTargetProperty = DependencyProperty.Register("PlacementTarget", typeof(UIElement), typeof(ProxyPopup<T>));

	public static readonly DependencyProperty StaysOpenProperty = DependencyProperty.Register("StaysOpen", typeof(bool), typeof(ProxyPopup<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty VerticalOffsetProperty = DependencyProperty.Register("VerticalOffset", typeof(double), typeof(ProxyPopup<T>));

	public static readonly DependencyProperty SendKeyEventsToMainWindowProperty = DependencyProperty.Register("SendKeyEventsToMainWindow", typeof(bool), typeof(ProxyPopup<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

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

	public bool AllowsTransparency
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowsTransparencyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowsTransparencyProperty, (object)value);
		}
	}

	public double HorizontalOffset
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(HorizontalOffsetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HorizontalOffsetProperty, (object)value);
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

	public PlacementMode Placement
	{
		get
		{
			return (PlacementMode)((DependencyObject)this).GetValue(PlacementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PlacementProperty, (object)value);
		}
	}

	public UIElement? PlacementTarget
	{
		get
		{
			return (UIElement)((DependencyObject)this).GetValue(PlacementTargetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PlacementTargetProperty, (object)value);
		}
	}

	public bool StaysOpen
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(StaysOpenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StaysOpenProperty, (object)value);
		}
	}

	public double VerticalOffset
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(VerticalOffsetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(VerticalOffsetProperty, (object)value);
		}
	}

	public bool SendKeyEventsToMainWindow
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SendKeyEventsToMainWindowProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SendKeyEventsToMainWindowProperty, (object)value);
		}
	}

	protected internal T PopupControl => _popup;

	public event EventHandler Closed
	{
		add
		{
			_popup.Closed += value;
		}
		remove
		{
			_popup.Closed -= value;
		}
	}

	public event EventHandler Opened
	{
		add
		{
			_popup.Opened += value;
		}
		remove
		{
			_popup.Opened -= value;
		}
	}

	public ProxyPopup()
	{
		SetupPopupBinding(Popup.ChildProperty);
		SetupPopupBinding(Popup.AllowsTransparencyProperty);
		SetupPopupBinding(FrameworkElement.HorizontalAlignmentProperty);
		SetupPopupBinding(Popup.HorizontalOffsetProperty);
		SetupPopupBinding(Popup.IsOpenProperty);
		SetupPopupBinding(Popup.PlacementProperty);
		SetupPopupBinding(Popup.PlacementTargetProperty);
		SetupPopupBinding(Popup.StaysOpenProperty);
		SetupPopupBinding(FrameworkElement.VerticalAlignmentProperty);
		SetupPopupBinding(Popup.VerticalOffsetProperty);
		SetupPopupBinding(FrameworkElement.WidthProperty);
		SetupPopupBinding(FrameworkElement.HeightProperty);
		SetupPopupBinding(FrameworkElement.MinWidthProperty);
		SetupPopupBinding(FrameworkElement.MaxWidthProperty);
		SetupPopupBinding(FrameworkElement.MinHeightProperty);
		SetupPopupBinding(FrameworkElement.MaxHeightProperty);
		SetupPopupBinding(SendKeyEventsToMainWindowProperty);
	}

	protected virtual bool AllowBind(DependencyProperty dp)
	{
		return true;
	}

	private void SetupPopupBinding(DependencyProperty dp)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		if (AllowBind(dp))
		{
			FieldInfo field = ReflectionHelper.GetField<T>(dp.Name + "Property", BindingFlags.Static | BindingFlags.Public);
			if (field != null && field.FieldType == typeof(DependencyProperty))
			{
				SetupBinding((DependencyProperty)field.GetValue(null));
			}
		}
	}

	protected void SetupBinding(DependencyProperty? dp)
	{
		if (dp != null)
		{
			_popup.SetBinding(dp, new Binding(dp.Name)
			{
				Source = this,
				Mode = BindingMode.TwoWay
			});
		}
	}

	HorizontalAlignment IPopup.get_HorizontalAlignment()
	{
		return base.HorizontalAlignment;
	}

	void IPopup.set_HorizontalAlignment(HorizontalAlignment value)
	{
		base.HorizontalAlignment = value;
	}

	VerticalAlignment IPopup.get_VerticalAlignment()
	{
		return base.VerticalAlignment;
	}

	void IPopup.set_VerticalAlignment(VerticalAlignment value)
	{
		base.VerticalAlignment = value;
	}

	double IPopup.get_Width()
	{
		return base.Width;
	}

	void IPopup.set_Width(double value)
	{
		base.Width = value;
	}

	double IPopup.get_Height()
	{
		return base.Height;
	}

	void IPopup.set_Height(double value)
	{
		base.Height = value;
	}

	double IPopup.get_MinWidth()
	{
		return base.MinWidth;
	}

	void IPopup.set_MinWidth(double value)
	{
		base.MinWidth = value;
	}

	double IPopup.get_MaxWidth()
	{
		return base.MaxWidth;
	}

	void IPopup.set_MaxWidth(double value)
	{
		base.MaxWidth = value;
	}

	double IPopup.get_MinHeight()
	{
		return base.MinHeight;
	}

	void IPopup.set_MinHeight(double value)
	{
		base.MinHeight = value;
	}

	double IPopup.get_MaxHeight()
	{
		return base.MaxHeight;
	}

	void IPopup.set_MaxHeight(double value)
	{
		base.MaxHeight = value;
	}
}
