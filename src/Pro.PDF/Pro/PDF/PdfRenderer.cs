using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using PdfiumViewer;
using Pro.Common.Components;
using Pro.Common.Mathematics;

namespace Pro.PDF;

public class PdfRenderer : DisposableBase
{
	public enum RenderImageFormat
	{
		PNG,
		JPEG
	}

	private const string PdfiumDLL = "x64/pdfium.dll";

	private const float RenderDPI = 96f;

	private const double DefaultZoomLevel = 2.0;

	private PdfDocument _document;

	public int PageCount
	{
		get
		{
			EnsureValid();
			return _document.PageCount;
		}
	}

	static PdfRenderer()
	{
		PdfiumResolver.Resolve += delegate(object s, PdfiumResolveEventArgs e)
		{
			e.PdfiumFileName = "x64/pdfium.dll";
		};
	}

	public PdfRenderer(string pdfFilename)
	{
		_document = PdfDocument.Load(pdfFilename);
	}

	protected override void OnDispose(bool disposeObjects)
	{
		if (disposeObjects)
		{
			_document.Dispose();
		}
	}

	public void Load(string pdfFilename)
	{
		EnsureValid();
		_document = PdfDocument.Load(pdfFilename);
	}

	public Vector2<double> GetPageSize(int pageNumber)
	{
		EnsureValid();
		int pageIndexFromPageNumber = GetPageIndexFromPageNumber(pageNumber);
		SizeF sizeF = _document.PageSizes[pageIndexFromPageNumber];
		return new Vector2<double>(sizeF.Width, sizeF.Height);
	}

	public void RenderPageToPNGFile(string outputFile, int pageNumber, double zoomLevel = 2.0)
	{
		using Image image = RenderPage(pageNumber, zoomLevel);
		image.Save(outputFile, ImageFormat.Png);
	}

	public BitmapSource RenderPageToImage(int pageNumber, double zoomLevel = 2.0)
	{
		using MemoryStream streamSource = RenderPageToStream(pageNumber, RenderImageFormat.PNG, zoomLevel);
		BitmapImage bitmapImage = new BitmapImage();
		bitmapImage.BeginInit();
		bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
		bitmapImage.UriSource = null;
		bitmapImage.StreamSource = streamSource;
		bitmapImage.EndInit();
		((Freezable)bitmapImage).Freeze();
		return bitmapImage;
	}

	public MemoryStream RenderPageToStream(int pageNumber, RenderImageFormat format, double zoomLevel = 2.0)
	{
		using Image image = RenderPage(pageNumber, zoomLevel);
		MemoryStream memoryStream = new MemoryStream();
		ImageFormat imageFormat = null;
		image.Save(memoryStream, format switch
		{
			RenderImageFormat.PNG => ImageFormat.Png, 
			RenderImageFormat.JPEG => ImageFormat.Jpeg, 
			_ => throw new NotSupportedException(), 
		});
		return memoryStream;
	}

	private Image RenderPage(int pageNumber, double zoomLevel)
	{
		EnsureValid();
		int pageIndexFromPageNumber = GetPageIndexFromPageNumber(pageNumber);
		SizeF sizeF = _document.PageSizes[pageIndexFromPageNumber];
		Vector2<int> vector = (new Vector2<double>(sizeF.Width, sizeF.Height) * zoomLevel).Cast<int>();
		return _document.Render(pageIndexFromPageNumber, vector.X, vector.Y, 96f, 96f, PdfRenderFlags.CorrectFromDpi);
	}

	private int GetPageIndexFromPageNumber(int pageNumber)
	{
		int num = pageNumber - 1;
		if (num < 0 || num >= _document.PageCount)
		{
			throw new ArgumentOutOfRangeException("pageNumber");
		}
		return num;
	}
}
