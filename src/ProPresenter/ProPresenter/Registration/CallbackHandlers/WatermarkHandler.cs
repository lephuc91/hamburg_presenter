using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pro.Common.DataStore;
using Pro.Common.Logging;
using Pro.Common.Security;
using Pro.Common.Utility;
using Pro.CoreApplication.Registration.Interaction;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.Services;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Registration.CallbackHandlers;

public class WatermarkHandler : IRegistrationCallbackHandler
{
	private const string WatermarkHash = "533E54096956D307738447E3BA31FB1DE81215A1BA23EAAC807445661A68A67C";

	private const string WatermarkImageResourceName = "ProPresenter.images.watermark.png";

	private static readonly Typeface Typeface = new Typeface("Segoe UI");

	private static readonly string WatermarkTextUnregistered = LocalizedStrings.Get("REGISTRATION_WATERMARK_TEXT_UNREGISTERED_label");

	private static readonly string WatermarkTextSeatInactve = LocalizedStrings.Get("REGISTRATION_WATERMARK_TEXT_SEAT_INACTIVE_label");

	private readonly IProCoreInstance _proCoreInstance;

	private readonly ILogger _logger;

	private readonly BitmapImage? _watermarkImage;

	public WatermarkHandler(IEmbeddedResourceReader resourceReader, IProCoreInstance proCoreInstance, ILogger logger, IForcedShutdownMessageProvider forcedShutdownMessageProvider)
	{
		_proCoreInstance = proCoreInstance;
		_logger = logger;
		_watermarkImage = ReadWatermarkImage(resourceReader);
		if (_watermarkImage == null)
		{
			forcedShutdownMessageProvider.ShowForcedApplicationShutdownDialog(IForcedShutdownMessageProvider.ShutdownReason.Watermark);
		}
		else
		{
			proCoreInstance.DisableWatermark();
		}
	}

	public bool HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		if (responseCallback.CallbackCase == Callback.CallbackOneofCase.SetWatermark)
		{
			_logger.Info("Updating the watermark...");
			SetWatermark setWatermark = responseCallback.SetWatermark;
			if (setWatermark.IsRegistered && setWatermark.ActiveSeat)
			{
				_proCoreInstance.DisableWatermark();
			}
			else if (_watermarkImage != null)
			{
				using DisposableRenderTargetBitmap disposableRenderTargetBitmap = RenderTextBitmap(setWatermark.IsRegistered && !setWatermark.ActiveSeat);
				_proCoreInstance.EnableWatermark(_watermarkImage, disposableRenderTargetBitmap);
			}
			return true;
		}
		return false;
	}

	private static BitmapImage? ReadWatermarkImage(IEmbeddedResourceReader reader)
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		using Stream stream = reader.Read(executingAssembly, "ProPresenter.images.watermark.png");
		if (stream == null || "533E54096956D307738447E3BA31FB1DE81215A1BA23EAAC807445661A68A67C" != stream.Hash())
		{
			return null;
		}
		stream.Seek(0L, SeekOrigin.Begin);
		BitmapImage bitmapImage = new BitmapImage();
		bitmapImage.BeginInit();
		bitmapImage.StreamSource = stream;
		bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
		bitmapImage.EndInit();
		((Freezable)bitmapImage).Freeze();
		return bitmapImage;
	}

	private static DisposableRenderTargetBitmap RenderTextBitmap(bool showInactiveSeat)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		DrawingVisual drawingVisual = new DrawingVisual();
		FormattedText formattedText = new FormattedText(showInactiveSeat ? WatermarkTextSeatInactve : WatermarkTextUnregistered, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, 50.0, Brushes.White, 1.0);
		using (DrawingContext drawingContext = drawingVisual.RenderOpen())
		{
			drawingContext.DrawText(formattedText, default(Point));
		}
		DisposableRenderTargetBitmap disposableRenderTargetBitmap = new DisposableRenderTargetBitmap((int)formattedText.Width, (int)formattedText.Height, 96.0, 96.0, PixelFormats.Pbgra32);
		disposableRenderTargetBitmap.Render(drawingVisual);
		disposableRenderTargetBitmap.Freeze();
		return disposableRenderTargetBitmap;
	}
}
