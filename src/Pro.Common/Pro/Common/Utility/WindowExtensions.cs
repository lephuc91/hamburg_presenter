using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media;
using Pro.Common.Mathematics;

namespace Pro.Common.Utility;

public static class WindowExtensions
{
	private const double IdentityDpi = 96.0;

	public static Vector2<double> GetDpiScaleFactor(this Window window)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		PresentationSource presentationSource = PresentationSource.FromVisual(window);
		if (presentationSource != null)
		{
			Matrix transformToDevice = presentationSource.CompositionTarget.TransformToDevice;
			return new Vector2<double>(((Matrix)(ref transformToDevice)).M11, ((Matrix)(ref transformToDevice)).M22);
		}
		using Graphics graphics = Graphics.FromHwnd(IntPtr.Zero);
		return new Vector2<double>((double)graphics.DpiX / 96.0, (double)graphics.DpiY / 96.0);
	}

	public static void BringToTop(this Window window)
	{
		if (!window.IsVisible)
		{
			window.Show();
		}
		if (window.WindowState == WindowState.Minimized)
		{
			window.WindowState = WindowState.Normal;
		}
		window.Activate();
		window.Topmost = true;
		window.Topmost = false;
		window.Focus();
	}
}
