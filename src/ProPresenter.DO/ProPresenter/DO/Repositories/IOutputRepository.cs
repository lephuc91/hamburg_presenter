using System.Collections.Generic;
using Pro.DO.Effects.Descriptions;
using Pro.DO.Transitions;
using Pro.ssAPI.Devices;
using ProPresenter.DO.Audio;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.DO.Repositories;

public interface IOutputRepository
{
	VideoInputDeviceCollection VideoInputDeviceCollection { get; }

	AudioInputDeviceCollection AudioInputDeviceCollection { get; }

	IReadOnlyList<EffectDescription> AvailableEffects { get; }

	ITransitionDescriptionCollection AvailableTransitions { get; }

	AudienceScreenArrangementCollection AudienceScreenArrangementCollection { get; }

	StageScreenArrangementCollection StageScreenArrangementCollection { get; }

	ILiveVideoInputCollection AvailableLiveVideoInputs { get; }

	IAudioInputCollection AvailableAudioInputs { get; }

	VideoOutputDeviceCollection VideoOutputDeviceCollection { get; }
}
