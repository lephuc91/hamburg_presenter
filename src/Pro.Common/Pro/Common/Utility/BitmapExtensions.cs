using System;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using Pro.Common.Win32;

namespace Pro.Common.Utility;

public static class BitmapExtensions
{
	public static BitmapSource ToBitmapSource(this Bitmap bitmap)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		nint hbitmap = bitmap.GetHbitmap();
		BitmapSource bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
		WindowsFunctions.DeleteObject(hbitmap);
		((Freezable)bitmapSource).Freeze();
		return bitmapSource;
	}
}
