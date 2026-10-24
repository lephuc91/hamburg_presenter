using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.DO.Export;

public static class ExportPrompt
{
	public delegate void ExportStartedDelegate(IExportProcess process);

	public delegate BitmapSource? RenderImageDelegate(CustomSlide slide, Color secondaryBackgroundColor, bool includeBackground, bool includeMedia);

	private static ExportStartedDelegate? _exportStarted;

	private static RenderImageDelegate? _renderImage;

	public static void SetExportStarted(ExportStartedDelegate exportStarted)
	{
		if (_exportStarted != null)
		{
			throw new InvalidOperationException();
		}
		_exportStarted = exportStarted;
	}

	public static void SetRenderImage(RenderImageDelegate renderImage)
	{
		if (_renderImage != null)
		{
			throw new InvalidOperationException();
		}
		_renderImage = renderImage;
	}

	internal static void ExportStarted(IExportProcess process)
	{
		_exportStarted?.Invoke(process);
	}

	internal static BitmapSource? RenderImage(CustomSlide slide, Color secondaryBackgroundColor, bool includeBackground, bool includeMedia)
	{
		return _renderImage?.Invoke(slide, secondaryBackgroundColor, includeBackground, includeMedia);
	}
}
