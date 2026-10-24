using System;
using System.Collections.Generic;
using System.Linq;
using Pro.DO.Effects.Descriptions;
using Pro.ssAPI.Devices;
using ProPresenter.DO.Audio;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Repositories;

namespace ProPresenter.DO;

public static class OutputVault
{
	private static IOutputRepository? _outputRepository;

	public static VideoInputDeviceCollection? VideoInputDeviceCollection => _outputRepository?.VideoInputDeviceCollection;

	public static VideoOutputDeviceCollection? VideoOuputDeviceCollection => _outputRepository?.VideoOutputDeviceCollection;

	public static AudioInputDeviceCollection? AudioInputDeviceCollection => _outputRepository?.AudioInputDeviceCollection;

	public static IReadOnlyList<EffectDescription>? AvailableEffects => _outputRepository?.AvailableEffects;

	public static AudienceScreenArrangementCollection? AudienceScreenArrangementCollection => OutputConfiguration?.AudienceArrangementScreens;

	public static StageScreenArrangementCollection? StageScreenArrangementCollection => OutputConfiguration?.StageArrangementScreens;

	public static IEnumerable<ScreenArrangementBase> AllScreens
	{
		get
		{
			IEnumerable<ScreenArrangementBase> audienceScreenArrangementCollection = AudienceScreenArrangementCollection;
			IEnumerable<ScreenArrangementBase> first = audienceScreenArrangementCollection ?? Enumerable.Empty<ScreenArrangementBase>();
			audienceScreenArrangementCollection = StageScreenArrangementCollection;
			IEnumerable<ScreenArrangementBase> second = audienceScreenArrangementCollection ?? Enumerable.Empty<ScreenArrangementBase>();
			return first.Concat(second);
		}
	}

	public static ILiveVideoInputCollection? AvailableLiveVideoInputs => _outputRepository?.AvailableLiveVideoInputs;

	public static IAudioInputCollection? AvailableAudioInputs => _outputRepository?.AvailableAudioInputs;

	public static IOutputConfiguration? OutputConfiguration { get; private set; }

	public static void Initialize(IOutputRepository outputRepository, IOutputConfiguration outputConfiguration)
	{
		if (_outputRepository != null)
		{
			throw new InvalidOperationException("Trying to initialize the output vault more than once.");
		}
		_outputRepository = outputRepository;
		OutputConfiguration = outputConfiguration;
	}
}
