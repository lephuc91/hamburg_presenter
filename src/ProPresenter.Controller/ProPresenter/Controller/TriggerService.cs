using System;
using System.Collections.Generic;
using Pro.Common.Collections;
using Pro.Common.MessageService;
using Pro.Common.Time;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.ClearGroups;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Events;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Looks;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Messages;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Props;
using ProPresenter.DO.Timer;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller;

public class TriggerService : ITriggering
{
	private readonly IInternalCoreManager _manager;

	private readonly TriggerSource _triggerSource;

	private readonly IMessageService _messageService;

	public Playlist<ProPresenterCue>? ActiveLibraryPlaylist
	{
		get
		{
			return _manager.ActiveLibraryPlaylist;
		}
		set
		{
			_manager.ActiveLibraryPlaylist = value;
		}
	}

	public VisualPlaylist? ActiveVisualPlaylist
	{
		get
		{
			return _manager.ActiveVisualPlaylist;
		}
		set
		{
			_manager.ActiveVisualPlaylist = value;
		}
	}

	public AudioPlaylist? ActiveAudioPlaylist
	{
		get
		{
			return _manager.ActiveAudioPlaylist;
		}
		set
		{
			_manager.ActiveAudioPlaylist = value;
		}
	}

	public ILibrary? ActiveLibrary
	{
		get
		{
			return _manager.ActiveLibrary;
		}
		set
		{
			_manager.ActiveLibrary = value;
		}
	}

	public ProPresenterCue? ActivePlaylistItem
	{
		get
		{
			return _manager.ActivePlaylistItem;
		}
		set
		{
			_manager.ActivePlaylistItem = value;
		}
	}

	public ITransportStatus TransportStatus => _manager.TransportStatus;

	public INotifyEnumerableChanged<IPropCue> ActiveProps => _manager.ActiveProps;

	public bool AudienceEnable => _manager.AudienceEnable;

	public bool StageEnable => _manager.StageEnable;

	public ArrangedCue? ActiveSlide => _manager.ActiveSlide;

	public ArrangedCue? ActivePresentationSlide => _manager.ActivePresentationSlide;

	public ArrangedCue? NextPresentationSlide => _manager.NextPresentationSlide;

	public ProPresenterCue? ActiveSlideParent => _manager.ActiveSlideParent;

	public ProPresenterCue? ActivePresentationParent => _manager.ActivePresentationParent;

	public ProPresenterCue? ActiveAnnouncementParent => _manager.ActiveAnnouncementParent;

	public event SlideTriggeredAction SlideTriggered
	{
		add
		{
			if (_manager != null)
			{
				_manager.SlideTriggered += value;
			}
		}
		remove
		{
			if (_manager != null)
			{
				_manager.SlideTriggered -= value;
			}
		}
	}

	public event SlideClearedAction SlideCleared
	{
		add
		{
			if (_manager != null)
			{
				_manager.SlideCleared += value;
			}
		}
		remove
		{
			if (_manager != null)
			{
				_manager.SlideCleared -= value;
			}
		}
	}

	public event PresentationCueFocusChangedAction PresentationCueFocusChanged
	{
		add
		{
			if (_manager != null)
			{
				_manager.PresentationCueFocusChanged += value;
			}
		}
		remove
		{
			if (_manager != null)
			{
				_manager.PresentationCueFocusChanged -= value;
			}
		}
	}

	public TriggerService(IInternalCoreManager manager, IMessageService messageService, TriggerSource triggerSource = TriggerSource.Internal)
	{
		_manager = manager;
		_triggerSource = triggerSource;
		if (manager != null)
		{
			manager.LayerTriggered += delegate(ProLayerIndex l, ProResourceState s)
			{
				if (l.IsAnyOf(ProLayerIndex.UserLayerBegin, ProLayerIndex.PresentationForeground, ProLayerIndex.PresentationBackground, ProLayerIndex.AnnouncementsBackground, ProLayerIndex.AnnouncementsForeground, ProLayerIndex.Props, ProLayerIndex.Messages, ProLayerIndex.Music))
				{
					LayersStatusUpdated.Publish(l, s == ProResourceState.Activated);
				}
			};
		}
		_messageService = messageService;
	}

	public void ClearVideoInput()
	{
		_manager.ClearVideoInput(_triggerSource);
		if (_triggerSource == TriggerSource.Internal)
		{
			_messageService.PublishMessage(new ClearTypeTriggeredMessage(ClearType.LiveVideo));
		}
	}

	public void ClearBackground()
	{
		_manager.ClearBackground(_triggerSource);
		if (_triggerSource == TriggerSource.Internal)
		{
			_messageService?.PublishMessage(new ClearTypeTriggeredMessage(ClearType.Background));
		}
	}

	public void ClearSlide()
	{
		_manager.ClearSlide(_triggerSource);
		if (_triggerSource == TriggerSource.Internal)
		{
			_messageService?.PublishMessage(new ClearTypeTriggeredMessage(ClearType.Slide));
		}
	}

	public void ClearAnnouncement()
	{
		_manager.ClearAnnouncement(_triggerSource);
		if (_triggerSource == TriggerSource.Internal)
		{
			_messageService?.PublishMessage(new ClearTypeTriggeredMessage(ClearType.Announcement));
		}
	}

	public void ClearProps()
	{
		_manager.ClearProps(_triggerSource);
		if (_triggerSource == TriggerSource.Internal)
		{
			_messageService?.PublishMessage(new ClearTypeTriggeredMessage(ClearType.Props));
		}
	}

	public void ClearMessages()
	{
		_manager.ClearMessages(_triggerSource);
		if (_triggerSource == TriggerSource.Internal)
		{
			_messageService?.PublishMessage(new ClearTypeTriggeredMessage(ClearType.Messages));
		}
	}

	public void ClearAudio()
	{
		_manager.ClearAudio(_triggerSource);
		if (_triggerSource == TriggerSource.Internal)
		{
			_messageService?.PublishMessage(new ClearTypeTriggeredMessage(ClearType.Audio));
		}
	}

	public void TriggerClearGroup(ClearGroup clearGroup)
	{
		_manager.TriggerClearGroup(clearGroup, _triggerSource);
		if (_triggerSource == TriggerSource.Internal)
		{
			_messageService?.PublishMessage(new CueTriggeredMessage(clearGroup));
		}
	}

	public void TriggerSlide(ArrangedCue slide, SlideTriggerOptions? options = null)
	{
		if (options?.Cue != null)
		{
			_manager.ActivePlaylistItem = options.Cue;
		}
		_manager.TriggerSlide(slide, _triggerSource, options);
		if (_triggerSource == TriggerSource.Internal)
		{
			_messageService?.PublishMessage(new CueTriggeredMessage(slide));
		}
	}

	public void TriggerBackground<T>(MediaCue media, Playlist<T> playlist, CueLocation cueLocation = CueLocation.MediaBin) where T : ProPresenterCue
	{
		_manager.TriggerBackground(media, playlist, _triggerSource, cueLocation);
		if (_triggerSource == TriggerSource.Internal)
		{
			_messageService?.PublishMessage(new CueTriggeredMessage(media));
		}
	}

	public void TriggerAudio<T>(MediaCue audio, Playlist<T> playlist, CueLocation cueLocation = CueLocation.AudioBin) where T : ProPresenterCue
	{
		_manager.TriggerAudio(audio, playlist, _triggerSource, cueLocation);
		if (_triggerSource == TriggerSource.Internal)
		{
			_messageService?.PublishMessage(new CueTriggeredMessage(audio));
		}
	}

	public void Play(ProLayerIndex layer, bool sendToNetwork = true)
	{
		_manager?.Play(layer, sendToNetwork);
	}

	public void Pause(ProLayerIndex layer, bool sendToNetwork = true)
	{
		_manager?.Pause(layer, sendToNetwork);
	}

	public void SkipToTime(ProLayerIndex proLayerIndex, int seconds)
	{
		_manager?.SkipToTime(proLayerIndex, seconds);
	}

	public bool GetAutoAdvance(ProLayerIndex proLayerIndex)
	{
		return _manager?.GetAutoAdvance(proLayerIndex) ?? false;
	}

	public void CancelAutoAdvance(ProLayerIndex proLayerIndex)
	{
		_manager?.CancelAutoAdvance(proLayerIndex);
	}

	public void TriggerProp(IPropCue prop)
	{
		_manager.TriggerProp(prop, _triggerSource);
		if (_triggerSource == TriggerSource.Internal)
		{
			_messageService?.PublishMessage(new CueTriggeredMessage(prop));
		}
	}

	public void ToggleProp(IPropCue prop, PropTrigger? propTrigger)
	{
		_manager.ToggleProp(prop, _triggerSource);
		if (_triggerSource == TriggerSource.Internal)
		{
			_messageService?.PublishMessage(new CueTriggeredMessage(prop, propTrigger));
		}
	}

	public void ClearProp(IPropCue prop)
	{
		_manager?.ClearProp(prop, _triggerSource);
	}

	public void TriggerTimerAction(Guid id, string name, TimerActionType timerActionType, Timer.Types.Configuration protoConfiguration, bool ignoreAnalytics = false)
	{
		_manager.TriggerTimerAction(id, name, timerActionType, protoConfiguration, TimeSlice.Zero, null, ignoreAnalytics);
	}

	public void TriggerTimerAction(TimerData timer, TimerActionType timerActionType, TimeSlice? incrementAmount = null, bool ignoreAnalytics = false)
	{
		_manager.TriggerTimerAction(timer, timerActionType, _triggerSource, incrementAmount ?? TimeSlice.Zero, ignoreAnalytics);
		if (_triggerSource == TriggerSource.Internal)
		{
			_messageService?.PublishMessage(new CueTriggeredMessage(timer));
		}
	}

	public void TriggerMessage(Guid id, string name, IEnumerable<Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue> tokenValues)
	{
		_manager.TriggerMessage(id, name, tokenValues);
	}

	public void ClearMessage(ProPresenter.DO.Messages.Message message)
	{
		_manager?.ClearMessage(message, _triggerSource);
	}

	public void TriggerMacro(ProPresenterMacro macro)
	{
		_manager.TriggerMacro(macro, _triggerSource);
		if (_triggerSource == TriggerSource.Internal)
		{
			_messageService?.PublishMessage(new CueTriggeredMessage(macro));
		}
	}

	public void TriggerAudienceLook(AudienceLook audienceLook)
	{
		_manager.TriggerAudienceLook(audienceLook, _triggerSource);
		if (_triggerSource == TriggerSource.Internal)
		{
			_messageService?.PublishMessage(new CueTriggeredMessage(audienceLook));
		}
	}

	public void TriggerStageAction(IEnumerable<Stage.Types.ScreenAssignment> assignments, bool ignoreAnalytics = false)
	{
		_manager.TriggerStageAction(assignments, ignoreAnalytics);
	}

	public void SendStageMessage(string message)
	{
		_manager.SendStageMessage(message, _triggerSource);
	}

	public void HideStageMessage()
	{
		_manager.HideStageMessage(_triggerSource);
	}

	public void TriggerMessage(ProPresenter.DO.Messages.Message message)
	{
		_manager.TriggerMessage(message, _triggerSource);
		if (_triggerSource == TriggerSource.Internal)
		{
			_messageService?.PublishMessage(new CueTriggeredMessage(message));
		}
	}

	public void TriggerNextSlide()
	{
		_manager.TriggerNextSlide(_triggerSource);
	}

	public void TriggerNextSlide(OutputDestination destination)
	{
		_manager.TriggerNextSlide(destination, _triggerSource);
	}

	public void TriggerPreviousSlide()
	{
		_manager.TriggerPreviousSlide(_triggerSource);
	}

	public void TriggerPreviousSlide(OutputDestination destination)
	{
		_manager.TriggerPreviousSlide(destination, _triggerSource);
	}

	public void TriggerNextBackground(VisualPlaylist playlist)
	{
		_manager.TriggerNextBackground(playlist, _triggerSource);
	}

	public void TriggerPreviousBackground(VisualPlaylist playlist)
	{
		_manager.TriggerPreviousBackground(playlist, _triggerSource);
	}

	public void TriggerNextAudio(AudioPlaylist playlist)
	{
		_manager.TriggerNextAudio(playlist, _triggerSource);
	}

	public void TriggerPreviousAudio(AudioPlaylist playlist)
	{
		_manager.TriggerPreviousAudio(playlist, _triggerSource);
	}

	public void TriggerHeader(HeaderAction header)
	{
		_manager.TriggerHeaderAction(header);
	}

	public void TriggerCapture(CaptureAction captureAction)
	{
		_manager.TriggerCapture(captureAction);
	}

	public void ShowAudienceScreens()
	{
		_manager.ShowAudienceScreens();
	}

	public void HideAudienceScreens()
	{
		_manager.HideAudienceScreens();
	}

	public void ShowStageScreens()
	{
		_manager.ShowStageScreens();
	}

	public void HideStageScreens()
	{
		_manager.HideStageScreens();
	}
}
