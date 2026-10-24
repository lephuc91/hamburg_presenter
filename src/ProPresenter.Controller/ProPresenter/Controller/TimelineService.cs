using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Time;
using Pro.DO.Storage;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Repos;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.Controller;

public class TimelineService : ITimelineService
{
	private bool _runCorePolling;

	private readonly List<TriggerHandle> _activeSession = new List<TriggerHandle>();

	private readonly ITimedPlaybackRepository _timedPlaybackRepository;

	public IEnumerable<TriggerHandle> ActiveSessions => _activeSession;

	public event Action<(TriggerHandle, TimedPlaybackStatus)>? UpdateStatus;

	public event Action<OutputDestination>? StopRequested;

	public TimelineService(ITimedPlaybackRepository timedPlaybackRepository)
	{
		_timedPlaybackRepository = timedPlaybackRepository;
		SetupTimer();
	}

	private void SetupTimer()
	{
		CompositionTarget.Rendering += async delegate
		{
			if (_runCorePolling)
			{
				TriggerHandle[] array = _activeSession.ToArray();
				foreach (TriggerHandle triggerHandle in array)
				{
					TimedPlaybackStatus item = await GetStatusAsync(triggerHandle);
					this.UpdateStatus?.Invoke((triggerHandle, item));
				}
			}
		};
	}

	public async Task<TriggerHandle> CreateSessionAsync(IDocumentCue document)
	{
		Timeline timeline = document.GetTimeline();
		if (timeline == null)
		{
			return TriggerHandle.Invalid;
		}
		TimedPlayback data = new TimedPlayback
		{
			Sequence = new TimedPlayback.Types.Sequence
			{
				Sequence_ = { timeline.Select((TimelineItemInfo i) => ToSequenceItem(i, document)).NonNull() },
				ContentDestination = document.DocumentAction.Destination.ToProtoDestination(),
				Presentation = document.DocumentAction?.Presentation?.Serialize(),
				Playlist = document.PlaylistParent?.ProtoSerialize()
			},
			Timing = new TimedPlayback.Types.Timing
			{
				Internal = new TimedPlayback.Types.Timing.Types.Internal
				{
					Duration = timeline.Duration.TotalSeconds,
					ShouldLoop = timeline.IsSetToLoop
				}
			}
		};
		TriggerHandle triggerHandle = await _timedPlaybackRepository.CreateTimedPlaybackSessionAsync(data);
		if ((object)triggerHandle == null)
		{
			triggerHandle = TriggerHandle.Invalid;
		}
		else
		{
			_activeSession.Add(triggerHandle);
			_runCorePolling = true;
		}
		return triggerHandle;
	}

	public async Task DestroySessionAsync(TriggerHandle handle)
	{
		_activeSession.Remove(handle);
		if (_activeSession.Empty())
		{
			_runCorePolling = false;
		}
		await _timedPlaybackRepository.DestroyTimedPlaybackSessionAsync(handle);
	}

	public async Task PlayAsync(TriggerHandle handle)
	{
		await UpdateTimelineAsync(handle, new TimedPlayback.Types.Update
		{
			Play = new TimedPlayback.Types.Update.Types.Play()
		});
	}

	public async Task RecordAsync(TriggerHandle handle, bool isRecording)
	{
		await UpdateTimelineAsync(handle, new TimedPlayback.Types.Update
		{
			Record = new TimedPlayback.Types.Update.Types.Record
			{
				IsRecording = isRecording
			}
		});
	}

	public async Task PauseAsync(TriggerHandle handle)
	{
		await UpdateTimelineAsync(handle, new TimedPlayback.Types.Update
		{
			Pause = new TimedPlayback.Types.Update.Types.Pause()
		});
	}

	public async Task ResetAsync(TriggerHandle handle)
	{
		await UpdateTimelineAsync(handle, new TimedPlayback.Types.Update
		{
			Reset = new TimedPlayback.Types.Update.Types.Reset()
		});
		this.UpdateStatus?.Invoke((handle, new TimedPlaybackStatus(0.0, TimedPlaybackState.Stopped, 0.0)));
	}

	public async Task JumpToTimeAsync(TriggerHandle handle, TimeSlice time)
	{
		await UpdateTimelineAsync(handle, new TimedPlayback.Types.Update
		{
			JumpToTime = new TimedPlayback.Types.Update.Types.JumpToTime
			{
				Time = ((time.Hours + time.Minutes + time.Seconds == 0L) ? 0.0 : time.TotalSeconds)
			}
		});
	}

	public async Task StartScrubAsync(TriggerHandle handle, TimeSlice time)
	{
		await UpdateTimelineAsync(handle, new TimedPlayback.Types.Update
		{
			StartScrub = new TimedPlayback.Types.Update.Types.StartScrub
			{
				Time = ((time.Hours + time.Minutes + time.Seconds == 0L) ? 0.0 : time.TotalSeconds)
			}
		});
	}

	public async Task EndScrubAsync(TriggerHandle handle, TimeSlice time)
	{
		await UpdateTimelineAsync(handle, new TimedPlayback.Types.Update
		{
			EndScrub = new TimedPlayback.Types.Update.Types.EndScrub
			{
				Time = ((time.Hours + time.Minutes + time.Seconds == 0L) ? 0.0 : time.TotalSeconds)
			}
		});
	}

	public async Task SetDurationAsync(IDocumentCue? documentCue, TriggerHandle handle)
	{
		Timeline timeline = documentCue?.GetTimeline();
		if (timeline != null)
		{
			TimeSlice duration = timeline.Duration;
			await UpdateItemsAsync(documentCue, handle);
			await UpdateTimelineAsync(handle, new TimedPlayback.Types.Update
			{
				Duration = new TimedPlayback.Types.Update.Types.Duration
				{
					Duration_ = duration.TotalSeconds
				}
			});
		}
	}

	public async Task SetToLoopAsync(TriggerHandle handle, bool shouldLoop)
	{
		await UpdateTimelineAsync(handle, new TimedPlayback.Types.Update
		{
			Loop = new TimedPlayback.Types.Update.Types.Loop
			{
				Loop_ = shouldLoop
			}
		});
	}

	public async Task UpdateItemsAsync(IDocumentCue? document, TriggerHandle handle)
	{
		Timeline timeline = document?.GetTimeline();
		if (timeline != null)
		{
			await UpdateTimelineAsync(handle, new TimedPlayback.Types.Update
			{
				UpdateSequence = new TimedPlayback.Types.Sequence
				{
					Sequence_ = { timeline.Select((TimelineItemInfo i) => ToSequenceItem(i, document)).NonNull() },
					ContentDestination = document.DocumentAction.Destination.ToProtoDestination(),
					Presentation = document.DocumentAction?.Presentation?.Serialize(),
					Playlist = document.PlaylistParent?.ProtoSerialize()
				}
			});
		}
	}

	public void StopTimeline(OutputDestination destination)
	{
		this.StopRequested?.Invoke(destination);
	}

	private async Task UpdateTimelineAsync(TriggerHandle handle, TimedPlayback.Types.Update update)
	{
		if (!(handle == TriggerHandle.Invalid))
		{
			await _timedPlaybackRepository.UpdateTimedPlaybackSessionAsync(handle, update);
		}
	}

	public async Task<TimedPlaybackStatus> GetStatusAsync(TriggerHandle handle)
	{
		return await _timedPlaybackRepository.GetTimedPlaybackSessionStatusAsync(handle);
	}

	private static TimedPlayback.Types.Sequence.Types.SequenceItem? ToSequenceItem(TimelineItemInfo item, IDocumentCue document)
	{
		if (document.DocumentAction?.Presentation == null)
		{
			return null;
		}
		Playlist<ProPresenterCue> playlistParent = document.PlaylistParent;
		TimeSlice duration = document.DocumentAction.Presentation.PresentationTimeline.Duration;
		if (playlistParent == null)
		{
			TimeSlice slideTime = item.SlideTime;
			OutputDestination destination = document.DocumentAction.Destination;
			RelativePath path = document.Path;
			return item.ToSequenceItem(slideTime, duration, destination, ((object)path != null) ? ((string)path) : string.Empty, document.DocumentAction.Presentation.Name, 0.0, ignoreCompletionAction: true);
		}
		return item.ToSequenceItem(item.SlideTime, duration, document.DocumentAction.Destination, playlistParent.ID, document.ID, 0.0, null, ignoreCompletionAction: true);
	}
}
