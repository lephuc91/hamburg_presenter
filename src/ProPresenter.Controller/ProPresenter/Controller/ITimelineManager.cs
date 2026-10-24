using System;
using System.Threading.Tasks;
using Pro.Common.Time;
using ProPresenter.DO.Cues;

namespace ProPresenter.Controller;

public interface ITimelineManager
{
	event Action<TimelineStatus>? StatusUpdated;

	void EndScrub(TimeSlice time, IDocumentCue documentCue);

	Task<TimedPlaybackStatus?> GetCurrentStatusAsync(IDocumentCue document);

	(bool isPlaying, bool isRecording, TimeSlice time) GetInfo(IDocumentCue? cue);

	void JumpToTime(TimeSlice time, IDocumentCue documentCue);

	void Pause(IDocumentCue? documentCue);

	void Play(IDocumentCue? documentCue, TimeSlice? initialTime = null);

	void Reset(IDocumentCue documentCue);

	void StartRecording(IDocumentCue documentCue);

	void StartScrub(TimeSlice time, IDocumentCue documentCue);

	Task StopTheActiveRecordingAsync(IDocumentCue except);

	void StopRecording(IDocumentCue documentCue);

	Task<bool> TryRegisterTimelineAsync(IDocumentCue cue);
}
