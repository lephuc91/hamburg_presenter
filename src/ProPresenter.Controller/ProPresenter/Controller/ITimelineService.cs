using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pro.Common.Time;
using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.Controller;

public interface ITimelineService
{
	IEnumerable<TriggerHandle> ActiveSessions { get; }

	event Action<(TriggerHandle, TimedPlaybackStatus)> UpdateStatus;

	event Action<OutputDestination> StopRequested;

	Task<TriggerHandle> CreateSessionAsync(IDocumentCue document);

	Task DestroySessionAsync(TriggerHandle handle);

	Task PlayAsync(TriggerHandle handle);

	Task RecordAsync(TriggerHandle handle, bool isRecording);

	Task PauseAsync(TriggerHandle handle);

	Task ResetAsync(TriggerHandle handle);

	Task JumpToTimeAsync(TriggerHandle handle, TimeSlice time);

	Task StartScrubAsync(TriggerHandle handle, TimeSlice time);

	Task EndScrubAsync(TriggerHandle handle, TimeSlice time);

	Task SetDurationAsync(IDocumentCue? documentCue, TriggerHandle handle);

	Task SetToLoopAsync(TriggerHandle handle, bool shouldLoop);

	Task UpdateItemsAsync(IDocumentCue? document, TriggerHandle handle);

	Task<TimedPlaybackStatus> GetStatusAsync(TriggerHandle handle);

	void StopTimeline(OutputDestination destination);
}
