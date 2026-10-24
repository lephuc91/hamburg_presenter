using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using Pro.Common.Utility;
using ProPresenter.UI.Utility;

namespace Pro.UI.Utility;

public class CustomIconProvider : ICustomIconProvider
{
	public bool TryGetIcon(out BitmapSource? icon, string selectedFile)
	{
		try
		{
			using FileStream stream = new FileStream(selectedFile, FileMode.Open);
			using Image image = Image.FromStream(stream);
			using Bitmap bitmap = new Bitmap(image, new Size(64, 64));
			using MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, new ImageFormat(image.RawFormat.Guid));
			icon = memoryStream.ToArray().ToBitmapSource();
			return true;
		}
		catch (Exception)
		{
			icon = null;
			return false;
		}
	}
}
