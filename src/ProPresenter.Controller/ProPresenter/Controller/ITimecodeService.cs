using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Timecode;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.Controller;

public interface ITimecodeService : INotifyPropertyChanged
{
	TriggerHandle? ActiveSessionHandle { get; }

	TimedPlaybackStatus? CurrentTimecodePlaybackStatus { get; }

	ITimecodeSettings ActiveTimecodeSettings { get; }

	bool IsPolling { get; }

	void StartTimecodePolling();

	void StopTimecodePolling();

	Task CreateTimecodePlaybackSessionAsync(IEnumerable<TimecodeItem> items);

	Task DestroyTimecodePlaybackSessionAsync();

	Task UpdateSessionSequenceItemsAsync(IEnumerable<TimecodeItem> items);

	Task TimecodeCaptureStartAsync();

	Task TimecodeCaptureStopAsync();

	Task UpdateTimecodeSettingsAsync(TimedPlayback proto);

	Task Engage(bool engage);

	TimecodeInformation GetTimecodeInformation();

	bool CanFollow(IDocumentCue? document);
}
