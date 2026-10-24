using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Threading;
using Pro.Common.Mathematics;
using Pro.Common.Win32;
using Pro.UI.Components;
using Pro.UI.Controls.Windowing;
using Pro.UI.Utility;

namespace Pro.UI.Controls;

[ContentProperty("Child")]
public class AnchoredPopup : FrameworkElement, IPopup
{
	private sealed class PopupWindow : Window
	{
		private const string TemplateKey = "PopupWindowTemplate";

		private readonly AnchoredPopup _anchoredPopup;

		private readonly LogicalParentLiftAdapter _contentAdapter = new LogicalParentLiftAdapter();

		public PopupWindow(AnchoredPopup anchoredPopup)
		{
			_anchoredPopup = anchoredPopup;
			base.Template = (ControlTemplate)ResourceProvider.GetResource("PopupWindowTemplate");
			base.Content = _contentAdapter;
			base.WindowStyle = WindowStyle.None;
			base.ResizeMode = ResizeMode.NoResize;
			base.ShowInTaskbar = false;
			base.WindowStartupLocation = WindowStartupLocation.Manual;
			base.Title = "POPUP_WINDOW";
			bool flag = !_anchoredPopup.Width.IsReal();
			bool flag2 = !_anchoredPopup.Height.IsReal();
			if (flag && flag2)
			{
				base.SizeToContent = SizeToContent.WidthAndHeight;
			}
			else if (flag)
			{
				base.SizeToContent = SizeToContent.Width;
			}
			else if (flag2)
			{
				base.SizeToContent = SizeToContent.Height;
			}
			_contentAdapter.SetBinding(LogicalParentLiftAdapter.ContentProperty, new Binding(ChildProperty.Name)
			{
				Source = _anchoredPopup,
				Mode = BindingMode.TwoWay
			});
			SetupBinding(Window.AllowsTransparencyProperty, AnchoredPopup.AllowsTransparencyProperty);
			SetupBinding(FrameworkElement.WidthProperty, FrameworkElement.WidthProperty);
			SetupBinding(FrameworkElement.HeightProperty, FrameworkElement.HeightProperty);
			SetupBinding(FrameworkElement.MinWidthProperty, FrameworkElement.MinWidthProperty);
			SetupBinding(FrameworkElement.MaxWidthProperty, FrameworkElement.MaxWidthProperty);
			SetupBinding(FrameworkElement.MinHeightProperty, FrameworkElement.MinHeightProperty);
			SetupBinding(FrameworkElement.MaxHeightProperty, FrameworkElement.MaxHeightProperty);
			SetupBinding(Window.ShowActivatedProperty, AnchoredPopup.ShowActivatedProperty);
			SetupBinding(WindowHelper.SendKeyEventsToMainWindowProperty, SendKeyEventsToMainWindowProperty);
		}

		private void SetupBinding(DependencyProperty windowDP, DependencyProperty popupDP)
		{
			SetBinding(windowDP, new Binding(popupDP.Name)
			{
				Source = _anchoredPopup,
				Mode = BindingMode.TwoWay
			});
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			e.Cancel = true;
			_anchoredPopup.ParentWindow?.Close();
		}

		protected override void OnActivated(EventArgs e)
		{
			_anchoredPopup.PopupActivated?.Invoke(_anchoredPopup, EventArgs.Empty);
		}

		protected override void OnDeactivated(EventArgs e)
		{
			if (!_anchoredPopup.StaysOpen)
			{
				_anchoredPopup.ClosePopup();
			}
			_anchoredPopup.PopupDeactivated?.Invoke(_anchoredPopup, EventArgs.Empty);
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Invalid comparison between Unknown and I4
			if ((int)e.Key == 13)
			{
				_anchoredPopup.ClosePopup();
			}
			base.OnKeyUp(e);
		}
	}

	private const string BypassLayoutPoliciesPropertyName = "BypassLayoutPolicies";

	private static PropertyInfo? _bypassLayoutPoliciesPropertyInfo;

	private FrameworkElement? _target;

	private PopupWindow? _popupWindow;

	private nint _popupWindowHandle = IntPtr.Zero;

	private Window? _parentWindow;

	private nint _parentWindowHandle = IntPtr.Zero;

	public static readonly DependencyProperty ChildProperty;

	public static readonly DependencyProperty AllowsTransparencyProperty;

	public static readonly DependencyProperty HorizontalOffsetProperty;

	public static readonly DependencyProperty IsOpenProperty;

	public static readonly DependencyProperty PlacementProperty;

	public static readonly DependencyProperty PlacementTargetProperty;

	public static readonly DependencyProperty StaysOpenProperty;

	public static readonly DependencyProperty VerticalOffsetProperty;

	public static readonly DependencyProperty ShowActivatedProperty;

	public static readonly DependencyProperty ActivateParentOnCloseProperty;

	public static readonly DependencyProperty SendKeyEventsToMainWindowProperty;

	public static readonly DependencyProperty ShareParentSpaceProperty;

	protected internal FrameworkElement? Target => _target;

	protected internal Window? ParentWindow => _parentWindow;

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

	public bool ShowActivated
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowActivatedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowActivatedProperty, (object)value);
		}
	}

	public bool ActivateParentOnClose
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ActivateParentOnCloseProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActivateParentOnCloseProperty, (object)value);
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

	public bool ShareParentSpace
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShareParentSpaceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShareParentSpaceProperty, (object)value);
		}
	}

	public event EventHandler? Closed;

	public event EventHandler? Opened;

	public event EventHandler? PopupActivated;

	public event EventHandler? PopupDeactivated;

	private static void OnChildChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((AnchoredPopup)(object)d).ChildChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as UIElement, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as UIElement);
	}

	private static void OnIsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((AnchoredPopup)(object)d).IsOpenChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnPlacementTargetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((AnchoredPopup)(object)d).PlacementTargetChanged((UIElement)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnHorizontalAlignmentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((AnchoredPopup)(object)d).UpdatePosition();
	}

	private static void OnVerticalAlignmentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((AnchoredPopup)(object)d).UpdatePosition();
	}

	static AnchoredPopup()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected O, but got Unknown
		ChildProperty = DependencyProperty.Register("Child", typeof(UIElement), typeof(AnchoredPopup), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnChildChanged)));
		AllowsTransparencyProperty = DependencyProperty.Register("AllowsTransparency", typeof(bool), typeof(AnchoredPopup));
		HorizontalOffsetProperty = DependencyProperty.Register("HorizontalOffset", typeof(double), typeof(AnchoredPopup));
		IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(AnchoredPopup), (PropertyMetadata)(object)new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnIsOpenChanged)));
		PlacementProperty = DependencyProperty.Register("Placement", typeof(PlacementMode), typeof(AnchoredPopup), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)PlacementMode.Bottom));
		PlacementTargetProperty = DependencyProperty.Register("PlacementTarget", typeof(UIElement), typeof(AnchoredPopup), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnPlacementTargetChanged)));
		StaysOpenProperty = DependencyProperty.Register("StaysOpen", typeof(bool), typeof(AnchoredPopup));
		VerticalOffsetProperty = DependencyProperty.Register("VerticalOffset", typeof(double), typeof(AnchoredPopup));
		ShowActivatedProperty = DependencyProperty.Register("ShowActivated", typeof(bool), typeof(AnchoredPopup), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		ActivateParentOnCloseProperty = DependencyProperty.Register("ActivateParentOnClose", typeof(bool), typeof(AnchoredPopup), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		SendKeyEventsToMainWindowProperty = DependencyProperty.Register("SendKeyEventsToMainWindow", typeof(bool), typeof(AnchoredPopup), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		ShareParentSpaceProperty = DependencyProperty.Register("ShareParentSpace", typeof(bool), typeof(AnchoredPopup));
		_bypassLayoutPoliciesPropertyInfo = typeof(FrameworkElement).GetProperty("BypassLayoutPolicies", BindingFlags.Instance | BindingFlags.NonPublic);
		FrameworkElement.HorizontalAlignmentProperty.OverrideMetadata(typeof(AnchoredPopup), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)HorizontalAlignment.Stretch, new PropertyChangedCallback(OnHorizontalAlignmentChanged)));
		FrameworkElement.VerticalAlignmentProperty.OverrideMetadata(typeof(AnchoredPopup), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)VerticalAlignment.Stretch, new PropertyChangedCallback(OnVerticalAlignmentChanged)));
	}

	public AnchoredPopup()
	{
		_bypassLayoutPoliciesPropertyInfo?.SetValue(this, true);
	}

	public static bool IsPopupWindow(Window window)
	{
		return window is PopupWindow;
	}

	protected virtual void OnClosed(EventArgs e)
	{
		this.Closed?.Invoke(this, e);
	}

	protected virtual void OnOpened(EventArgs e)
	{
		this.Opened?.Invoke(this, e);
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		return Vector2<double>.Zero;
	}

	private void OnTargetUpdated()
	{
		if (_parentWindow != null)
		{
			_parentWindow.SizeChanged -= OnSizeChanged;
			_parentWindow.LocationChanged -= OnPositionChanged;
			_parentWindow.Closing -= OnWindowClosing;
		}
		_parentWindow = ((_target != null) ? (Window.GetWindow((DependencyObject)(object)_target) ?? ((DependencyObject)(object)_target).FindVisualParent<Window>()) : null);
		if (_parentWindow != null)
		{
			_parentWindow.SizeChanged += OnSizeChanged;
			_parentWindow.LocationChanged += OnPositionChanged;
			_parentWindow.Closing += OnWindowClosing;
			_parentWindowHandle = new WindowInteropHelper(_parentWindow).EnsureHandle();
		}
		else
		{
			_parentWindowHandle = IntPtr.Zero;
		}
	}

	private void ChildChanged(UIElement? oldChild, UIElement? newChild)
	{
		if (oldChild is FrameworkElement frameworkElement)
		{
			RemoveLogicalChild(frameworkElement);
			frameworkElement.SizeChanged -= OnSizeChanged;
			if (frameworkElement is IDialogContent dialogContent)
			{
				dialogContent.Accept -= ClosePopup;
				dialogContent.Cancel -= ClosePopup;
			}
		}
		if (newChild is FrameworkElement frameworkElement2)
		{
			AddLogicalChild(frameworkElement2);
			frameworkElement2.SizeChanged += OnSizeChanged;
			if (frameworkElement2 is IDialogContent dialogContent2)
			{
				dialogContent2.Accept += ClosePopup;
				dialogContent2.Cancel += ClosePopup;
			}
		}
	}

	private void IsOpenChanged(bool isOpen)
	{
		if (_popupWindow == null)
		{
			_popupWindow = new PopupWindow(this);
			_popupWindowHandle = new WindowInteropHelper(_popupWindow).EnsureHandle();
		}
		if (isOpen)
		{
			OnTargetUpdated();
			OnOpened(EventArgs.Empty);
			_popupWindow.Owner = _parentWindow;
			_popupWindow.Show();
			UpdatePosition(initOpen: true);
			if (!ShowActivated)
			{
				WindowsFunctions.SetWindowPos(_popupWindowHandle, IntPtr.Zero, 0, 0, 0, 0, SWP.NOSIZE | SWP.NOMOVE | SWP.NOACTIVATE);
			}
		}
		else
		{
			((DispatcherObject)this).Dispatcher.InvokeAsync((Action)delegate
			{
				_popupWindow.Hide();
			});
			OnClosed(EventArgs.Empty);
			if (ActivateParentOnClose)
			{
				_parentWindow?.Activate();
			}
		}
	}

	private void PlacementTargetChanged(UIElement newTarget)
	{
		if (_target != null)
		{
			_target.SizeChanged -= OnSizeChanged;
			_target.LayoutUpdated -= OnLayoutUpdated;
		}
		_target = newTarget as FrameworkElement;
		if (_target != null)
		{
			_target.SizeChanged += OnSizeChanged;
			_target.LayoutUpdated += OnLayoutUpdated;
		}
		OnTargetUpdated();
	}

	private void OnWindowClosing(object? sender, CancelEventArgs e)
	{
		if (IsOpen)
		{
			(_parentWindow?.Owner ?? Application.Current?.MainWindow)?.Focus();
			ClosePopup();
		}
	}

	private void ClosePopup()
	{
		((DependencyObject)this).SetCurrentValue(IsOpenProperty, (object)false);
	}

	private void OnSizeChanged(object? sender, SizeChangedEventArgs e)
	{
		UpdatePosition();
	}

	private void OnLayoutUpdated(object? sender, EventArgs e)
	{
		UpdatePosition();
	}

	private void OnPositionChanged(object? sender, EventArgs e)
	{
		UpdatePosition();
	}

	protected virtual void UpdatePosition(bool initOpen = false)
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		if (_popupWindow == null || _parentWindow == null || !IsOpen)
		{
			return;
		}
		nint hMonitor = WindowsFunctions.MonitorFromWindow(_parentWindowHandle, MONITOR.DEFAULTTOPRIMARY);
		MONITORINFO lpmi = MONITORINFO.Empty;
		WindowsFunctions.GetMonitorInfoW(hMonitor, ref lpmi);
		WindowsFunctions.GetDpiForMonitor(hMonitor, MDT.EFFECTIVE_DPI, out var dpiX, out var dpiY);
		Vector2<double> scale = new Vector2<double>(dpiX, dpiY) / 96.0;
		Rect<double> screenBounds = (Rect<double>)lpmi.RcWork;
		screenBounds.Position = screenBounds.Position.ComponentwiseQuotient(scale);
		screenBounds.Size = screenBounds.Size.ComponentwiseQuotient(scale);
		Vector2<double> popupSize = (Vector2<double>)(Child?.RenderSize ?? ((Size)Vector2<double>.Zero));
		Vector2<double> targetSize = (Vector2<double>)(Target?.RenderSize ?? ((Size)Vector2<double>.Zero));
		Vector2<double> vector = (Vector2<double>)(PlacementTarget?.TranslatePoint(Vector2<double>.Zero, _parentWindow) ?? ((Point)Vector2<double>.Zero));
		WindowsFunctions.GetWindowRect(_parentWindowHandle, out var lpRect);
		Vector2<double> vector2 = ((Rect<double>)lpRect).TopLeft.ComponentwiseQuotient(scale);
		Vector2<double> vector3 = new Vector2<double>(GetHorizontalOffset(popupSize, targetSize), GetVerticalOffset(popupSize, targetSize));
		Vector2<double> popupPosition = vector2 + vector + vector3;
		switch (Placement)
		{
		case PlacementMode.Top:
			adjustY(0.0 - popupSize.Y, targetSize.Y);
			break;
		case PlacementMode.Left:
			adjustX(0.0 - popupSize.X, targetSize.X);
			break;
		case PlacementMode.Bottom:
			adjustY(targetSize.Y, 0.0 - popupSize.Y);
			break;
		case PlacementMode.Right:
			adjustX(targetSize.X, 0.0 - popupSize.X);
			break;
		}
		if (ShareParentSpace && initOpen && !screenBounds.Contains(new Rect<double>(popupPosition, popupSize)))
		{
			double num = _parentWindow.Top;
			double num2 = _parentWindow.Left;
			double width = _parentWindow.Width;
			double height = _parentWindow.Height;
			switch (Placement)
			{
			case PlacementMode.Top:
				num = popupSize.Y - _parentWindow.Top;
				break;
			case PlacementMode.Left:
				num2 = popupSize.X - _parentWindow.Left;
				break;
			case PlacementMode.Bottom:
			{
				double num5 = _parentWindow.Top + _parentWindow.ActualHeight + popupSize.Y - screenBounds.Height;
				double num6 = _parentWindow.ActualHeight - num5;
				if (num6 > 0.0)
				{
					height = num6;
				}
				else
				{
					num -= num5;
				}
				break;
			}
			case PlacementMode.Right:
			{
				double num3 = _parentWindow.Left + _parentWindow.ActualWidth + popupSize.X - screenBounds.Width;
				double num4 = _parentWindow.ActualWidth - num3;
				if (num4 > 0.0)
				{
					width = num4;
				}
				else
				{
					num2 -= num3;
				}
				break;
			}
			}
			_parentWindow.Top = num;
			_parentWindow.Left = num2;
			_parentWindow.Width = width;
			_parentWindow.Height = height;
		}
		Vector2<int> vector4 = popupPosition.ComponentwiseProduct(scale).Ceiling().Cast<int>();
		WindowsFunctions.SetWindowPos(_popupWindowHandle, IntPtr.Zero, vector4.X, vector4.Y, 0, 0, SWP.NOSIZE | SWP.NOZORDER | SWP.NOACTIVATE);
		void adjustX(double a, double b)
		{
			popupPosition.X += a;
			if (doesIntersect(out var intersection2))
			{
				popupPosition.Y += intersection2.Height;
				if (intersection2.Width.Abs() > 0.1)
				{
					popupPosition.X += 0.0 - a + b;
				}
			}
		}
		void adjustY(double a, double b)
		{
			popupPosition.Y += a;
			if (doesIntersect(out var intersection3))
			{
				popupPosition.X += intersection3.Width;
				if (intersection3.Height.Abs() > 0.1)
				{
					popupPosition.Y += 0.0 - a + b;
				}
			}
		}
		bool doesIntersect(out Rect<double> intersection)
		{
			Rect<double> targetRect = new Rect<double>(popupPosition, popupSize);
			bool num7 = !screenBounds.Contains(targetRect);
			if (!num7)
			{
				intersection = Rect<double>.Empty;
				return num7;
			}
			screenBounds.Intersects(targetRect, out intersection);
			intersection.Width = (targetRect.Width - intersection.Width) * ((targetRect.Left < intersection.Left) ? 1.0 : (-1.0));
			intersection.Height = (targetRect.Height - intersection.Height) * ((targetRect.Top < intersection.Top) ? 1.0 : (-1.0));
			return num7;
		}
	}

	private double GetHorizontalOffset(Vector2<double> popupSize, Vector2<double> targetSize)
	{
		double x = targetSize.X;
		double x2 = popupSize.X;
		return base.HorizontalAlignment switch
		{
			HorizontalAlignment.Left => 0.0, 
			HorizontalAlignment.Center => (x - x2) / 2.0, 
			HorizontalAlignment.Right => x - x2, 
			HorizontalAlignment.Stretch => HorizontalOffset, 
			_ => throw new NotSupportedException(), 
		};
	}

	private double GetVerticalOffset(Vector2<double> popupSize, Vector2<double> targetSize)
	{
		double y = targetSize.Y;
		double y2 = popupSize.Y;
		return base.VerticalAlignment switch
		{
			VerticalAlignment.Top => 0.0, 
			VerticalAlignment.Center => (y - y2) / 2.0, 
			VerticalAlignment.Bottom => y - y2, 
			VerticalAlignment.Stretch => VerticalOffset, 
			_ => throw new NotSupportedException(), 
		};
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
