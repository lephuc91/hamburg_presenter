using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using Pro.Common.Win32;

namespace Pro.UI.DragDropHelper;

public class DragVisualWindow : Window
{
	public DragVisualWindow()
	{
		base.WindowStyle = WindowStyle.None;
		base.Topmost = true;
		base.AllowsTransparency = true;
		base.Background = new SolidColorBrush(Colors.Transparent);
		base.ShowInTaskbar = false;
		base.Focusable = false;
		base.Title = "DRAG_VISUAL_WINDOW";
	}

	protected override void OnSourceInitialized(EventArgs e)
	{
		nint hWnd = new WindowInteropHelper(this).EnsureHandle();
		WindowsFunctions.SetWindowLong(hWnd, GWL.EXSTYLE, (nint)(uint)((int)WindowsFunctions.GetWindowLong(hWnd, GWL.EXSTYLE) | 0x20));
		base.OnSourceInitialized(e);
	}
}
