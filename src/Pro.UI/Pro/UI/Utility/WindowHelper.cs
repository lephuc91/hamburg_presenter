using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Effects;
using Pro.Common.ErrorReporting;
using Pro.Common.Logging;
using Pro.Common.Win32;
using Pro.UI.Controls.Windowing;
using Pro.UI.DependencyInjection;

namespace Pro.UI.Utility;

public static class WindowHelper
{
	[CompilerGenerated]
	private static class _003C_003EO
	{
		public static CancelEventHandler _003C0_003E__Window_Closing_ForHidingWindow;

		public static KeyEventHandler _003C1_003E__RaiseEventToMainWindow;

		public static DependencyPropertyChangedEventHandler _003C2_003E__OnWindowVisibilityChanged;

		public static Func<Window, bool> _003C3_003E__GetCanOwnWindows;

		public static DependencyPropertyChangedEventHandler _003C4_003E__Window_OnVisibilityChanged_UpdateBlurMainWindowAndHideAllOthers;
	}

	private const string HideOnClose = "HideOnClose";

	private const string SendKeyEventsToMainWindow = "SendKeyEventsToMainWindow";

	private const string UseGlobalStyle = "UseGlobalStyle";

	private const string ChildOf = "ChildOf";

	private const string CanOwnWindows = "CanOwnWindows";

	private const string BlurMainWindowAndHideAllOthers = "BlurMainWindowAndHideAllOthers";

	private const string WindowsHiddenByBlur = "WindowsHiddenByBlur";

	public static readonly DependencyProperty HideOnCloseProperty = DependencyProperty.RegisterAttached("HideOnClose", typeof(bool), typeof(WindowHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(HideOnCloseChanged)));

	public static readonly DependencyProperty SendKeyEventsToMainWindowProperty = DependencyProperty.RegisterAttached("SendKeyEventsToMainWindow", typeof(bool), typeof(WindowHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(SendKeyEventsToMainWindowChanged)));

	public static readonly DependencyProperty UseGlobalStyleProperty = DependencyProperty.RegisterAttached("UseGlobalStyle", typeof(bool), typeof(WindowHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(UseGlobalStyleChanged)));

	public static readonly DependencyProperty ChildOfProperty = DependencyProperty.RegisterAttached("ChildOf", typeof(WindowAttachedTo), typeof(WindowHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)WindowAttachedTo.NotSet, new PropertyChangedCallback(ChildOfChanged)));

	public static readonly DependencyProperty CanOwnWindowsProperty = DependencyProperty.RegisterAttached("CanOwnWindows", typeof(bool), typeof(WindowHelper));

	public static readonly DependencyProperty BlurMainWindowAndHideAllOthersProperty = DependencyProperty.RegisterAttached("BlurMainWindowAndHideAllOthers", typeof(bool), typeof(WindowHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(BlurMainWindowAndHideAllOthersChanged)));

	private static readonly DependencyProperty WindowsHiddenByBlurProperty = DependencyProperty.RegisterAttached("WindowsHiddenByBlur", typeof(IList<Window>), typeof(WindowHelper));

	private static void HideOnCloseChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnHideOnCloseChanged((Window)(object)callerObject, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void SendKeyEventsToMainWindowChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnSendKeyEventsToMainWindowChanged((UIElement)(object)callerObject, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void UseGlobalStyleChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnUseGlobalStyleChanged((Window)(object)callerObject, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void ChildOfChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnChildOfChanged((Window)(object)callerObject, (WindowAttachedTo)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public static bool GetHideOnClose(Window element)
	{
		return (bool)((DependencyObject)element).GetValue(HideOnCloseProperty);
	}

	public static void SetHideOnClose(Window element, bool value)
	{
		((DependencyObject)element).SetValue(HideOnCloseProperty, (object)value);
	}

	public static bool GetSendKeyEventsToMainWindow(Window element)
	{
		return (bool)((DependencyObject)element).GetValue(SendKeyEventsToMainWindowProperty);
	}

	public static void SetSendKeyEventsToMainWindow(Window element, bool value)
	{
		((DependencyObject)element).SetValue(SendKeyEventsToMainWindowProperty, (object)value);
	}

	public static bool GetUseGlobalStyle(Window element)
	{
		return (bool)((DependencyObject)element).GetValue(UseGlobalStyleProperty);
	}

	public static void SetUseGlobalStyle(Window element, bool value)
	{
		((DependencyObject)element).SetValue(UseGlobalStyleProperty, (object)value);
	}

	public static WindowAttachedTo GetChildOf(Window element)
	{
		return (WindowAttachedTo)((DependencyObject)element).GetValue(ChildOfProperty);
	}

	public static void SetChildOf(Window element, WindowAttachedTo value)
	{
		((DependencyObject)element).SetValue(ChildOfProperty, (object)value);
	}

	public static bool GetCanOwnWindows(Window element)
	{
		return (bool)((DependencyObject)element).GetValue(CanOwnWindowsProperty);
	}

	public static void SetCanOwnWindows(Window element, bool value)
	{
		((DependencyObject)element).SetValue(CanOwnWindowsProperty, (object)value);
	}

	private static void OnHideOnCloseChanged(Window window, bool hideOnClose)
	{
		if (hideOnClose)
		{
			window.Closing += Window_Closing_ForHidingWindow;
		}
		else
		{
			window.Closing -= Window_Closing_ForHidingWindow;
		}
	}

	private static void Window_Closing_ForHidingWindow(object? sender, CancelEventArgs e)
	{
		e.Cancel = true;
		(sender as Window)?.Hide();
	}

	private static void OnSendKeyEventsToMainWindowChanged(UIElement element, bool sendKeyEventsToMainWindow)
	{
		if (sendKeyEventsToMainWindow)
		{
			element.KeyDown += RaiseEventToMainWindow;
			element.KeyUp += RaiseEventToMainWindow;
		}
		else
		{
			element.KeyDown -= RaiseEventToMainWindow;
			element.KeyUp -= RaiseEventToMainWindow;
		}
	}

	private static void OnUseGlobalStyleChanged(Window window, bool useGlobalStyle)
	{
		window.Style = (useGlobalStyle ? (Application.Current?.Resources[typeof(Window)] as Style) : null);
	}

	private static void RaiseEventToMainWindow(object? sender, RoutedEventArgs e)
	{
		if (Application.Current.MainWindow != sender)
		{
			Application.Current.MainWindow?.RaiseEvent(e);
		}
	}

	private static void OnChildOfChanged(Window window, WindowAttachedTo childOf)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		Window window2;
		switch (childOf)
		{
		case WindowAttachedTo.NotSet:
		{
			object obj = _003C_003EO._003C2_003E__OnWindowVisibilityChanged;
			if (obj == null)
			{
				DependencyPropertyChangedEventHandler val = OnWindowVisibilityChanged;
				_003C_003EO._003C2_003E__OnWindowVisibilityChanged = val;
				obj = (object)val;
			}
			window.IsVisibleChanged -= (DependencyPropertyChangedEventHandler)obj;
			window.Owner = null;
			return;
		}
		case WindowAttachedTo.MainWindow:
			window2 = MainWindow();
			break;
		case WindowAttachedTo.ActiveWindow:
			window2 = LatestActiveWindow();
			break;
		default:
			window2 = null;
			break;
		}
		Window window3 = window2;
		if (window != window3)
		{
			object obj2 = _003C_003EO._003C2_003E__OnWindowVisibilityChanged;
			if (obj2 == null)
			{
				DependencyPropertyChangedEventHandler val2 = OnWindowVisibilityChanged;
				_003C_003EO._003C2_003E__OnWindowVisibilityChanged = val2;
				obj2 = (object)val2;
			}
			window.IsVisibleChanged += (DependencyPropertyChangedEventHandler)obj2;
			if (window3 != null)
			{
				window.Owner = window3;
			}
		}
	}

	private static void OnWindowVisibilityChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		object newValue = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		if ((!(newValue is bool) || !(bool)newValue) && sender is Window { Owner: ICloseable { IsClosing: false } } window)
		{
			window.Owner.Activate();
		}
	}

	public static void ShowWindow(this Window window)
	{
		if (!window.IsVisible)
		{
			window.Show();
		}
		else
		{
			window.Activate();
		}
	}

	public static Window? LatestActiveWindow()
	{
		Window window = MainWindow();
		if (window == null)
		{
			Log.Debug("No main window found");
			return null;
		}
		return GetHighestZOrderVisibleAndOwnedWindow(window) ?? window;
	}

	public static Window? MainWindow()
	{
		Window window = Application.Current?.MainWindow;
		if (window != null && window.IsVisible)
		{
			return window;
		}
		return null;
	}

	private static Window? GetHighestZOrderVisibleAndOwnedWindow(Window window)
	{
		nint[] ownedWindowHandles = (from w in window.OwnedWindows.OfType<Window>().Where(GetCanOwnWindows)
			select new WindowInteropHelper(w).EnsureHandle()).ToArray();
		nint result = IntPtr.Zero;
		WindowsFunctions.EnumWindows(delegate(nint wnd, nint param)
		{
			if (Array.Exists(ownedWindowHandles, (nint w) => w == wnd))
			{
				result = wnd;
				return false;
			}
			return true;
		}, IntPtr.Zero);
		if (result != IntPtr.Zero)
		{
			return Application.Current.Windows.OfType<Window>().FirstOrDefault((Window x) => x.IsVisible && new WindowInteropHelper(x).Handle == result);
		}
		return null;
	}

	public static bool GetBlurMainWindowAndHideAllOthers(Window element)
	{
		return (bool)((DependencyObject)element).GetValue(BlurMainWindowAndHideAllOthersProperty);
	}

	public static void SetBlurMainWindowAndHideAllOthers(Window element, bool value)
	{
		((DependencyObject)element).SetValue(BlurMainWindowAndHideAllOthersProperty, (object)value);
	}

	private static void BlurMainWindowAndHideAllOthersChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnBlurMainWindowAndHideAllOthersChanged((Window)(object)callerObject, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnBlurMainWindowAndHideAllOthersChanged(Window window, bool blurMainWindowAndHideAllOthers)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		if (blurMainWindowAndHideAllOthers)
		{
			if (window.IsVisible)
			{
				DoBlurMaindWindowAndHideAllOthers(window);
			}
			object obj = _003C_003EO._003C4_003E__Window_OnVisibilityChanged_UpdateBlurMainWindowAndHideAllOthers;
			if (obj == null)
			{
				DependencyPropertyChangedEventHandler val = Window_OnVisibilityChanged_UpdateBlurMainWindowAndHideAllOthers;
				_003C_003EO._003C4_003E__Window_OnVisibilityChanged_UpdateBlurMainWindowAndHideAllOthers = val;
				obj = (object)val;
			}
			window.IsVisibleChanged += (DependencyPropertyChangedEventHandler)obj;
		}
		else
		{
			DoUnblurMainWindowAndShowAllOthers(window);
			object obj2 = _003C_003EO._003C4_003E__Window_OnVisibilityChanged_UpdateBlurMainWindowAndHideAllOthers;
			if (obj2 == null)
			{
				DependencyPropertyChangedEventHandler val2 = Window_OnVisibilityChanged_UpdateBlurMainWindowAndHideAllOthers;
				_003C_003EO._003C4_003E__Window_OnVisibilityChanged_UpdateBlurMainWindowAndHideAllOthers = val2;
				obj2 = (object)val2;
			}
			window.IsVisibleChanged -= (DependencyPropertyChangedEventHandler)obj2;
		}
	}

	private static void Window_OnVisibilityChanged_UpdateBlurMainWindowAndHideAllOthers(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (sender is Window window)
		{
			object newValue = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
			if (newValue is bool && (bool)newValue && GetBlurMainWindowAndHideAllOthers(window))
			{
				DoBlurMaindWindowAndHideAllOthers(window);
			}
			else
			{
				DoUnblurMainWindowAndShowAllOthers(window);
			}
		}
	}

	private static void DoBlurMaindWindowAndHideAllOthers(Window sender)
	{
		Window mainWindow = MainWindow();
		if (mainWindow != null && mainWindow != sender)
		{
			mainWindow.Effect = new BlurEffect
			{
				KernelType = KernelType.Gaussian,
				Radius = 30.0,
				RenderingBias = RenderingBias.Quality
			};
		}
		List<Window> list = (from Window w in Application.Current.Windows
			where w.IsVisible && w != sender && w != mainWindow
			select w).ToList();
		foreach (Window item in list)
		{
			Log.Debug($"Hiding window with title {item.Title} and type {((object)item).GetType()} for blur effect");
			item.Visibility = Visibility.Hidden;
		}
		((DependencyObject)sender).SetValue(WindowsHiddenByBlurProperty, (object)list);
	}

	private static void DoUnblurMainWindowAndShowAllOthers(Window sender)
	{
		Window window = MainWindow();
		if (window != null && window != sender)
		{
			window.Effect = null;
		}
		if (((DependencyObject)sender).GetValue(WindowsHiddenByBlurProperty) is IList<Window> source)
		{
			try
			{
				foreach (Window item in source.Where((Window w) => w.IsLoaded && Application.Current.Windows.OfType<Window>().Contains(w)))
				{
					Log.Debug($"Showing window with title {item.Title} and type {((object)item).GetType()} for blur effect");
					item.Visibility = Visibility.Visible;
				}
			}
			catch (Exception e)
			{
				UIServiceProvider.GetService<IErrorReporter>().Error(e, "Error while showing windows hidden by blur effect");
			}
		}
		((DependencyObject)sender).SetValue(WindowsHiddenByBlurProperty, (object)null);
	}
}
