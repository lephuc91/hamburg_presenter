using System;
using Pro.Common.Mathematics;
using Pro.DO.Storage;
using Pro.ssAPI.Devices;
using ProPresenter.DO.Audio;
using ProPresenter.DO.LiveVideo;

namespace ProPresenter.ViewModels.Settings.Pages.Inputs;

public interface IInputsSettingsService
{
	IVideoInputDeviceCollection VideoInputDeviceCollection { get; }

	IAudioInputDeviceCollection AudioInputDeviceCollection { get; }

	ILiveVideoInputCollection AvailableLiveVideoInputs { get; }

	IAudioInputCollection AvailableAudioInputs { get; }

	LiveVideoInput? AddVideoInput();

	bool CanAddVideoInput();

	AudioInput AddAudioInput();

	bool CanAddAudioInput();

	void RemoveLiveVideoInput(LiveVideoInput liveVideoInput);

	void RemoveAudioInput(AudioInput audioInput);

	bool TryCaptureVideoInputThumbnail(Guid liveVideoInputID, string thumbnailFolder, out RelativePath thumbnailImageFile);

	void RenderPreview(nint texture, Vector2<int> textureSize);
}
