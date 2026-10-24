using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;
using Pro.Common.Mathematics;
using Pro.Common.Versioning;
using Pro.Common.Win32;
using Pro.UI.Theming;

namespace Pro.UI.Controls.Windowing;

[TemplatePart(Name = "PART_MinimizeButton", Type = typeof(Button))]
[TemplatePart(Name = "PART_MaximizeRestoreButton", Type = typeof(Button))]
[TemplatePart(Name = "PART_CloseButton", Type = typeof(Button))]
public class ChromedWindow : PositionableWindow, ICloseableDialog, ICloseable
{
	private sealed class EdgeWindow : Window
	{
		private readonly ChromedWindow _targetWindow;

		private nint _handle = IntPtr.Zero;

		private HwndSource? _hwndSource;

		private Vector2<double> _scalar = Vector2<double>.One;

		private Vector2<int> _offset = Vector2<int>.Zero;

		private Rect<int> _outerBounds = Rect<int>.Empty;

		private Rect<int> _innerBounds = Rect<int>.Empty;

		private Rect<int> _leftEdge = Rect<int>.Empty;

		private Rect<int> _topEdge = Rect<int>.Empty;

		private Rect<int> _rightEdge = Rect<int>.Empty;

		private Rect<int> _bottomEdge = Rect<int>.Empty;

		private Rect<int> _tlCorner = Rect<int>.Empty;

		private Rect<int> _trCorner = Rect<int>.Empty;

		private Rect<int> _blCorner = Rect<int>.Empty;

		private Rect<int> _brCorner = Rect<int>.Empty;

		private bool _isClosedOrClosing;

		public bool HasSafeAccess
		{
			get
			{
				if (_isClosedOrClosing || ((DispatcherObject)this).Dispatcher.HasShutdownStarted || ((DispatcherObject)this).Dispatcher.HasShutdownFinished)
				{
					return false;
				}
				EnsureHandleCreated();
				if (_hwndSource?.CompositionTarget == null)
				{
					return false;
				}
				return true;
			}
		}

		public EdgeWindow(ChromedWindow targetWindow)
		{
			_targetWindow = targetWindow;
			base.Background = Brushes.Transparent;
			base.WindowStyle = WindowStyle.None;
			base.AllowsTransparency = true;
			base.WindowStartupLocation = WindowStartupLocation.Manual;
			base.ShowInTaskbar = false;
		}

		private void EnsureHandleCreated()
		{
			if (_handle == IntPtr.Zero)
			{
				_handle = new WindowInteropHelper(this).EnsureHandle();
			}
			if (_hwndSource == null)
			{
				_hwndSource = System.Windows.Interop.HwndSource.FromHwnd(_handle);
			}
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			_isClosedOrClosing = true;
		}

		protected override void OnClosed(EventArgs e)
		{
			_isClosedOrClosing = true;
		}

		protected override void OnSourceInitialized(EventArgs e)
		{
			EnsureHandleCreated();
			System.Windows.Interop.HwndSource.FromHwnd(_handle)?.AddHook(WndProc);
			WindowsFunctions.SetWindowLong(_handle, GWL.EXSTYLE, (nint)(uint)((int)WindowsFunctions.GetWindowLong(_handle, GWL.EXSTYLE) | 0x80));
			base.OnSourceInitialized(e);
		}

		protected override void OnRender(DrawingContext drawingContext)
		{
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			GradientStopCollection gradientStops;
			if (!(_innerBounds == Rect<int>.Empty))
			{
				drawingContext.PushTransform(new ScaleTransform(1.0 / _scalar.X, 1.0 / _scalar.Y));
				drawingContext.PushTransform(new TranslateTransform(-_leftEdge.Left, -_topEdge.Top));
				Color edgeColor = _targetWindow.EdgeColor;
				gradientStops = new GradientStopCollection
				{
					new GradientStop(Color.FromArgb(72, edgeColor.R, edgeColor.G, edgeColor.B), 0.0),
					new GradientStop(Color.FromArgb(0, edgeColor.R, edgeColor.G, edgeColor.B), 1.0)
				};
				drawEdge(_leftEdge, Vector2<double>.UnitX, Vector2<double>.Zero);
				drawEdge(_topEdge, Vector2<double>.UnitY, Vector2<double>.Zero);
				drawEdge(_rightEdge, Vector2<double>.Zero, Vector2<double>.UnitX);
				drawEdge(_bottomEdge, Vector2<double>.Zero, Vector2<double>.UnitY);
				drawCorner(_tlCorner, Vector2<int>.Zero);
				drawCorner(_trCorner, Vector2<int>.UnitX);
				drawCorner(_blCorner, Vector2<int>.UnitY);
				drawCorner(_brCorner, Vector2<int>.One);
				drawingContext.DrawRectangle(_targetWindow.Background, new Pen(new SolidColorBrush(edgeColor), 2.0), _innerBounds);
				drawingContext.Pop();
				drawingContext.Pop();
			}
			void drawCorner(Rect<int> corner, Vector2<int> offset)
			{
				//IL_0021: Unknown result type (might be due to invalid IL or missing references)
				//IL_0063: Unknown result type (might be due to invalid IL or missing references)
				if (!(corner == Rect<int>.Empty))
				{
					RadialGradientBrush brush2 = new RadialGradientBrush(gradientStops);
					drawingContext.PushClip(new RectangleGeometry(corner));
					drawingContext.DrawRectangle(brush2, null, new Rect<int>(corner.Position - corner.Size.ComponentwiseProduct(offset), corner.Size * 2));
					drawingContext.Pop();
				}
			}
			void drawEdge(Rect<int> edge, Vector2<double> startPoint, Vector2<double> endPoint)
			{
				//IL_0021: Unknown result type (might be due to invalid IL or missing references)
				//IL_002d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0041: Unknown result type (might be due to invalid IL or missing references)
				if (!(edge == Rect<int>.Empty))
				{
					LinearGradientBrush brush = new LinearGradientBrush
					{
						GradientStops = gradientStops,
						StartPoint = startPoint,
						EndPoint = endPoint
					};
					drawingContext.DrawRectangle(brush, null, edge);
				}
			}
		}

		private nint WndProc(nint hWnd, int msg, nint wParam, nint lParam, ref bool handled)
		{
			switch ((WM)msg)
			{
			case WM.ACTIVATE:
				WindowsFunctions.SendMessage(_targetWindow.Handle, 6, new IntPtr(1), IntPtr.Zero);
				handled = true;
				break;
			case WM.MOUSEACTIVATE:
				handled = true;
				return 3;
			case WM.NCHITTEST:
			{
				handled = true;
				HT hT = DoNCHitTest(lParam);
				if (_targetWindow.TryValidateDirectionHT(hT, out var validatedHT))
				{
					hT = validatedHT;
				}
				return new IntPtr((int)hT);
			}
			case WM.WINDOWPOSCHANGING:
			{
				WINDOWPOS structure = Marshal.PtrToStructure<WINDOWPOS>(lParam);
				structure.Flags |= SWP.NOACTIVATE;
				Marshal.StructureToPtr(structure, lParam, fDeleteOld: true);
				break;
			}
			case WM.NCLBUTTONDOWN:
			case WM.NCLBUTTONDBLCLK:
			case WM.NCRBUTTONDOWN:
			case WM.NCRBUTTONDBLCLK:
			case WM.NCMBUTTONDOWN:
			case WM.NCMBUTTONDBLCLK:
			case WM.NCXBUTTONDOWN:
			case WM.NCXBUTTONDBLCLK:
				WindowsFunctions.SendMessage(_targetWindow.Handle, 6, new IntPtr(2), IntPtr.Zero);
				WindowsFunctions.SendMessage(_targetWindow.Handle, msg, wParam, IntPtr.Zero);
				handled = true;
				break;
			}
			return IntPtr.Zero;
		}

		public void UpdatePosition(Vector2<int> edgeThickness, Rect<int> targetBounds, Rect<int> monitorBounds, Vector2<double> scalar, bool isMaximized)
		{
			EnsureHandleCreated();
			_scalar = Vector2<double>.One;
			_offset = Vector2<int>.Zero;
			_outerBounds = Rect<int>.Empty;
			_innerBounds = Rect<int>.Empty;
			_leftEdge = Rect<int>.Empty;
			_topEdge = Rect<int>.Empty;
			_rightEdge = Rect<int>.Empty;
			_bottomEdge = Rect<int>.Empty;
			_tlCorner = Rect<int>.Empty;
			_trCorner = Rect<int>.Empty;
			_blCorner = Rect<int>.Empty;
			_brCorner = Rect<int>.Empty;
			if (!isMaximized)
			{
				_scalar = scalar;
				_offset = targetBounds.TopLeft;
				targetBounds.Position -= _offset;
				monitorBounds.Position -= _offset;
				_outerBounds = targetBounds;
				_innerBounds = targetBounds;
				_tlCorner = new Rect<int>(targetBounds.TopLeft, Vector2<int>.Zero);
				_trCorner = new Rect<int>(targetBounds.TopRight, Vector2<int>.Zero);
				_blCorner = new Rect<int>(targetBounds.BottomLeft, Vector2<int>.Zero);
				_brCorner = new Rect<int>(targetBounds.BottomRight, Vector2<int>.Zero);
				if (targetBounds.Left != monitorBounds.Left)
				{
					_leftEdge = new Rect<int>(targetBounds.TopLeft - new Vector2<int>(edgeThickness.X, 0), new Vector2<int>(edgeThickness.X, targetBounds.Height));
					_tlCorner.Width = edgeThickness.X;
					_tlCorner.Left -= edgeThickness.X;
					_blCorner.Width = edgeThickness.X;
					_blCorner.Left -= edgeThickness.X;
					_outerBounds.Left -= edgeThickness.X;
					_outerBounds.Width += edgeThickness.X;
				}
				if (targetBounds.Top != monitorBounds.Top)
				{
					_topEdge = new Rect<int>(targetBounds.TopLeft - new Vector2<int>(0, edgeThickness.Y), new Vector2<int>(targetBounds.Width, edgeThickness.Y));
					_tlCorner.Height = edgeThickness.Y;
					_tlCorner.Top -= edgeThickness.Y;
					_trCorner.Height = edgeThickness.Y;
					_trCorner.Top -= edgeThickness.Y;
					_outerBounds.Top -= edgeThickness.Y;
					_outerBounds.Height += edgeThickness.Y;
				}
				if (targetBounds.Right != monitorBounds.Right)
				{
					_rightEdge = new Rect<int>(targetBounds.TopRight, new Vector2<int>(edgeThickness.X, targetBounds.Height));
					_trCorner.Width = edgeThickness.X;
					_brCorner.Width = edgeThickness.X;
					_outerBounds.Width += edgeThickness.X;
				}
				if (targetBounds.Bottom != monitorBounds.Bottom)
				{
					_bottomEdge = new Rect<int>(targetBounds.BottomLeft, new Vector2<int>(targetBounds.Width, edgeThickness.Y));
					_blCorner.Height = edgeThickness.Y;
					_brCorner.Height = edgeThickness.Y;
					_outerBounds.Height += edgeThickness.Y;
				}
			}
			WindowsFunctions.SetWindowPos(_handle, _targetWindow.Handle, _outerBounds.Left + _offset.X, _outerBounds.Top + _offset.Y, _outerBounds.Width, _outerBounds.Height, SWP.NOACTIVATE);
		}

		private HT DoNCHitTest(nint lParam)
		{
			Vector2<int> point = PositionableWindow.UnpackPoint(lParam) - _offset;
			if (_leftEdge.Contains(point))
			{
				return HT.LEFT;
			}
			if (_topEdge.Contains(point))
			{
				return HT.TOP;
			}
			if (_rightEdge.Contains(point))
			{
				return HT.RIGHT;
			}
			if (_bottomEdge.Contains(point))
			{
				return HT.BOTTOM;
			}
			if (_tlCorner.Contains(point))
			{
				return HT.TOPLEFT;
			}
			if (_trCorner.Contains(point))
			{
				return HT.TOPRIGHT;
			}
			if (_blCorner.Contains(point))
			{
				return HT.BOTTOMLEFT;
			}
			if (_brCorner.Contains(point))
			{
				return HT.BOTTOMRIGHT;
			}
			return HT.NOWHERE;
		}
	}

	private const string TemplateKey = "ChromedWindowTemplate";

	private const string MinimizeButtonName = "PART_MinimizeButton";

	private const string MaximizeRestoreButtonName = "PART_MaximizeRestoreButton";

	private const string CloseButtonName = "PART_CloseButton";

	private readonly Func<HwndSource?, bool>? IsLayoutActive = CreateDelegate<Func<HwndSource, bool>>("IsLayoutActive");

	private readonly Action<HwndSource?>? SetLayoutSize = CreateDelegate<Action<HwndSource>>("SetLayoutSize");

	private static readonly (HT hitHt, ResizeDirection direction, HT resultHt)[] ResizeDirectionHTMap = new(HT, ResizeDirection, HT)[16]
	{
		(HT.LEFT, ResizeDirection.Left, HT.BORDER),
		(HT.RIGHT, ResizeDirection.Right, HT.BORDER),
		(HT.TOP, ResizeDirection.Top, HT.BORDER),
		(HT.BOTTOM, ResizeDirection.Bottom, HT.BORDER),
		(HT.TOPLEFT, ResizeDirection.Left, HT.TOP),
		(HT.TOPLEFT, ResizeDirection.Top, HT.LEFT),
		(HT.TOPLEFT, ResizeDirection.TopLeft, HT.BORDER),
		(HT.TOPRIGHT, ResizeDirection.Right, HT.TOP),
		(HT.TOPRIGHT, ResizeDirection.Top, HT.RIGHT),
		(HT.TOPRIGHT, ResizeDirection.TopRight, HT.BORDER),
		(HT.BOTTOMRIGHT, ResizeDirection.Right, HT.BOTTOM),
		(HT.BOTTOMRIGHT, ResizeDirection.Bottom, HT.RIGHT),
		(HT.BOTTOMRIGHT, ResizeDirection.BottomRight, HT.BORDER),
		(HT.BOTTOMLEFT, ResizeDirection.Left, HT.BOTTOM),
		(HT.BOTTOMLEFT, ResizeDirection.Bottom, HT.LEFT),
		(HT.BOTTOMLEFT, ResizeDirection.BottomLeft, HT.BORDER)
	};

	private readonly EdgeWindow? _edgeWindow;

	private Button? _minimizeButton;

	private Button? _maximizeRestoreButton;

	private Button? _closeButton;

	private bool _isClosing;

	public static readonly DependencyProperty EdgeColorProperty = DependencyProperty.Register("EdgeColor", typeof(Color), typeof(ChromedWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Color.FromArgb(byte.MaxValue, 0, 122, 204)));

	public static readonly DependencyProperty LeftContentProperty = DependencyProperty.Register("LeftContent", typeof(object), typeof(ChromedWindow));

	public static readonly DependencyProperty RightContentProperty = DependencyProperty.Register("RightContent", typeof(object), typeof(ChromedWindow));

	public static readonly DependencyProperty ControlButtonPaletteProperty = DependencyProperty.Register("ControlButtonPalette", typeof(StatePalette), typeof(ChromedWindow));

	public static readonly DependencyProperty CanMinimizeProperty = DependencyProperty.Register("CanMinimize", typeof(bool), typeof(ChromedWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty CanMaximizeProperty = DependencyProperty.Register("CanMaximize", typeof(bool), typeof(ChromedWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty CanCloseProperty = DependencyProperty.Register("CanClose", typeof(bool), typeof(ChromedWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ShowTitlebarProperty = DependencyProperty.Register("ShowTitlebar", typeof(bool), typeof(ChromedWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ShowTitleProperty = DependencyProperty.Register("ShowTitle", typeof(bool), typeof(ChromedWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ResizeDirectionProperty = DependencyProperty.Register("ResizeDirection", typeof(ResizeDirection), typeof(ChromedWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)ResizeDirection.All));

	public Color EdgeColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(EdgeColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EdgeColorProperty, (object)value);
		}
	}

	public object LeftContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(LeftContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LeftContentProperty, value);
		}
	}

	public object RightContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(RightContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RightContentProperty, value);
		}
	}

	public StatePalette ControlButtonPalette
	{
		get
		{
			return (StatePalette)((DependencyObject)this).GetValue(ControlButtonPaletteProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ControlButtonPaletteProperty, (object)value);
		}
	}

	public bool CanMinimize
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanMinimizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanMinimizeProperty, (object)value);
		}
	}

	public bool CanMaximize
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanMaximizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanMaximizeProperty, (object)value);
		}
	}

	public bool CanClose
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanCloseProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanCloseProperty, (object)value);
		}
	}

	public bool ShowTitlebar
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowTitlebarProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowTitlebarProperty, (object)value);
		}
	}

	public bool ShowTitle
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowTitleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowTitleProperty, (object)value);
		}
	}

	public ResizeDirection ResizeDirection
	{
		get
		{
			return (ResizeDirection)((DependencyObject)this).GetValue(ResizeDirectionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ResizeDirectionProperty, (object)value);
		}
	}

	protected bool IsResizing { get; private set; }

	[MemberNotNullWhen(true, "_edgeWindow")]
	private bool ControlsEdgeBorder
	{
		[MemberNotNullWhen(true, "_edgeWindow")]
		get;
	}

	public bool IsClosing => _isClosing;

	public ChromedWindow()
	{
		ControlsEdgeBorder = VersionInfo.OSVersion.Major < 10 || VersionInfo.OSVersion.Build < 22000;
		if (ControlsEdgeBorder)
		{
			_edgeWindow = new EdgeWindow(this);
			_edgeWindow.SetBinding(Window.ResizeModeProperty, new Binding(Window.ResizeModeProperty.Name)
			{
				Source = this
			});
		}
		base.Template = (ControlTemplate)ResourceProvider.GetResource("ChromedWindowTemplate");
	}

	private static T? CreateDelegate<T>(string methodName) where T : Delegate
	{
		MethodInfo method = typeof(HwndSource).GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
		if (method != null)
		{
			return (T)Delegate.CreateDelegate(typeof(T), method);
		}
		return null;
	}

	protected override void OnClosing(CancelEventArgs e)
	{
		base.OnClosing(e);
		if (!e.Cancel)
		{
			_isClosing = true;
		}
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		_minimizeButton = GetTemplateChild("PART_MinimizeButton") as Button;
		_maximizeRestoreButton = GetTemplateChild("PART_MaximizeRestoreButton") as Button;
		_closeButton = GetTemplateChild("PART_CloseButton") as Button;
		if (_minimizeButton != null)
		{
			_minimizeButton.Click += delegate
			{
				base.WindowState = WindowState.Minimized;
			};
		}
		if (_maximizeRestoreButton != null)
		{
			_maximizeRestoreButton.Click += delegate
			{
				if (base.WindowState == WindowState.Normal)
				{
					base.WindowState = WindowState.Maximized;
				}
				else if (base.WindowState == WindowState.Maximized)
				{
					base.WindowState = WindowState.Normal;
				}
			};
		}
		if (_closeButton != null)
		{
			_closeButton.Click += delegate
			{
				Close();
			};
		}
	}

	protected override void OnSourceInitialized(EventArgs e)
	{
		base.OnSourceInitialized(e);
		if (ControlsEdgeBorder)
		{
			_edgeWindow.Owner = base.Owner;
			if (base.IsVisible && _edgeWindow.HasSafeAccess)
			{
				_edgeWindow.Show();
			}
		}
	}

	protected override nint WndProc(nint hWnd, int msg, nint wParam, nint lParam, ref bool handled)
	{
		switch ((WM)msg)
		{
		case WM.DESTROY:
			if (ControlsEdgeBorder && _edgeWindow.HasSafeAccess)
			{
				_edgeWindow.Close();
			}
			break;
		case WM.SIZE:
			if (ControlsEdgeBorder && _edgeWindow.HasSafeAccess)
			{
				switch ((SIZE)wParam)
				{
				case SIZE.MINIMIZED:
					_edgeWindow.WindowState = WindowState.Minimized;
					break;
				case SIZE.RESTORED:
				case SIZE.MAXIMIZED:
					_edgeWindow.WindowState = WindowState.Normal;
					break;
				}
			}
			break;
		case WM.SHOWWINDOW:
			if (ControlsEdgeBorder && _edgeWindow.HasSafeAccess)
			{
				if (wParam != IntPtr.Zero)
				{
					_edgeWindow.Show();
				}
				else
				{
					_edgeWindow.Hide();
				}
			}
			break;
		case WM.NCCALCSIZE:
		{
			handled = true;
			bool num = WindowsFunctions.IsZoomed(hWnd);
			if (num)
			{
				WindowsFunctions.DefWindowProc(hWnd, 131u, wParam, lParam);
			}
			RECT structure = Marshal.PtrToStructure<RECT>(lParam);
			if (num)
			{
				structure.Top -= WindowsFunctions.GetSystemMetricsForDpi(SM.CYCAPTION, base.DPI.Y) + 1;
				nint hMonitor = WindowsFunctions.MonitorFromWindow(hWnd, MONITOR.DEFAULTTOPRIMARY);
				MONITORINFO lpmi = MONITORINFO.Empty;
				WindowsFunctions.GetMonitorInfoW(hMonitor, ref lpmi);
				if (lpmi.RcMonitor.Width == lpmi.RcWork.Width && lpmi.RcMonitor.Height == lpmi.RcWork.Height)
				{
					APPBARDATA pData = APPBARDATA.Empty;
					if (WindowsFunctions.SHAppBarMessage(ABM.GETTASKBARPOS, ref pData) != IntPtr.Zero)
					{
						Vector2<int> vector = Vector2<double>.One.ComponentwiseProduct(base.Scalar).Ceiling().Cast<int>();
						switch (pData.Edge)
						{
						case ABE.LEFT:
							structure.Left += vector.X;
							break;
						case ABE.TOP:
							structure.Top += vector.Y;
							break;
						case ABE.RIGHT:
							structure.Right -= vector.X;
							break;
						case ABE.BOTTOM:
							structure.Bottom -= vector.Y;
							break;
						}
					}
				}
			}
			else if (ControlsEdgeBorder)
			{
				if (wParam != IntPtr.Zero)
				{
					structure.Bottom--;
				}
			}
			else
			{
				Vector2<int> edgeThickness = GetEdgeThickness();
				structure.Left += edgeThickness.X;
				structure.Right -= edgeThickness.X;
				structure.Bottom -= edgeThickness.Y;
			}
			Marshal.StructureToPtr(structure, lParam, fDeleteOld: true);
			if (base.SizeToContent != 0)
			{
				((DispatcherObject)this).Dispatcher.InvokeAsync((Action)delegate
				{
					Func<HwndSource?, bool>? isLayoutActive = IsLayoutActive;
					if (isLayoutActive != null && isLayoutActive(base.HwndSource))
					{
						SetLayoutSize?.Invoke(base.HwndSource);
					}
				});
			}
			return IntPtr.Zero;
		}
		case WM.ENTERSIZEMOVE:
			IsResizing = true;
			break;
		case WM.EXITSIZEMOVE:
			IsResizing = false;
			break;
		}
		return base.WndProc(hWnd, msg, wParam, lParam, ref handled);
	}

	protected override void OnUpdateBounds(Rect<int> windowBounds, Rect<int> monitorBounds, bool isMaximized)
	{
		if (ControlsEdgeBorder && _edgeWindow.HasSafeAccess)
		{
			_edgeWindow.UpdatePosition(GetEdgeThickness(), windowBounds, monitorBounds, base.Scalar, isMaximized);
		}
	}

	protected override bool TryNCHitTest(nint lParam, Vector2<int> edgeThickness, HT defaultHT, out HT ht)
	{
		edgeThickness = ((!ControlsEdgeBorder) ? GetEdgeThickness() : Vector2<int>.Zero);
		if (!ControlsEdgeBorder && base.WindowState == WindowState.Normal)
		{
			bool flag = false;
			Vector2<int> vector = PositionableWindow.UnpackPoint(lParam) - base.Offset;
			ht = defaultHT;
			if (vector.Y < edgeThickness.Y)
			{
				if (vector.X < edgeThickness.X)
				{
					ht = HT.TOPLEFT;
				}
				else if (vector.X > base.WindowBounds.Width - edgeThickness.X)
				{
					ht = HT.TOPRIGHT;
				}
				else
				{
					ht = HT.TOP;
				}
				flag = true;
			}
			if (TryValidateDirectionHT(ht, out var validatedHT))
			{
				ht = validatedHT;
				flag = true;
			}
			if (flag)
			{
				return true;
			}
		}
		return base.TryNCHitTest(lParam, edgeThickness, defaultHT, out ht);
	}

	private Vector2<int> GetEdgeThickness()
	{
		return new Vector2<int>(WindowsFunctions.GetSystemMetricsForDpi(SM.CXFRAME, base.DPI.X) + WindowsFunctions.GetSystemMetricsForDpi(SM.CXPADDEDBORDER, base.DPI.X), WindowsFunctions.GetSystemMetricsForDpi(SM.CYFRAME, base.DPI.Y) + WindowsFunctions.GetSystemMetricsForDpi(SM.CXPADDEDBORDER, base.DPI.Y));
	}

	private bool TryValidateDirectionHT(HT ht, out HT validatedHT)
	{
		validatedHT = ht;
		if (ResizeDirection != ResizeDirection.All && ht != 0)
		{
			(HT, ResizeDirection, HT)[] resizeDirectionHTMap = ResizeDirectionHTMap;
			for (int i = 0; i < resizeDirectionHTMap.Length; i++)
			{
				var (hT, resizeDirection, hT2) = resizeDirectionHTMap[i];
				if (hT == ht && !ResizeDirection.HasFlag(resizeDirection))
				{
					validatedHT = hT2;
					return true;
				}
			}
		}
		return false;
	}

	bool? ICloseableDialog.get_DialogResult()
	{
		return base.DialogResult;
	}

	void ICloseableDialog.set_DialogResult(bool? value)
	{
		base.DialogResult = value;
	}

	void ICloseable.Close()
	{
		Close();
	}
}
