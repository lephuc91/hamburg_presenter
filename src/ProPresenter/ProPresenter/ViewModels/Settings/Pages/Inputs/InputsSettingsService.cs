using System;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.DO.Storage;
using Pro.ssAPI.Devices;
using ProPresenter.DO.Audio;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Repositories;
using ProPresenter.DO.Settings;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.ViewModels.Settings.Pages.Inputs;

public class InputsSettingsService : IInputsSettingsService
{
	private const int MAX_INPUT_COUNT = 64;

	private static readonly Vector2<int> PREVIEW_SIZE = new Vector2<int>(960, 540);

	private readonly IOutputRepository _outputRepo;

	private readonly IProCoreInstance _procore;

	public IVideoInputDeviceCollection VideoInputDeviceCollection => _outputRepo.VideoInputDeviceCollection;

	public IAudioInputDeviceCollection AudioInputDeviceCollection => _outputRepo.AudioInputDeviceCollection;

	public ILiveVideoInputCollection AvailableLiveVideoInputs => _outputRepo.AvailableLiveVideoInputs;

	public IAudioInputCollection AvailableAudioInputs => _outputRepo.AvailableAudioInputs;

	public InputsSettingsService(IOutputRepository outputRepo, IProCoreInstance procore, IApp app)
	{
		_outputRepo = outputRepo;
		_procore = procore;
	}

	public LiveVideoInput? AddVideoInput()
	{
		_outputRepo.AvailableLiveVideoInputs.InputCount++;
		return _outputRepo.AvailableLiveVideoInputs.LastOrDefault();
	}

	public bool CanAddVideoInput()
	{
		return _outputRepo.AvailableLiveVideoInputs.InputCount < 64;
	}

	public void RemoveLiveVideoInput(LiveVideoInput liveVideoInput)
	{
		_outputRepo.AvailableLiveVideoInputs.RemoveInput(liveVideoInput);
	}

	public bool TryCaptureVideoInputThumbnail(Guid liveVideoInputID, string thumbnailFolder, out RelativePath thumbnailImageFile)
	{
		try
		{
			BitmapSource videoInputPreviewSnapshot = _procore.GetVideoInputPreviewSnapshot(PREVIEW_SIZE.X, PREVIEW_SIZE.Y);
			if (videoInputPreviewSnapshot == null)
			{
				thumbnailImageFile = RelativePath.Empty();
				return false;
			}
			string text = Path.Combine(thumbnailFolder, $"{liveVideoInputID}.png");
			videoInputPreviewSnapshot.TryWriteImage(text);
			thumbnailImageFile = new RelativePath(text);
			return true;
		}
		catch (Exception value)
		{
			Log.Error($"Failed to execute command {"TryCaptureVideoInputThumbnail"} with error - {value}");
			thumbnailImageFile = RelativePath.Empty();
			return false;
		}
	}

	public AudioInput AddAudioInput()
	{
		return _outputRepo.AvailableAudioInputs.AddInput();
	}

	public bool CanAddAudioInput()
	{
		return _outputRepo.AvailableAudioInputs.Count < 64;
	}

	public void RemoveAudioInput(AudioInput audioInput)
	{
		_outputRepo.AvailableAudioInputs.RemoveInput(audioInput);
	}

	public void RenderPreview(nint texture, Vector2<int> textureSize)
	{
		_procore.RenderOutputPreview(ProRenderViewType.VideoInputPreferenceTab, texture, textureSize.X, textureSize.Y);
	}
}
