using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media.Imaging;
using Pro.Common.Logging;
using Pro.Common.Utility;
using ProPresenter.DO.Import;

namespace ProPresenter.ViewModels.Editor;

public class ClipboardProvider : IClipboardProvider
{
	public bool ContainsData<T>()
	{
		return ClipboardManager.ContainsData<T[]>();
	}

	public IEnumerable<T>? GetData<T>()
	{
		return ClipboardManager.GetData<T[]>();
	}

	public void SetData<T>(T data)
	{
		ClipboardManager.SetData(data);
	}

	public bool ContainsImage()
	{
		try
		{
			return Clipboard.ContainsImage();
		}
		catch (Exception ex) when (((ex is COMException || ex is ExternalException) ? 1 : 0) != 0)
		{
			Log.Error("System clipboard locked; unable to check for image data: {0}\n{1}", ex.Message, ex.StackTrace);
			return false;
		}
	}

	public string? GetImage()
	{
		BitmapSource image;
		try
		{
			image = Clipboard.GetImage();
		}
		catch (Exception ex) when (((ex is COMException || ex is ExternalException) ? 1 : 0) != 0)
		{
			Log.Error("System clipboard locked; unable to retrieve image data: {0}\n{1}", ex.Message, ex.StackTrace);
			return null;
		}
		if (image == null)
		{
			return null;
		}
		string text = Path.Combine(ImportHelper.GetTempDirectory(), $"{Guid.NewGuid()}.jpg");
		try
		{
			using FileStream stream = new FileStream(text, FileMode.Create);
			JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder();
			jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(image));
			jpegBitmapEncoder.Save(stream);
			return text;
		}
		catch (Exception ex2)
		{
			Log.Error("Failed to encode or save clipboard image to temporary path: {0}\n{1}", ex2.Message, ex2.StackTrace);
			Log.Error(ex2);
			return null;
		}
	}
}
