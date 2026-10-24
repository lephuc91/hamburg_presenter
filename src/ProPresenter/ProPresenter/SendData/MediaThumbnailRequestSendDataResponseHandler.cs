using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Google.Protobuf;
using Pro.Common.Dispatcher;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Media;
using ProPresenter.DO.Repositories;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.SendDataHandlers;

namespace ProPresenter.SendData;

public class MediaThumbnailRequestSendDataResponseHandler : ISendDataResponseHandler
{
	private readonly IProCoreInstance _procore;

	private readonly IUiDispatcher _dispatcher;

	private readonly IApp _app;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IOutputRepository _outputRepository;

	public MediaThumbnailRequestSendDataResponseHandler(IProCoreInstance proCoreInstance, IUiDispatcher uiDispatcher, IApp app, IProPresenterDOFactoryProvider factoryProvider, IOutputRepository outputRepository)
	{
		_procore = proCoreInstance;
		_dispatcher = uiDispatcher;
		_app = app;
		_factoryProvider = factoryProvider;
		_outputRepository = outputRepository;
	}

	public bool CanHandle(SendDataResponse.MessageTypeOneofCase sendDataResponseType)
	{
		return sendDataResponseType == SendDataResponse.MessageTypeOneofCase.GetMediaThumbnail;
	}

	public async Task Handle(SendDataResponse? sendDataResponse)
	{
		if (sendDataResponse?.GetMediaThumbnail != null)
		{
			await _dispatcher.InvokeAsync((Func<Task>)async delegate
			{
				BitmapSource bitmapSource = await GetPreview(GetMedia(sendDataResponse.GetMediaThumbnail));
				Pro.SerializationInterop.RVProtoData.SendData data = new Pro.SerializationInterop.RVProtoData.SendData
				{
					MessageId = sendDataResponse.MessageId,
					MediaThumbnail = new MediaThumbnail
					{
						Width = 0,
						Height = 0,
						Stride = 0uL,
						Data = (bitmapSource?.ToByteString() ?? ByteString.Empty)
					}
				};
				_procore.SendData(data, out var _);
			}, default(CancellationToken));
		}
	}

	private MediaBase? GetMedia(GetMediaThumbnail request)
	{
		Media media = request.Media;
		if (media != null)
		{
			IFill fill = FillGenerator.DeserializeFill(new Graphics.Types.Fill
			{
				Media = media
			}, _factoryProvider.MediaFactory, "");
			if (fill is LiveVideoFill liveVideoFill)
			{
				return liveVideoFill.LiveVideo;
			}
			if (fill is MediaFill mediaFill)
			{
				return mediaFill.Media;
			}
		}
		else
		{
			Pro.SerializationInterop.RVProtoData.Action action = request.Action;
			if (action != null)
			{
				MediaAction mediaAction = MediaAction.ConstructMediaAction(action, _app, _factoryProvider.MediaFactory, _outputRepository.AvailableTransitions, "");
				mediaAction.Deserialize(action, new ApplicationData(ApplicationType.ProPresenter), "");
				return mediaAction.Media;
			}
		}
		return null;
	}

	private static async Task<BitmapSource?> GetPreview(MediaBase? media)
	{
		if (media is LiveVideoMedia liveVideoMedia)
		{
			if (liveVideoMedia.Drawing.PreviewImage != null)
			{
				return liveVideoMedia.Drawing.PreviewImage;
			}
			LiveVideoInput input = liveVideoMedia.LiveVideo.Input;
			if (input != null && input.HasThumbnail)
			{
				return ImageHelper.LoadImage(input.ThumbnailPath);
			}
		}
		else if (media is VisualMedia visualMedia)
		{
			TaskCompletionSource completionSource = new TaskCompletionSource();
			Action<FileMediaBase> value = delegate
			{
				completionSource.TrySetResult();
			};
			visualMedia.MetadataLoadSuccessful += value;
			visualMedia.MetadataLoadFailed += value;
			if (!visualMedia.MetadataLoaded)
			{
				await completionSource.Task;
			}
			return visualMedia.Drawing.PreviewImage;
		}
		return null;
	}
}
