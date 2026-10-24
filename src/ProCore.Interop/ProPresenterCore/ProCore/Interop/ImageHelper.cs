using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;

namespace ProPresenterCore.ProCore.Interop;

internal static class ImageHelper
{
	public static void Encode(this BitmapSource source, ref nint targetImage, ref uint targetSize)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		using MemoryStream memoryStream = new MemoryStream();
		JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder();
		jpegBitmapEncoder.QualityLevel = 90;
		jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(source));
		jpegBitmapEncoder.Save(memoryStream);
		byte[] buffer = memoryStream.GetBuffer();
		int num = (int)memoryStream.Length;
		targetImage = ProCore.DataTransferAlloc((uint)num);
		targetSize = (uint)num;
		Marshal.Copy(buffer, 0, targetImage, num);
	}
}
