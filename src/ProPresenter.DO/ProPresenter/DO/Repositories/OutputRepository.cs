using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Logging;
using Pro.DO.Effects.Descriptions;
using Pro.DO.Transitions;
using Pro.ssAPI.Devices;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Audio;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.DO.Repositories;

public class OutputRepository : IOutputRepository
{
	public VideoInputDeviceCollection VideoInputDeviceCollection { get; }

	public VideoOutputDeviceCollection VideoOutputDeviceCollection { get; }

	public AudioInputDeviceCollection AudioInputDeviceCollection { get; }

	public AudioOutputDeviceCollection AudioOutputDeviceCollection { get; }

	public IReadOnlyList<EffectDescription> AvailableEffects { get; }

	public AudienceScreenArrangementCollection AudienceScreenArrangementCollection { get; }

	public StageScreenArrangementCollection StageScreenArrangementCollection { get; }

	public ILiveVideoInputCollection AvailableLiveVideoInputs { get; }

	public IAudioInputCollection AvailableAudioInputs { get; }

	public ITransitionDescriptionCollection AvailableTransitions { get; }

	public OutputRepository(ITransitionDescriptionCollection availableTransitions, VideoInputDeviceCollection videoInputDeviceCollection, VideoOutputDeviceCollection videoOutputDeviceCollection, AudioInputDeviceCollection audioInputDeviceCollection, AudioOutputDeviceCollection audioOutputDeviceCollection, IReadOnlyList<EffectDescription> effectDescriptionCollection, IOutputConfiguration outputConfiguration, ILiveVideoInputCollection videoInputs, IAudioInputCollection audioInputs)
	{
		Log.Info("Initializing the output repository...");
		AvailableTransitions = availableTransitions;
		VideoInputDeviceCollection = videoInputDeviceCollection;
		VideoOutputDeviceCollection = videoOutputDeviceCollection;
		AudioInputDeviceCollection = audioInputDeviceCollection;
		AudioOutputDeviceCollection = audioOutputDeviceCollection;
		AvailableEffects = effectDescriptionCollection;
		AudienceScreenArrangementCollection = outputConfiguration.AudienceArrangementScreens;
		StageScreenArrangementCollection = outputConfiguration.StageArrangementScreens;
		AvailableLiveVideoInputs = videoInputs;
		AvailableAudioInputs = audioInputs;
		Log.Info("Done initializing the output repository");
		RecordAnalytics(outputConfiguration);
	}

	private void RecordAnalytics(IOutputConfiguration outputConfiguration)
	{
		StartupLooksEvent.Publish(outputConfiguration.AudienceLooks.Count);
		RecordScreens();
	}

	private void RecordScreens()
	{
		RecordScreenSummary();
		foreach (ScreenArrangementBase screenArrangement in AudienceScreenArrangementCollection.Concat(StageScreenArrangementCollection))
		{
			RecordScreenArrangement(screenArrangement);
			screenArrangement.Screens.Where((Screen s) => s.IsConfigured).ForEach(delegate(Screen s)
			{
				RecordOutput(s, screenArrangement.ArrangementType.ToScreenType());
			});
		}
	}

	private void RecordScreenSummary()
	{
		StartupScreenConfigSummaryEvent.Publish(AudienceScreenArrangementCollection?.Count ?? 0, StageScreenArrangementCollection?.Count ?? 0);
	}

	private static void RecordScreenArrangement(ScreenArrangementBase screenArrangement)
	{
		ProScreenType screenType = screenArrangement.ScreenTargetType.ToScreenType();
		bool backgroundEnabled = screenArrangement.BackgroundEnabled;
		if (!(screenArrangement is SingleScreenArrangement singleScreenArrangement))
		{
			if (!(screenArrangement is EdgeBlendScreenArrangement edgeBlendScreenArrangement))
			{
				if (screenArrangement is CombinedScreenArrangement combinedScreenArrangement)
				{
					StartupScreenConfigGroupedEvent.Publish(screenType, backgroundEnabled, combinedScreenArrangement.ColumnCount, combinedScreenArrangement.RowCount);
				}
			}
			else
			{
				StartupScreenConfigEdgeBlendEvent.Publish(screenType, backgroundEnabled, edgeBlendScreenArrangement.ScreenCount);
			}
		}
		else if (singleScreenArrangement.ArrangementType == ScreenArrangementType.Single)
		{
			StartupScreenConfigSingleEvent.Publish(screenType, backgroundEnabled);
		}
		else
		{
			StartupScreenConfigMirroredEvent.Publish(screenType, backgroundEnabled, singleScreenArrangement.ScreenCount);
		}
	}

	private static void RecordOutput(Screen screen, ScreenType screenType)
	{
		StartupScreenConfigOutputEvent.Publish(screen.MainOutput.SubrectTargetMode.ToScreenAlignment(), screenType, screen.MainOutputDevice?.DeviceType.ToOutputType() ?? OutputType.Placeholder, colorCorrectionEnabled: true, screen.CornerPinning.IsEnabled, screen.OutputSize.Cast<int>(), screen.AlphaBlendMode, screen.GetAlphaKeyOutputDevice());
	}
}
