using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Pro.Common.Time;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Communication.MIDI;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Props;
using ProPresenter.DO.Timer;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.Controller.Outputs.Communication;

public class MIDIExecutor : IMIDIExecutor
{
	private readonly ICoreManager _manager;

	private readonly ITimelineManager _timelineManager;

	private readonly ITriggering _service;

	private bool _isVideoPlaying;

	public MIDIExecutor(ICoreManager manager, ITriggeringFactory triggeringFactory, ITimelineManager timelineManager)
	{
		_manager = manager;
		_timelineManager = timelineManager;
		_service = triggeringFactory.Create(TriggerSource.MIDI);
		_manager.TransportStatusChanged += delegate(ResourceAddress _, ProTransportStatus t)
		{
			_isVideoPlaying = t.IsPlaying;
		};
	}

	public void ClearAll()
	{
		_manager.ClearAll();
	}

	public void ClearSlide()
	{
		_service.ClearSlide();
	}

	public void ClearBackground()
	{
		_service.ClearBackground();
	}

	public void ClearAnnouncements()
	{
		_service.ClearAnnouncement();
	}

	public void ClearProps()
	{
		_service.ClearProps();
	}

	public void ClearMessages()
	{
		_service.ClearMessages();
	}

	public void ClearAudio()
	{
		_service.ClearAudio();
	}

	public void TriggerLogo()
	{
		_manager.TriggerLogo();
	}

	public void RestartBackgroundVideo()
	{
		_manager.SetPresentationBackgroundPos(TimeSlice.Zero);
	}

	public void ToggleVideo()
	{
		(_isVideoPlaying ? new Action(PauseVideo) : new Action(PlayVideo))();
	}

	public void PlayVideo()
	{
		_manager.PlayPresentationBackground();
	}

	public void PauseVideo()
	{
		_manager.PausePresentationBackground();
	}

	public void GoToNextPlaylistItem()
	{
		TrySelectPlaylistItem(_manager.NextPresentation);
	}

	public void GoToPreviousPlaylistItem()
	{
		TrySelectPlaylistItem(_manager.PreviousPresentation);
	}

	public void TriggerNextSlide()
	{
		_service.TriggerNextSlide();
	}

	public void TriggerPreviousSlide()
	{
		_service.TriggerPreviousSlide();
	}

	public void StartTimeline()
	{
		if (TryGetActiveTimeline(out IDocumentCue document))
		{
			_timelineManager.Play(document, null);
		}
	}

	public void PauseTimeline()
	{
		if (TryGetActiveTimeline(out IDocumentCue document))
		{
			_timelineManager.Pause(document);
		}
	}

	public void ResetTimeline()
	{
		if (TryGetActiveTimeline(out IDocumentCue document))
		{
			_timelineManager.Reset(document);
		}
	}

	public void SelectPlaylist(Playlist<ProPresenterCue>? playlist)
	{
		_manager.ActiveLibraryPlaylist = playlist ?? _manager.ActiveLibraryPlaylist;
	}

	public void SelectPlaylistItem(int index)
	{
		TrySelectPlaylistItem(_manager.ActiveLibraryPlaylist?.Where((ProPresenterCue p) => !p.IsHidden).ElementAtOrDefault(index));
	}

	public void TriggerSlide(int index)
	{
		ArrangedCue arrangedCue = GetActiveDocument()?.DocumentAction?.ActiveArrangement?.ArrangedCues.ElementAtOrDefault(index);
		if (arrangedCue != null)
		{
			_service.TriggerSlide(arrangedCue);
		}
	}

	public void SelectVisualPlaylist(VisualPlaylist? visualPlaylist)
	{
		_manager.ActiveVisualPlaylist = visualPlaylist ?? _manager.ActiveVisualPlaylist;
	}

	public void TriggerVisualCue(int index)
	{
		VisualPlaylist activeVisualPlaylist = _manager.ActiveVisualPlaylist;
		MediaCue mediaCue = activeVisualPlaylist?.ElementAtOrDefault(index);
		if (mediaCue != null)
		{
			_service.TriggerBackground(mediaCue, activeVisualPlaylist);
		}
	}

	public void SelectAudioPlaylist(AudioPlaylist? audioPlaylist)
	{
		_manager.ActiveAudioPlaylist = audioPlaylist ?? _manager.ActiveAudioPlaylist;
	}

	public void TriggerAudioCue(int index)
	{
		AudioPlaylist activeAudioPlaylist = _manager.ActiveAudioPlaylist;
		MediaCue mediaCue = activeAudioPlaylist?.ElementAtOrDefault(index);
		if (mediaCue != null)
		{
			_service.TriggerAudio(mediaCue, activeAudioPlaylist);
		}
	}

	public void ToggleProp(IPropCue prop)
	{
		_service.ToggleProp(prop, PropTrigger.Trigger);
	}

	public void StartTimer(TimerData timer)
	{
		_service.TriggerTimerAction(timer, TimerActionType.Start, null);
	}

	public void StopTimer(TimerData timer)
	{
		_service.TriggerTimerAction(timer, TimerActionType.Stop, null);
	}

	public void ResetTimer(TimerData timer)
	{
		_service.TriggerTimerAction(timer, TimerActionType.ResetAndStart, null);
	}

	public void TriggerMacro(ProPresenterMacro macro)
	{
		_service.TriggerMacro(macro);
	}

	public void SelectMacroGroup(int index)
	{
		_manager.ChangeActiveMacroGroup(index);
	}

	public void SelectPropGroup(int index)
	{
		_manager.ChangeActivePropGroup(index);
	}

	private void TrySelectPlaylistItem(ProPresenterCue? cue)
	{
		_manager.ActivePlaylistItem = cue ?? _manager.ActivePlaylistItem;
	}

	private IDocumentCue? GetActiveDocument()
	{
		return _manager.ActivePlaylistItem as IDocumentCue;
	}

	private bool TryGetActiveTimeline([NotNullWhen(true)] out IDocumentCue? document)
	{
		document = GetActiveDocument();
		return document != null;
	}
}
