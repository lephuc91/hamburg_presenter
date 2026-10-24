using System.ComponentModel;
using Pro.Common.Time;
using Pro.DO.Triggering;
using Pro.ssAPI;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Settings;

public interface IImport : INotifyPropertyChanged
{
	AudioBehaviorType AudioPlaybackBehavior { get; set; }

	ScaleBehavior BackgroundScaleBehavior { get; set; }

	ScaleBehavior ForegroundScaleBehavior { get; set; }

	TimeSlice ImageDurationTime { get; set; }

	ImportLayer ImageLayer { get; set; }

	CompletionTargetType ImageNextBehavior { get; set; }

	ImportDurationType ImportDurationType { get; set; }

	int RandomMaxTime { get; set; }

	int RandomMinTime { get; set; }

	EndBehaviorType VideoEndBehavior { get; set; }

	ImportLayer VideoLayer { get; set; }

	CompletionTargetType VideoNextBehavior { get; set; }

	PlaybackBehaviorType VideoPlaybackBehavior { get; set; }

	void ApplyImportSettings(MediaCue mediaCue);
}
