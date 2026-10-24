using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Common.Win32;

namespace Pro.UI.Controls.Windowing;

public class PositionableWindow : Window
{
	public static readonly DependencyProperty IsPositionSavedProperty = DependencyProperty.Register("IsPositionSaved", typeof(bool), typeof(PositionableWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty LastWindowStateProperty = DependencyProperty.Register("LastWindowState", typeof(SW), typeof(PositionableWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)SW.SHOWNORMAL, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty LastWindowRectProperty = DependencyProperty.Register("LastWindowRect", typeof(Rect<int>), typeof(PositionableWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Rect<int>.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	protected nint Handle { get; private set; }

	protected HwndSource? HwndSource { get; private set; }

	protected Vector2<uint> DPI { get; private set; } = new Vector2<uint>(96u);

	protected Vector2<double> Scalar { get; private set; } = Vector2<double>.One;

	protected Rect<int> WindowBounds { get; private set; } = Rect<int>.Empty;

	protected Vector2<int> Offset { get; private set; } = Vector2<int>.Zero;

	public bool IsPositionSaved
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsPositionSavedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsPositionSavedProperty, (object)value);
		}
	}

	public SW LastWindowState
	{
		get
		{
			return (SW)((DependencyObject)this).GetValue(LastWindowStateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LastWindowStateProperty, (object)value);
		}
	}

	public Rect<int> LastWindowRect
	{
		get
		{
			return (Rect<int>)((DependencyObject)this).GetValue(LastWindowRectProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LastWindowRectProperty, (object)value);
		}
	}

	public event Action<PositionableWindow>? WindowDimensionsChanged;

	public PositionableWindow()
	{
		base.LocationChanged += delegate
		{
			OnLocationChanged();
		};
		base.SizeChanged += delegate
		{
			OnSizeChanged();
		};
	}

	protected override void OnSourceInitialized(EventArgs e)
	{
		Handle = new WindowInteropHelper(this).EnsureHandle();
		HwndSource = System.Windows.Interop.HwndSource.FromHwnd(Handle);
		HwndSource?.AddHook(WndProc);
		LoadWindowDimensions();
		UpdateBounds();
		base.OnSourceInitialized(e);
	}

	protected virtual nint WndProc(nint hWnd, int msg, nint wParam, nint lParam, ref bool handled)
	{
		switch ((WM)msg)
		{
		case WM.ACTIVATE:
		case WM.WINDOWPOSCHANGED:
			UpdateBounds();
			break;
		case WM.MOUSEHWHEEL:
		{
			int num = (short)((((IntPtr)wParam).ToInt64() >> 16) & 0xFFFF);
			if (num != 0)
			{
				OnMouseTilt(num);
			}
			return 1;
		}
		case WM.NCHITTEST:
		{
			HT defaultHT = (HT)WindowsFunctions.DefWindowProc(hWnd, (uint)msg, wParam, lParam);
			handled = TryNCHitTest(lParam, Vector2<int>.Zero, defaultHT, out var ht);
			if (handled)
			{
				return new IntPtr((int)ht);
			}
			break;
		}
		}
		return IntPtr.Zero;
	}

	protected virtual void OnMouseTilt(int tilt)
	{
	}

	protected override void OnStateChanged(EventArgs e)
	{
		SaveWindowDimensions();
		base.OnStateChanged(e);
	}

	private void OnLocationChanged()
	{
		SaveWindowDimensions();
	}

	private void OnSizeChanged()
	{
		SaveWindowDimensions();
	}

	private void SaveWindowDimensions()
	{
		if (base.IsLoaded && Handle != IntPtr.Zero)
		{
			WindowsFunctions.GetWindowPlacement(Handle, out var lpwndpl);
			IsPositionSaved = true;
			LastWindowState = lpwndpl.ShowCommand;
			LastWindowRect = (Rect<int>)lpwndpl.NormalPosition;
			this.WindowDimensionsChanged?.Invoke(this);
		}
	}

	public void LoadWindowDimensions()
	{
		if (IsPositionSaved && Handle != IntPtr.Zero)
		{
			WINDOWPLACEMENT lpwndpl = WINDOWPLACEMENT.Empty;
			lpwndpl.ShowCommand = LastWindowState;
			lpwndpl.NormalPosition = LastWindowRect;
			lpwndpl.MinPosition = Vector2<int>.NegativeOne;
			lpwndpl.MaxPosition = Vector2<int>.NegativeOne;
			WindowsFunctions.SetWindowPlacement(Handle, ref lpwndpl);
		}
	}

	protected virtual void OnUpdateBounds(Rect<int> windowBounds, Rect<int> monitorBounds, bool isMaximized)
	{
	}

	protected void UpdateBounds()
	{
		nint hMonitor = WindowsFunctions.MonitorFromWindow(Handle, MONITOR.DEFAULTTOPRIMARY);
		MONITORINFO lpmi = MONITORINFO.Empty;
		WindowsFunctions.GetWindowRect(Handle, out var lpRect);
		WindowsFunctions.GetWindowPlacement(Handle, out var lpwndpl);
		WindowsFunctions.GetMonitorInfoW(hMonitor, ref lpmi);
		WindowsFunctions.GetDpiForMonitor(hMonitor, MDT.EFFECTIVE_DPI, out var dpiX, out var dpiY);
		Rect<int> monitorBounds = (Rect<int>)lpmi.RcWork;
		bool isMaximized = lpwndpl.ShowCommand == SW.MAXIMIZE;
		DPI = new Vector2<uint>(dpiX, dpiY);
		Scalar = DPI.Cast<double>() / 96.0;
		WindowBounds = (Rect<int>)lpRect;
		Offset = WindowBounds.TopLeft;
		OnUpdateBounds(WindowBounds, monitorBounds, isMaximized);
	}

	protected virtual bool TryNCHitTest(nint lParam, Vector2<int> edgeThickness, HT defaultHT, out HT ht)
	{
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		ht = HT.NOWHERE;
		Vector2<int> vector = UnpackPoint(lParam);
		Vector2<double> vector2 = (vector - (Offset + edgeThickness)).Cast<double>().ComponentwiseQuotient(Scalar);
		DependencyObject visual = null;
		if (!WindowBounds.Pad(-edgeThickness).Contains(vector))
		{
			return false;
		}
		VisualTreeHelper.HitTest(this, delegate(DependencyObject m)
		{
			if (m is UIElement uIElement)
			{
				if (!uIElement.IsVisible)
				{
					return HitTestFilterBehavior.ContinueSkipSelfAndChildren;
				}
				if (!uIElement.IsHitTestVisible)
				{
					return HitTestFilterBehavior.ContinueSkipSelf;
				}
				return HitTestFilterBehavior.Continue;
			}
			return HitTestFilterBehavior.ContinueSkipSelfAndChildren;
		}, delegate(HitTestResult m)
		{
			visual = m.VisualHit;
			return HitTestResultBehavior.Stop;
		}, new PointHitTestParameters(vector2));
		if (visual is UIElement uIElement2)
		{
			if (visual is INonClientSpace nonClientSpace)
			{
				ht = nonClientSpace.DoHitTest(vector2 - (Vector2<double>)uIElement2.TranslatePoint(Vector2<double>.Zero, this));
			}
			else
			{
				ht = HT.CLIENT;
			}
			return true;
		}
		return false;
	}

	protected static Vector2<int> UnpackPoint(nint lParam)
	{
		long num = ((IntPtr)lParam).ToInt64();
		return new Vector2<int>((short)num, (short)(num >> 16));
	}
}
