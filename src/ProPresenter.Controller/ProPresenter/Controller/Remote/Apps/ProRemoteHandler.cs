using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using System.Windows.Threading;
using Newtonsoft.Json.Linq;
using Pro.Common.Collections;
using Pro.Common.Nullability;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.Common.Versioning;
using Pro.DO.Storage;
using Pro.Network.Protocol;
using ProPresenter.DO;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Looks;
using ProPresenter.DO.MacroGroups;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Media;
using ProPresenter.DO.Messages;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Timer;

namespace ProPresenter.Controller.Remote.Apps;

internal class ProRemoteHandler
{
	public delegate void BroadcastDelegate(string action, JObject data, Predicate<RemoteClient> predicate);

	private delegate void SendResponseDelegate(JObject data, bool injectAction);

	[CompilerGenerated]
	private sealed class _003CFindParentIndices_003Ed__240 : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private int _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IPlaylist<ProPresenterCue> playlist;

		public IPlaylist<ProPresenterCue> _003C_003E3__playlist;

		public ProRemoteHandler _003C_003E4__this;

		private IPlaylist<ProPresenterCue> _003CparentCollection_003E5__2;

		int IEnumerator<int>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CFindParentIndices_003Ed__240(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CparentCollection_003E5__2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			ProRemoteHandler proRemoteHandler = _003C_003E4__this;
			IPlaylist<ProPresenterCue> playlist;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003CparentCollection_003E5__2 = this.playlist.PlaylistParent;
				playlist = this.playlist;
				goto IL_00a3;
			case 1:
				_003C_003E1__state = -1;
				goto IL_0090;
			case 2:
				{
					_003C_003E1__state = -1;
					return false;
				}
				IL_00a3:
				if (_003CparentCollection_003E5__2 != null)
				{
					int? num2 = _003CparentCollection_003E5__2.Children?.IndexOf<IPlaylist<ProPresenterCue>>(playlist);
					if (num2.HasValue)
					{
						_003C_003E2__current = num2.Value;
						_003C_003E1__state = 1;
						return true;
					}
					goto IL_0090;
				}
				if (proRemoteHandler.PlaylistLibrary == null)
				{
					return false;
				}
				_003C_003E2__current = proRemoteHandler.PlaylistLibrary.IndexOf(playlist);
				_003C_003E1__state = 2;
				return true;
				IL_0090:
				playlist = _003CparentCollection_003E5__2;
				_003CparentCollection_003E5__2 = playlist.PlaylistParent;
				goto IL_00a3;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<int> IEnumerable<int>.GetEnumerator()
		{
			_003CFindParentIndices_003Ed__240 _003CFindParentIndices_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CFindParentIndices_003Ed__ = this;
			}
			else
			{
				_003CFindParentIndices_003Ed__ = new _003CFindParentIndices_003Ed__240(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			_003CFindParentIndices_003Ed__.playlist = _003C_003E3__playlist;
			return _003CFindParentIndices_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<int>)this).GetEnumerator();
		}
	}

	private const int CurrentProtocolVersion = 701;

	private const string OldVersionErrorMessage = "Remote application protocol out of date. Update application";

	private const string AuthErrorMessage = "Password is incorrect or remote control is not enabled";

	private static readonly TimeSlice TimerBroadcastInterval = TimeSlice.FromSeconds(1.0);

	private const string TimerFormat = "${{{0}: H:MM:SS}}";

	private const string TextFormat = "${{{0}}}";

	private const string AuthenticateAction = "authenticate";

	private const string RequestLibraryAction = "libraryRequest";

	private const string RequestPresentationAction = "presentationRequest";

	private const string RequestPresentationSlideIndexAction = "presentationSlideIndex";

	private const string RequestPresentationCurrentAction = "presentationCurrent";

	private const string RequestPresentationCurrentIndexAction = "presentationCurrentIndex";

	private const string PresentationTriggerIndexAction = "presentationTriggerIndex";

	private const string RequestPresentationTriggerPreviousAction = "presentationTriggerPrevious";

	private const string RequestPresentationTriggerNextAction = "presentationTriggerNext";

	private const string RequestTimelineResetAction = "timelineRewind";

	private const string RequestTimelinePlayPauseAction = "timelinePlayPause";

	private const string RequestAllPlaylistsAction = "playlistRequestAll";

	private const string RequestPlaylistAction = "playlistRequest";

	private const string RequestClocksAction = "clockRequest";

	private const string RequestClockStartAction = "clockStart";

	private const string RequestClockStopAction = "clockStop";

	private const string RequestClockResetAction = "clockReset";

	private const string RequestClockStartAllAction = "clockStartAll";

	private const string RequestClockStopAllAction = "clockStopAll";

	private const string RequestClockResetAllAction = "clockResetAll";

	private const string RequestClockStartSendingCurrentTimeAction = "clockStartSendingCurrentTime";

	private const string RequestClockStopSendingCurrentTimeAction = "clockStopSendingCurrentTime";

	private const string RequestClockCurrentTimesAction = "clockCurrentTimes";

	private const string RequestClockStartStopAction = "clockStartStop";

	private const string RequestClockResetIndexAction = "clockResetIndex";

	private const string RequestClockDeleteAddAction = "clockDeleteAdd";

	private const string RequestClockDurationChangedAction = "clockDurationChanged";

	private const string RequestClockNameChangedAction = "clockNameChanged";

	private const string RequestClockTypeChangedAction = "clockTypeChanged";

	private const string RequestClockFormatChangedAction = "clockIsPMChanged";

	private const string RequestClockEndTimeChangedAction = "clockEndTimeChanged";

	private const string RequestClockOverrunChangedAction = "clockOverrunChanged";

	private const string RequestClockUpdateAction = "clockUpdate";

	private const string RequestClearAllAction = "clearAll";

	private const string RequestClearTextAction = "clearText";

	private const string RequestClearVideoAction = "clearVideo";

	private const string RequestClearAudioAction = "clearAudio";

	private const string RequestClearPropsAction = "clearProps";

	private const string RequestClearToLogoAction = "clearToLogo";

	private const string RequestClearTelestratorAction = "clearTelestrator";

	private const string RequestClearMessagesAction = "clearMessages";

	private const string RequestClearAnnouncementAction = "clearAnnouncements";

	private const string RequestMessageAction = "messageRequest";

	private const string RequestMessageSendAction = "messageSend";

	private const string RequestMessageHideAction = "messageHide";

	private const string RequestAudioAction = "audioRequest";

	private const string RequestAudioPlaylistAction = "audioPlaylist";

	private const string RequestAudioCurrentSongAction = "audioCurrentSong";

	private const string RequestAudioStartCueAction = "audioStartCue";

	private const string RequestAudioPlayPauseAction = "audioPlayPause";

	private const string RequestAudioIsPlayingAction = "audioIsPlaying";

	private const string RequestAudioTriggeredAction = "audioTriggered";

	private const string RequestStageDisplaySetsAction = "stageDisplaySets";

	private const string RequestStageDisplayChangeLayoutAction = "stageDisplayChangeLayout";

	private const string RequestStageDisplaySendMessageAction = "stageDisplaySendMessage";

	private const string RequestStageDisplayHideMessageAction = "stageDisplayHideMessage";

	private const string RequestAudienceLooksAction = "looksRequest";

	private const string RequestAudienceLookTrigger = "looksTrigger";

	private const string RequestMacrosAction = "macrosRequest";

	private const string RequestMacrosTrigger = "macrosTrigger";

	private ProRemoteInteractor? _interactor;

	private readonly Dispatcher _dispatcher;

	private readonly BroadcastDelegate _broadcast;

	private readonly IPlaylistEncoder _playlistEncoder;

	private readonly IPresentationEncoder _presentationEncoder;

	private readonly DispatcherTimer _updateCurrentTimer;

	private readonly List<RemoteClient> _subscribedTimerClients = new List<RemoteClient>();

	private TimerCollection? _timers;

	private MessageCollection? _messages;

	private StageScreenLayoutMap? _stageScreenLayoutMap;

	private IMacroSource? _macroSource;

	private IAudienceLookCollection? _looks;

	private LiveAudienceLook? _liveLook;

	public bool CanControl { get; set; } = true;

	public bool CanObserve { get; set; } = true;

	public string ControlPassword { get; set; } = "c";

	public string ObserverPassword { get; set; } = "o";

	public LibraryCollection? Libraries { get; set; }

	public LibraryPlaylistCollection? PlaylistLibrary { get; set; }

	public AudioPlaylistCollection? AudioPlaylistLibrary { get; set; }

	public IAudienceLookCollection? AudienceLooks
	{
		get
		{
			return _looks;
		}
		set
		{
			if (_looks != null)
			{
				_looks.CollectionChanged -= AudienceLooks_CollectionChanged;
			}
			_looks = value;
			if (_looks != null)
			{
				_looks.CollectionChanged += AudienceLooks_CollectionChanged;
			}
		}
	}

	public IMacroSource? MacroSource
	{
		get
		{
			return _macroSource;
		}
		set
		{
			if (_macroSource != null)
			{
				_macroSource.MacroCollectionsChanged -= MacroSource_CollectionChanged;
			}
			_macroSource = value;
			if (_macroSource != null)
			{
				_macroSource.MacroCollectionsChanged += MacroSource_CollectionChanged;
			}
		}
	}

	public bool IsAudioPlaying { get; set; }

	public TimerCollection? Timers
	{
		get
		{
			return _timers;
		}
		set
		{
			if (_timers != null)
			{
				_timers.CollectionChanged -= Timers_CollectionChanged;
			}
			_timers = value;
			if (_timers != null)
			{
				_timers.ForEach(HookupTimerDataEvents);
				_timers.CollectionChanged += Timers_CollectionChanged;
			}
		}
	}

	public MessageCollection? Messages
	{
		get
		{
			return _messages;
		}
		set
		{
			if (_messages != null)
			{
				_messages.CollectionChanged -= Messages_CollectionChanged;
			}
			_messages = value;
			if (_messages != null)
			{
				_messages.ForEach(HookupMessagePropertyChange);
				_messages.CollectionChanged += Messages_CollectionChanged;
			}
		}
	}

	public ArrangedCue? ActiveSlide { get; set; }

	public ProPresenterCue? ActivePlaylistItem { get; set; }

	public AudioMedia? ActiveAudio { get; set; }

	public Playlist<ProPresenterCue>? ActivePlaylist { get; set; }

	public Playlist<MediaCue>? ActiveAudioPlaylist { get; set; }

	public StageScreenArrangementCollection? StageScreens { get; set; }

	public StagePresentation? StageLayouts { get; set; }

	public StageScreenLayoutMap? StageScreenLayoutMap
	{
		get
		{
			return _stageScreenLayoutMap;
		}
		set
		{
			if (_stageScreenLayoutMap != null)
			{
				_stageScreenLayoutMap.DataModified -= NotifyStageScreenLayoutsChanged;
			}
			_stageScreenLayoutMap = value;
			if (_stageScreenLayoutMap != null)
			{
				_stageScreenLayoutMap.DataModified += NotifyStageScreenLayoutsChanged;
			}
		}
	}

	public event Action<OutputDestination>? TriggerPreviousSlide;

	public event Action<OutputDestination>? TriggerNextSlide;

	public event Action<IDocumentCue?, ILibrary?, IPlaylist<ProPresenterCue>?>? ResetTimeline;

	public event Action<IDocumentCue?, ILibrary?, IPlaylist<ProPresenterCue>?>? PlayPauseTimeline;

	public event Action<MediaCue, Playlist<MediaCue>>? TriggerAudio;

	public event Action<AudioPlaylist?>? ChangeActiveAudioPlaylist;

	public event Action? PlayAudio;

	public event Action? PauseAudio;

	public event Action<TimerData>? StartTimer;

	public event Action<TimerData>? StopTimer;

	public event Action<TimerData>? ResetTimer;

	public event Action? ClearAll;

	public event Action? ClearSlide;

	public event Action? ClearVideo;

	public event Action? ClearAudio;

	public event Action? ClearProps;

	public event Action? ClearToLogo;

	public event Action? ClearTelestrator;

	public event Action? ClearMessages;

	public event Action? ClearAnnouncement;

	public event Action<Message>? ShowMessage;

	public event Action<Message>? HideMessage;

	public event Action<string>? ChangeStageMessage;

	public event Action? HideStageMessage;

	public event Action<AudienceLook>? TriggerLook;

	public event Action<ProPresenterMacro>? TriggerMacro;

	[GeneratedRegex("^(?:[0-9]+\\.)*[0-9]+\\:[0-9]+$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex PlaylistPathPattern()
	{
		return _003CRegexGenerator_g_003EFDBB621A7266593264A3784C53E4820C187E0E9870C29266C7FF9E377C635B5DD__PlaylistPathPattern_3.Instance;
	}

	public ProRemoteHandler(ActionRegistrar registrar, BroadcastDelegate broadcast, Dispatcher dispatcher, IPlaylistEncoder? playlistEncoder = null, IPresentationEncoder? presentationEncoder = null)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		_dispatcher = dispatcher;
		_broadcast = broadcast;
		_updateCurrentTimer = new DispatcherTimer((TimeSpan)TimerBroadcastInterval, (DispatcherPriority)9, (EventHandler)UpdateCurrentTimers_Tick, dispatcher);
		_playlistEncoder = playlistEncoder ?? new PlaylistEncoder();
		_presentationEncoder = presentationEncoder ?? new PresentationEncoder();
		SetupActions(registrar);
		_updateCurrentTimer.Start();
	}

	public void SetInteractor(ProRemoteInteractor interactor)
	{
		_interactor = interactor;
	}

	private void SetupActions(ActionRegistrar registrar)
	{
		Action<string, Action<JObject, RemoteClient, SendResponseDelegate>> action2 = delegate(string action, Action<JObject, RemoteClient, SendResponseDelegate> handler)
		{
			registrar.Register(action, delegate(JObject d, RemoteClient c)
			{
				ActionWebSocketBase<RemoteClient, string, JObject>.ActionResponse response = null;
				if (c.IsAuthenticated)
				{
					Dispatcher dispatcher = _dispatcher;
					if (dispatcher != null)
					{
						dispatcher.Invoke((Action)delegate
						{
							handler(d, c, sendResponse);
						});
					}
				}
				return response;
				void sendResponse(JObject rd, bool i)
				{
					if (response != null)
					{
						throw new InvalidOperationException();
					}
					response = new ActionWebSocketBase<RemoteClient, string, JObject>.ActionResponse(i, rd);
				}
			});
		};
		Action<string, Action<JObject, RemoteClient, SendResponseDelegate>> action3 = delegate(string action, Action<JObject, RemoteClient, SendResponseDelegate> handler)
		{
			registrar.Register(action, delegate(JObject d, RemoteClient c)
			{
				ActionWebSocketBase<RemoteClient, string, JObject>.ActionResponse response2 = null;
				if (c.IsAuthenticated && c.CanControl)
				{
					Dispatcher dispatcher2 = _dispatcher;
					if (dispatcher2 != null)
					{
						dispatcher2.Invoke((Action)delegate
						{
							handler(d, c, sendResponse);
						});
					}
				}
				return response2;
				void sendResponse(JObject rd, bool i)
				{
					if (response2 != null)
					{
						throw new InvalidOperationException();
					}
					response2 = new ActionWebSocketBase<RemoteClient, string, JObject>.ActionResponse(i, rd);
				}
			});
		};
		registrar.Register("authenticate", AuthenticateHandler);
		action2("libraryRequest", RequestLibraryHandler);
		action2("presentationRequest", RequestPresentationHandler);
		action2("presentationSlideIndex", RequestPresentationSlideIndexHandler);
		action2("presentationCurrent", RequestPresentationCurrentHandler);
		action2("presentationCurrentIndex", RequestPresentationCurrentIndexHandler);
		action3("presentationTriggerIndex", RequestPresentationTriggerIndexHandler);
		action3("presentationTriggerPrevious", RequestPresentationTriggerPreviousHandler);
		action3("presentationTriggerNext", RequestPresentationTriggerNextHandler);
		action3("timelineRewind", RequestTimelineResetHandler);
		action3("timelinePlayPause", RequestTimelinePlayPauseHandler);
		action2("playlistRequest", RequestAllPlaylistsHandler);
		action2("playlistRequestAll", RequestAllPlaylistsHandler);
		action2("clockRequest", RequestClocksHandler);
		action2("clockStartSendingCurrentTime", RequestClockStartSendingCurrentTimeHandler);
		action2("clockStopSendingCurrentTime", RequestClockStopSendingCurrentTimeHandler);
		action3("clockStart", RequestClockStartHandler);
		action3("clockStop", RequestClockStopHandler);
		action3("clockReset", RequestClockResetHandler);
		action3("clockStartAll", RequestClockStartAllHandler);
		action3("clockStopAll", RequestClockStopAllHandler);
		action3("clockResetAll", RequestClockResetAllHandler);
		action3("clockUpdate", RequestClockUpdateHandler);
		action3("clearAll", RequestClearAllActionHandler);
		action3("clearText", RequestClearTextActionHandler);
		action3("clearVideo", RequestClearVideoActionHandler);
		action3("clearAudio", RequestClearAudioActionHandler);
		action3("clearProps", RequestClearPropsActionHandler);
		action3("clearToLogo", RequestClearToLogoActionHandler);
		action3("clearTelestrator", RequestClearTelestratorActionHandler);
		action3("clearMessages", RequestClearMessageActionHandler);
		action3("clearAnnouncements", RequestClearAnnouncementActionHandler);
		action3("messageRequest", RequestMessageActionHandler);
		action3("messageSend", RequestMessageSendHandler);
		action3("messageHide", RequestMessageHideHandler);
		action2("audioRequest", RequestAudioHandler);
		action2("audioPlaylist", RequestAudioHandler);
		action2("audioCurrentSong", RequestAudioCurrentSongHandler);
		action2("audioIsPlaying", RequestAudioIsPlayingHandler);
		action3("audioStartCue", RequestAudioStartCueHandler);
		action3("audioPlayPause", RequestAudioPlayPauseHandler);
		action2("stageDisplaySets", RequestStageDisplaySetsHandler);
		action3("stageDisplayChangeLayout", RequestStageDisplayChangeLayoutHandler);
		action3("stageDisplaySendMessage", RequestStageDisplaySendMessageHandler);
		action3("stageDisplayHideMessage", RequestStageDisplayHideMessageHandler);
		action3("looksRequest", RequestAudienceLooksHandler);
		action3("looksTrigger", RequestAudienceLookTriggerHandler);
		action3("macrosRequest", RequestMacrosHandler);
		action3("macrosTrigger", RequestMacrosTriggerHandler);
	}

	private void Broadcast(string action, JObject? data = null)
	{
		_broadcast(action, data ?? new JObject(), (RemoteClient c) => c.IsAuthenticated);
	}

	private string GeneratePlaylistPath(IPlaylist<ProPresenterCue> playlist)
	{
		if (playlist.PlaylistParent != null)
		{
			return string.Join(".", FindParentIndices(playlist).Reverse());
		}
		return PlaylistLibrary?.IndexOf(playlist).ToString() ?? string.Empty;
	}

	[IteratorStateMachine(typeof(_003CFindParentIndices_003Ed__240))]
	private IEnumerable<int> FindParentIndices(IPlaylist<ProPresenterCue> playlist)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CFindParentIndices_003Ed__240(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__playlist = playlist
		};
	}

	private static bool TryFindPlaylist<T>(string path, IPlaylist<T>[] playlists, [NotNullWhen(true)] out IPlaylist<T>? playlist, [NotNullWhen(true)] out T? item) where T : ProPresenterCue
	{
		playlist = null;
		item = null;
		string[] array = path.Split(':');
		if (array.Length != 2)
		{
			return false;
		}
		string[] array2 = array[0].Split('.');
		if (!int.TryParse(array[1], out var result))
		{
			return false;
		}
		string[] array3 = array2;
		foreach (string s in array3)
		{
			int result2 = -1;
			if (!int.TryParse(s, out result2))
			{
				return false;
			}
			if (result2 < 0 || result2 >= playlists.Length)
			{
				return false;
			}
			playlist = playlists[result2];
			if (playlist is GroupPlaylist<T> groupPlaylist)
			{
				playlists = groupPlaylist.Children.ToArray();
			}
		}
		Playlist<T> obj = playlist as Playlist<T>;
		item = ((obj != null) ? obj.Where((T i) => !i.IsHidden).ElementAtOrDefault(result) : null);
		return item != null;
	}

	private void Timers_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.Cast<TimerData>().ForEach(UnhookTimerDataEvents);
		e.NewItems?.Cast<TimerData>().ForEach(HookupTimerDataEvents);
		NotifyTimersCollectionChanged();
	}

	private void UnhookTimerDataEvents(TimerData timerData)
	{
		UnhookTimerSourceEvents(timerData.Source);
		UnHookupTimerActiveEvents(timerData.Active);
		timerData.SourceChanged -= Timer_SourceChanged;
		timerData.ActiveChanged -= Timer_ActiveChanged;
	}

	private void HookupTimerDataEvents(TimerData timerData)
	{
		HookupTimerSourceEvents(timerData.Source);
		HookupTimerActiveEvents(timerData.Active);
		timerData.SourceChanged += Timer_SourceChanged;
		timerData.ActiveChanged += Timer_ActiveChanged;
	}

	private void UnhookTimerSourceEvents(TimerBase? timerSource)
	{
		if (timerSource != null)
		{
			timerSource.PropertyChanged -= TimerSource_PropertyChanged;
		}
	}

	private void HookupTimerSourceEvents(TimerBase? timerSource)
	{
		if (timerSource != null)
		{
			timerSource.PropertyChanged += TimerSource_PropertyChanged;
		}
	}

	private void UnHookupTimerActiveEvents(TimerBase? timerActive)
	{
		if (timerActive != null)
		{
			timerActive.WasReset -= NotifyClockReset;
			timerActive.PropertyChanged -= TimerActive_PropertyChanged;
		}
	}

	private void HookupTimerActiveEvents(TimerBase? timerActive)
	{
		if (timerActive != null)
		{
			timerActive.WasReset += NotifyClockReset;
			timerActive.PropertyChanged += TimerActive_PropertyChanged;
		}
	}

	private void TimerSource_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "Name":
			NotifyClockNameChanged(sender as TimerData);
			break;
		case "StartTime":
			NotifyClockDurationChanged(sender as TimerBase);
			break;
		case "TimeFormat":
			NotifyTimeFormatChanged(sender as CountdownToTime);
			break;
		case "EndTime":
			if (sender is TimerBase { TimerType: TimerType.CountdownToTime } timerBase)
			{
				NotifyClockDurationChanged(timerBase);
			}
			else
			{
				NotifyEndTimeChanged(sender as TimerBase);
			}
			break;
		case "IsOverRunAllowed":
			NotifyClockOverrrunChanged(sender as TimerBase);
			break;
		case "IsTimerRunning":
			NotifyClockTimerStartStop(sender as TimerBase);
			break;
		}
	}

	private void TimerActive_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "IsTimerRunning")
		{
			NotifyClockTimerStartStop(sender as TimerBase);
		}
	}

	private void Timer_SourceChanged(TimerBase oldSource, TimerBase newSource)
	{
		if (oldSource != null)
		{
			UnhookTimerSourceEvents(oldSource);
		}
		if (newSource != null)
		{
			HookupTimerSourceEvents(newSource);
			NotifyClockTypeChanged(newSource);
		}
	}

	private void Timer_ActiveChanged(TimerBase oldActive, TimerBase newActive)
	{
		if (oldActive != null)
		{
			oldActive.WasReset -= NotifyClockReset;
			newActive.PropertyChanged -= TimerActive_PropertyChanged;
		}
		if (newActive != null)
		{
			newActive.WasReset += NotifyClockReset;
			newActive.PropertyChanged += TimerActive_PropertyChanged;
		}
	}

	private void Messages_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.Cast<Message>().ForEach(UnhookMessagePropertyChange);
		e.NewItems?.Cast<Message>().ForEach(HookupMessagePropertyChange);
		NotifyMessagesUpdated();
	}

	private void HookupMessagePropertyChange(Message message)
	{
		message.PropertyChanged += Message_PropertyChanged;
		message.Tokens.CollectionChanged += Tokens_CollectionChanged;
	}

	private void UnhookMessagePropertyChange(Message message)
	{
		message.PropertyChanged -= Message_PropertyChanged;
		message.Tokens.CollectionChanged -= Tokens_CollectionChanged;
	}

	private void Tokens_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		NotifyMessagesUpdated();
	}

	private void Message_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		NotifyMessagesUpdated();
	}

	private JObject EncodeMessages()
	{
		return JObject.FromObject(new
		{
			messages = Messages?.Select((Message m) => new
			{
				messageTitle = m.Name,
				messageComponents = m.EncodeToComponents("${{{0}}}", "${{{0}: H:MM:SS}}")
			})
		});
	}

	private ActionWebSocketBase<RemoteClient, string, JObject>.ActionResponse AuthenticateHandler(JObject data, RemoteClient client)
	{
		string error = string.Empty;
		if (((dynamic)data).protocol >= 701)
		{
			if (CanControl && !string.IsNullOrEmpty(ControlPassword) && ((dynamic)data).password == ControlPassword)
			{
				client.CanControl = true;
				client.IsAuthenticated = true;
			}
			else if (CanObserve && ((dynamic)data).password == ObserverPassword)
			{
				client.IsAuthenticated = true;
			}
			else
			{
				error = "Password is incorrect or remote control is not enabled";
			}
		}
		else
		{
			error = "Remote application protocol out of date. Update application";
		}
		return new ActionWebSocketBase<RemoteClient, string, JObject>.ActionResponse(injectAction: true, JObject.FromObject(new
		{
			controller = (client.CanControl ? 1 : 0),
			authenticated = (client.IsAuthenticated ? 1 : 0),
			error = error,
			majorVersion = 7,
			minorVersion = VersionInfo.AppVersion.Major,
			patchVersion = VersionInfo.AppVersion.Minor,
			protocol = 701
		}));
	}

	private void RequestLibraryHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		if (Libraries != null)
		{
			sendResponse(JObject.FromObject(new
			{
				library = Libraries.SelectMany((ILibrary l) => l).Select(DocumentCueToPath)
			}), injectAction: true);
		}
	}

	private void RequestPresentationHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		string text = ((dynamic)data).presentationPath;
		int slideQuality = ((dynamic)data).presentationSlideQuality ?? ((object)25);
		if (PlaylistPathPattern().IsMatch(text))
		{
			HandlePlaylistItemDocument(text, slideQuality, sendResponse);
		}
		else
		{
			HandlePresentationDocument(text, slideQuality, sendResponse);
		}
	}

	private void HandlePlaylistItemDocument(string path, int slideQuality, SendResponseDelegate sendResponse)
	{
		if (PlaylistLibrary != null && TryFindPlaylist(path, PlaylistLibrary.ToArray(), out IPlaylist<ProPresenterCue> _, out ProPresenterCue item) && item is IDocumentCue documentCue)
		{
			sendResponse(JObject.FromObject(_presentationEncoder.Encode(documentCue, path, "presentationCurrent", slideQuality)), injectAction: false);
		}
	}

	private void HandlePresentationDocument(string presentationPath, int slideQuality, SendResponseDelegate sendResponse)
	{
		DocumentCue documentCue = Libraries?.FindDocument(new RelativePath(presentationPath));
		if (documentCue != null)
		{
			sendResponse(JObject.FromObject(_presentationEncoder.Encode(documentCue, "presentationCurrent", slideQuality)), injectAction: false);
		}
	}

	private void RequestPresentationCurrentHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		if (ActivePlaylistItem is IDocumentCue documentCue)
		{
			sendResponse(JObject.FromObject(_presentationEncoder.Encode(documentCue, string.Empty, 400)), injectAction: true);
		}
	}

	private void RequestPresentationCurrentIndexHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		IDocumentCue documentCue = ActivePlaylistItem as IDocumentCue;
		int? presentationIndex = ((documentCue == null) ? new int?(-1) : Libraries?.IndexOf(documentCue));
		string presentationPath = DocumentCueToPath(documentCue);
		int presentationDestination = (int)((!(documentCue?.DocumentAction?.Destination).HasValue) ? ((OutputDestination)(-1)) : documentCue.DocumentAction.Destination);
		sendResponse(JObject.FromObject(new { presentationIndex, presentationPath, presentationDestination }), injectAction: true);
	}

	private void RequestPresentationSlideIndexHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		IDocumentCue documentCue = ActivePlaylistItem as IDocumentCue;
		int slideIndex = ((ActiveSlide != null) ? (documentCue?.DocumentAction?.ActiveArrangement?.ArrangedCues.IndexOf(ActiveSlide) ?? (-1)) : (-1));
		string presentationPath = DocumentCueToPath(documentCue);
		int presentationDestination = (int)((!(documentCue?.DocumentAction?.Destination).HasValue) ? ((OutputDestination)(-1)) : documentCue.DocumentAction.Destination);
		sendResponse(JObject.FromObject(new { slideIndex, presentationPath, presentationDestination }), injectAction: true);
	}

	private void RequestPresentationTriggerIndexHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		TriggerPresentationSlideRequest triggerPresentationSlideRequest = data.ToObject<TriggerPresentationSlideRequest>();
		triggerPresentationSlideRequest.ThrowWhenNull("deserialized");
		_interactor?.HandleSlideTrigger(triggerPresentationSlideRequest);
	}

	private void RequestPresentationTriggerNextHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		this.TriggerNextSlide?.Invoke((OutputDestination)((dynamic)data).presentationDestination);
	}

	private void RequestPresentationTriggerPreviousHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		this.TriggerPreviousSlide?.Invoke((OutputDestination)((dynamic)data).presentationDestination);
	}

	private void RequestTimelineResetHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		this.ResetTimeline?.Invoke(GetDocumentCue(data, out ILibrary targetLibrary, out IPlaylist<ProPresenterCue> targetPlaylist), targetLibrary, targetPlaylist);
	}

	private void RequestTimelinePlayPauseHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		this.PlayPauseTimeline?.Invoke(GetDocumentCue(data, out ILibrary targetLibrary, out IPlaylist<ProPresenterCue> targetPlaylist), targetLibrary, targetPlaylist);
	}

	private IDocumentCue? GetDocumentCue(JObject data, out ILibrary? targetLibrary, out IPlaylist<ProPresenterCue>? targetPlaylist)
	{
		targetLibrary = null;
		targetPlaylist = null;
		string text = ((dynamic)data).presentationPath;
		ProPresenterCue item;
		if (PlaylistPathPattern().IsMatch(text))
		{
			if (PlaylistLibrary == null || !TryFindPlaylist(text, PlaylistLibrary.ToArray(), out targetPlaylist, out item))
			{
				item = null;
			}
		}
		else
		{
			item = Libraries?.FindDocument(new RelativePath(text), out targetLibrary);
		}
		if (!(item is IDocumentCue result))
		{
			return null;
		}
		return result;
	}

	private void RequestAllPlaylistsHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		if (PlaylistLibrary != null)
		{
			sendResponse(JObject.FromObject(_playlistEncoder.Encode(PlaylistLibrary)), injectAction: true);
		}
	}

	private void RequestClocksHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		if (Timers != null)
		{
			sendResponse(JObject.FromObject(new
			{
				clockInfo = Timers.Select((TimerData t) => new
				{
					clockType = (int)(t.Source?.TimerType ?? TimerType.Countdown),
					clockState = (t.Active?.IsTimerRunning ?? false),
					clockName = (t.Name ?? string.Empty),
					clockTimePeriodFormat = (int)((t.Source as CountdownToTime)?.TimeFormat ?? TimeFormat.AM),
					clockFormat = BuildClockFormat(t.Source),
					clockDuration = (TimeToString(t.Source?.StartTime) ?? string.Empty),
					clockOverrun = (t.Source?.IsOverRunAllowed ?? false),
					clockEndTime = TimeToString(t.Source?.EndTime),
					clockTime = ((t.Active != null) ? TimeToString(t.Active.RunningTime) : string.Empty)
				})
			}), injectAction: true);
		}
	}

	private void RequestClockStartHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		if (Timers != null)
		{
			int num = ((dynamic)data).clockIndex;
			if (num < Timers.Count && num >= 0)
			{
				this.StartTimer?.Invoke(Timers[num]);
			}
		}
	}

	private void RequestClockStopHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		if (Timers != null)
		{
			int num = ((dynamic)data).clockIndex;
			if (num < Timers.Count && num >= 0)
			{
				this.StopTimer?.Invoke(Timers[num]);
			}
		}
	}

	private void RequestClockResetHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		if (Timers != null)
		{
			int num = ((dynamic)data).clockIndex;
			if (num < Timers.Count && num >= 0)
			{
				this.ResetTimer?.Invoke(Timers[num]);
			}
		}
	}

	private void RequestClockStartAllHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		Timers?.ForEach(delegate(TimerData t)
		{
			this.StartTimer?.Invoke(t);
		});
	}

	private void RequestClockStopAllHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		Timers?.ForEach(delegate(TimerData t)
		{
			this.StopTimer?.Invoke(t);
		});
	}

	private void RequestClockResetAllHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		Timers?.ForEach(delegate(TimerData t)
		{
			this.ResetTimer?.Invoke(t);
		});
	}

	private void RequestClockUpdateHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		if (Timers == null)
		{
			return;
		}
		TimeSlice? timeSlice = null;
		string value = (string)((dynamic)data).clockTime;
		if (!string.IsNullOrEmpty(value))
		{
			timeSlice = TimeSliceHelper.StringToTimeSlice(value);
		}
		int timeFormat = ((dynamic)data).clockTimePeriodFormat;
		bool isOverRunAllowed = ((dynamic)data).clockOverrun ?? ((object)false);
		string name = ((dynamic)data).clockName;
		int num = ((dynamic)data).clockIndex;
		int num2 = ((dynamic)data).clockType;
		TimeSlice? timeSlice2 = null;
		string value2 = (string)((dynamic)data).clockElapsedTime;
		if (!string.IsNullOrEmpty(value2))
		{
			timeSlice2 = TimeSliceHelper.StringToTimeSlice(value2);
		}
		if (num >= Timers.Count || num < 0)
		{
			return;
		}
		TimerData timerData = Timers[num];
		TimerType timerType = (TimerType)num2;
		if (timerType != timerData.Source?.TimerType)
		{
			Timers.ChangeTimerType(timerData, timerType);
		}
		switch (timerType)
		{
		case TimerType.Countdown:
			if (timeSlice.HasValue && timerData.Source != null)
			{
				timerData.Source.StartTime = timeSlice.Value;
			}
			break;
		case TimerType.CountdownToTime:
			if (timerData.Source != null)
			{
				((CountdownToTime)timerData.Source).TimeFormat = (TimeFormat)timeFormat;
				if (timeSlice2.HasValue)
				{
					timerData.Source.EndTime = timeSlice2.Value;
				}
			}
			break;
		case TimerType.ElapsedTime:
			if (timeSlice.HasValue && timerData.Source != null)
			{
				timerData.Source.StartTime = timeSlice.Value;
			}
			if (timeSlice2.HasValue && timerData.Source != null)
			{
				timerData.Source.EndTime = timeSlice2.Value;
			}
			break;
		}
		if (timerData.Source != null)
		{
			timerData.Name = name;
			timerData.Source.IsOverRunAllowed = isOverRunAllowed;
			if (timeSlice.HasValue)
			{
				this.ResetTimer?.Invoke(timerData);
			}
		}
	}

	private void RequestClockStartSendingCurrentTimeHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		lock (_subscribedTimerClients)
		{
			if (!_subscribedTimerClients.Contains(client))
			{
				_subscribedTimerClients.Add(client);
			}
		}
	}

	private void RequestClockStopSendingCurrentTimeHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		lock (_subscribedTimerClients)
		{
			_subscribedTimerClients.Remove(client);
		}
	}

	private void RequestClearAllActionHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		this.ClearAll?.Invoke();
	}

	private void RequestClearTextActionHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		this.ClearSlide?.Invoke();
	}

	private void RequestClearVideoActionHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		this.ClearVideo?.Invoke();
	}

	private void RequestClearAudioActionHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		this.ClearAudio?.Invoke();
	}

	private void RequestClearPropsActionHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		this.ClearProps?.Invoke();
	}

	private void RequestClearToLogoActionHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		this.ClearToLogo?.Invoke();
	}

	private void RequestClearTelestratorActionHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		this.ClearTelestrator?.Invoke();
	}

	private void RequestClearMessageActionHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		this.ClearMessages?.Invoke();
	}

	private void RequestClearAnnouncementActionHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		this.ClearAnnouncement?.Invoke();
	}

	private void RequestMessageActionHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		MessageCollection? messages = Messages;
		if (messages != null && messages.Any())
		{
			sendResponse(EncodeMessages(), injectAction: true);
		}
	}

	private void RequestMessageSendHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		if (Messages == null)
		{
			return;
		}
		int num = ((dynamic)data).messageIndex;
		if (num < 0 || num >= Messages.Count)
		{
			return;
		}
		Message message = Messages[num];
		string[] array = ((JArray)((dynamic)data).messageKeys).Select((JToken t) => t.Value<string>()).ToArray();
		string[] array2 = ((JArray)((dynamic)data).messageValues).Select((JToken t) => t.Value<string>()).ToArray();
		if (array.Length != array2.Length)
		{
			return;
		}
		for (int i = 0; i < array.Length; i++)
		{
			string key = array[i];
			string text = array2[i];
			MessageTokenBase messageTokenBase = message.Tokens.FirstOrDefault((MessageTokenBase t) => t.Content == key);
			if (messageTokenBase != null && messageTokenBase is TextToken textToken)
			{
				text.ThrowWhenNull("value");
				textToken.Text = text;
			}
		}
		this.ShowMessage?.Invoke(message);
	}

	private void RequestMessageHideHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		if (Messages != null)
		{
			int num = ((dynamic)data).messageIndex;
			if (num >= 0 && num < Messages.Count)
			{
				this.HideMessage?.Invoke(Messages[num]);
			}
		}
	}

	private void RequestAudioHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		if (AudioPlaylistLibrary != null)
		{
			sendResponse(JObject.FromObject(new
			{
				audioPlaylist = _playlistEncoder.Encode(AudioPlaylistLibrary).Playlists
			}), injectAction: true);
		}
	}

	private void RequestAudioCurrentSongHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		if (ActiveAudio != null)
		{
			sendResponse(JObject.FromObject(new
			{
				audioName = ActiveAudio.SourceFile.Filename,
				audioArtist = ActiveAudio.Metadata?.Artist
			}), injectAction: true);
		}
	}

	private void RequestAudioStartCueHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		if (AudioPlaylistLibrary != null)
		{
			string path = ((dynamic)data).audioChildPath;
			IPlaylist<MediaCue>[] playlists = AudioPlaylistLibrary.ToArray();
			if (TryFindPlaylist(path, playlists, out IPlaylist<MediaCue> playlist, out MediaCue item) && playlist is AudioPlaylist audioPlaylist)
			{
				this.ChangeActiveAudioPlaylist?.Invoke(audioPlaylist);
				this.TriggerAudio?.Invoke(item, audioPlaylist);
			}
		}
	}

	private void RequestAudioPlayPauseHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		if (IsAudioPlaying)
		{
			this.PauseAudio?.Invoke();
		}
		else
		{
			this.PlayAudio?.Invoke();
		}
	}

	private void RequestAudioIsPlayingHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		sendResponse(JObject.FromObject(new
		{
			audioIsPlaying = IsAudioPlaying
		}), injectAction: true);
	}

	private void RequestStageDisplaySetsHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		if (StageScreens != null && StageScreenLayoutMap != null && StageLayouts != null)
		{
			sendResponse(JObject.FromObject(new
			{
				stageScreens = from s in StageScreens
					where StageScreenLayoutMap.ContainsKey(s)
					select new
					{
						stageScreenName = s.Name,
						stageScreenUUID = s.ID,
						stageLayoutSelectedLayoutUUID = StageScreenLayoutMap[s]?.ID
					},
				stageLayouts = StageLayouts.DefaultArrangement.ArrangedCues.Select((ArrangedCue l) => new
				{
					stageLayoutName = l.Source.Name,
					stageLayoutUUID = l.Source.ID
				})
			}), injectAction: true);
		}
	}

	private void RequestStageDisplayChangeLayoutHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		if (StageScreens != null && StageScreenLayoutMap != null && StageLayouts != null)
		{
			Guid screenID = Guid.Parse((string)((dynamic)data).stageScreenUUID);
			Guid layoutID = Guid.Parse((string)((dynamic)data).stageLayoutUUID);
			ScreenArrangementBase screenArrangementBase = StageScreens.FirstOrDefault((ScreenArrangementBase s) => s.ID == screenID);
			SlideCue slideCue = StageLayouts.DefaultArrangement.ArrangedCues.FirstOrDefault((ArrangedCue l) => l.Source.ID == layoutID)?.Source;
			if (screenArrangementBase != null && slideCue != null)
			{
				StageScreenLayoutMap.AssignScreen(screenArrangementBase, slideCue);
			}
		}
	}

	private void RequestStageDisplaySendMessageHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		this.ChangeStageMessage?.Invoke((string)((dynamic)data).stageDisplayMessage);
	}

	private void RequestStageDisplayHideMessageHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		this.HideStageMessage?.Invoke();
	}

	public void UpdateLiveLook(LiveAudienceLook look)
	{
		_liveLook = look;
	}

	private void RequestAudienceLooksHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		if (AudienceLooks != null)
		{
			sendResponse(JObject.FromObject(new
			{
				looks = AudienceLooks.Select((AudienceLook look) => new
				{
					lookName = look.Name,
					lookID = look.ID.ToString(),
					lookIndex = AudienceLooks.IndexOf(look)
				}),
				activeLook = new
				{
					lookName = (_liveLook?.Live.Name ?? ""),
					lookID = _liveLook?.OriginalID.ToString()
				}
			}), injectAction: true);
		}
	}

	private void RequestAudienceLookTriggerHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		if (Guid.TryParse((string)((dynamic)data).lookID, out var lookID))
		{
			AudienceLook audienceLook = AudienceLooks?.FirstOrDefault((AudienceLook l) => l.ID == lookID);
			if (audienceLook != null)
			{
				this.TriggerLook?.Invoke(audienceLook);
				return;
			}
		}
		string lookName = ((dynamic)data).lookName;
		if (lookName != null && lookName.Length > 0)
		{
			AudienceLook audienceLook2 = AudienceLooks?.FirstOrDefault((AudienceLook l) => l.Name == lookName);
			if (audienceLook2 != null)
			{
				this.TriggerLook?.Invoke(audienceLook2);
				return;
			}
		}
		int num = ((dynamic)data).lookIndex;
		if (num >= 0 && num < (AudienceLooks?.Count ?? 0))
		{
			AudienceLook audienceLook3 = AudienceLooks?.ElementAtOrDefault(num);
			if (audienceLook3 != null)
			{
				this.TriggerLook?.Invoke(audienceLook3);
			}
		}
	}

	private void RequestMacrosHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		if (MacroSource != null)
		{
			sendResponse(JObject.FromObject(new
			{
				macros = MacroSource.FlatCollection.Select((ProPresenterMacro macro) => new
				{
					macroName = macro.Name,
					macroID = macro.ID.ToString(),
					macroIndex = MacroSource.FlatCollection.IndexOf(macro),
					macroColor = macro.Color.EncodeColor()
				})
			}), injectAction: true);
		}
	}

	private void RequestMacrosTriggerHandler(JObject data, RemoteClient client, SendResponseDelegate sendResponse)
	{
		if (Guid.TryParse((string)((dynamic)data).macroID, out var macroID))
		{
			ProPresenterMacro proPresenterMacro = MacroSource?.FlatCollection.FirstOrDefault((ProPresenterMacro l) => l.ID == macroID);
			if (proPresenterMacro != null)
			{
				this.TriggerMacro?.Invoke(proPresenterMacro);
				return;
			}
		}
		string macroName = ((dynamic)data).macroName;
		if (macroName != null && macroName.Length > 0)
		{
			ProPresenterMacro proPresenterMacro2 = MacroSource?.FlatCollection.FirstOrDefault((ProPresenterMacro l) => l.Name == macroName);
			if (proPresenterMacro2 != null)
			{
				this.TriggerMacro?.Invoke(proPresenterMacro2);
				return;
			}
		}
		int num = ((dynamic)data).macroIndex;
		if (num >= 0 && num < (MacroSource?.FlatCollection.Count() ?? 0))
		{
			ProPresenterMacro proPresenterMacro3 = MacroSource?.FlatCollection.ElementAtOrDefault(num);
			if (proPresenterMacro3 != null)
			{
				this.TriggerMacro?.Invoke(proPresenterMacro3);
			}
		}
	}

	public void NotifySlideTriggered(IArrangedCue arrangedCue, int buildPosition, OutputDestination destination)
	{
		switch (destination)
		{
		case OutputDestination.Presentation:
		{
			if ((ActivePlaylistItem as IDocumentCue)?.DocumentAction?.Presentation == null)
			{
				break;
			}
			string presentationPath = DocumentCueToPath(ActivePlaylistItem as IDocumentCue);
			if (ActivePlaylistItem != null)
			{
				Playlist<ProPresenterCue>? activePlaylist = ActivePlaylist;
				if (activePlaylist != null && activePlaylist.Contains(ActivePlaylistItem))
				{
					presentationPath = $"{GeneratePlaylistPath(ActivePlaylist)}:{ActivePlaylist.IndexOf(ActivePlaylistItem)}";
				}
			}
			Broadcast("presentationTriggerIndex", JObject.FromObject(new
			{
				slideIndex = ((ActivePlaylistItem as IDocumentCue)?.DocumentAction?.ActiveArrangement?.ArrangedCues.IndexOf(arrangedCue) ?? (-1)),
				presentationPath = presentationPath,
				presentationDestination = (int)destination
			}));
			break;
		}
		case OutputDestination.Announcement:
		{
			DocumentCue documentCue = Libraries?.FindDocument(arrangedCue.Source?.ParentPresentation?.SourceFile);
			Broadcast("presentationTriggerIndex", JObject.FromObject(new
			{
				slideIndex = documentCue?.DocumentAction.ActiveArrangement?.ArrangedCues.IndexOf(arrangedCue),
				presentationPath = DocumentCueToPath(documentCue),
				presentationDestination = (int)destination
			}));
			break;
		}
		}
	}

	private void NotifyClockTimerStartStop(TimerBase? timer)
	{
		int num = Timers?.FindIndex((TimerData t) => t.Active == timer) ?? (-1);
		if (num >= 0)
		{
			timer.ThrowWhenNull("timer");
			string text = TimeToString(timer.RunningTime);
			Broadcast("clockStartStop", JObject.FromObject(new
			{
				clockTime = text,
				clockState = timer.IsTimerRunning,
				clockIndex = num,
				clockInfo = new object[3]
				{
					num + 1,
					timer.IsTimerRunning,
					text
				}
			}));
		}
	}

	private void NotifyClockReset(TimerBase timer)
	{
		int num = Timers?.FindIndex((TimerData t) => t.Active == timer) ?? (-1);
		if (num >= 0)
		{
			Broadcast("clockResetIndex", JObject.FromObject(new
			{
				clockIndex = num
			}));
		}
	}

	private void NotifyClockNameChanged(TimerData? timer)
	{
		int num = Timers?.FindIndex((TimerData t) => t == timer) ?? (-1);
		if (num >= 0)
		{
			timer.ThrowWhenNull("timer");
			Broadcast("clockNameChanged", JObject.FromObject(new
			{
				clockName = timer.Name,
				clockIndex = num,
				clockInfo = new object[2]
				{
					num + 1,
					timer.Name
				}
			}));
		}
	}

	private void NotifyTimersCollectionChanged()
	{
		if (Timers != null)
		{
			Broadcast("clockDeleteAdd", JObject.FromObject(new
			{
				clockInfo = Timers.Select((TimerData t) => new
				{
					clockType = (int)(t.Source?.TimerType ?? TimerType.Countdown),
					clockState = (t.Active?.IsTimerRunning ?? false),
					clockName = (t.Name ?? string.Empty),
					clockTimePeriodFormat = (int)((t.Source as CountdownToTime)?.TimeFormat ?? TimeFormat.AM),
					clockFormat = BuildClockFormat(t.Source),
					clockDuration = TimeToString(t.Source?.StartTime),
					clockOverrun = t.Source?.IsOverRunAllowed,
					clockEndTime = TimeToString(t.Source?.EndTime),
					clockTime = TimeToString(t.Active?.RunningTime)
				})
			}));
		}
	}

	private void NotifyClockDurationChanged(TimerBase? timer)
	{
		if (Timers != null)
		{
			int num = Timers?.FindIndex((TimerData t) => t.Source == timer) ?? (-1);
			if (num >= 0)
			{
				timer.ThrowWhenNull("timer");
				string text = TimeToString((timer.TimerType == TimerType.CountdownToTime) ? timer.EndTime : timer.StartTime);
				Broadcast("clockDurationChanged", JObject.FromObject(new
				{
					clockDuration = text,
					clockIndex = num,
					clockInfo = new object[2]
					{
						num + 1,
						text
					}
				}));
			}
		}
	}

	private void NotifyClockTypeChanged(TimerBase timer)
	{
		if (Timers != null)
		{
			int num = Timers.FindIndex((TimerData t) => t.Source == timer);
			if (num >= 0)
			{
				Broadcast("clockTypeChanged", JObject.FromObject(new
				{
					clockType = (int)timer.TimerType,
					clockIndex = num,
					clockInfo = new object[2]
					{
						num + 1,
						((int)timer.TimerType).ToString()
					}
				}));
			}
		}
	}

	private void NotifyTimeFormatChanged(CountdownToTime? countdownToTime)
	{
		if (Timers != null && countdownToTime != null)
		{
			int num = Timers.FindIndex((TimerData t) => t.Source == countdownToTime);
			if (num >= 0)
			{
				Broadcast("clockIsPMChanged", JObject.FromObject(new
				{
					clockTimePeriodFormat = (int)countdownToTime.TimeFormat,
					clockFormat = BuildClockFormat(countdownToTime),
					clockIndex = num,
					clockInfo = new object[2]
					{
						num + 1,
						(int)countdownToTime.TimeFormat
					}
				}));
			}
		}
	}

	private void NotifyEndTimeChanged(TimerBase? timer)
	{
		if (Timers != null && timer != null && timer.TimerType != 0)
		{
			int num = Timers.FindIndex((TimerData t) => t.Source == timer);
			if (num >= 0)
			{
				string text = TimeToString(timer.EndTime);
				Broadcast("clockEndTimeChanged", JObject.FromObject(new
				{
					clockEndTime = text,
					clockIndex = num,
					clockInfo = new object[2]
					{
						num + 1,
						text
					}
				}));
			}
		}
	}

	private void NotifyClockOverrrunChanged(TimerBase? timer)
	{
		if (Timers != null && timer != null)
		{
			int num = Timers.FindIndex((TimerData t) => t.Source == timer);
			if (num >= 0)
			{
				Broadcast("clockOverrunChanged", JObject.FromObject(new
				{
					clockOverrun = timer.IsOverRunAllowed,
					clockIndex = num,
					clockInfo = new object[2]
					{
						num + 1,
						timer.IsOverRunAllowed
					}
				}));
			}
		}
	}

	private void UpdateCurrentTimers_Tick(object? sender, EventArgs e)
	{
		IEnumerable<TimerData> enumerable = Timers?.Where((TimerData t) => t?.Source != null);
		if (enumerable == null || enumerable.Empty())
		{
			return;
		}
		lock (_subscribedTimerClients)
		{
			_broadcast("clockCurrentTimes", JObject.FromObject(new
			{
				clockTimes = enumerable.Select((TimerData t) => TimeToString(t.Active?.RunningTime))
			}), _subscribedTimerClients.Contains);
		}
	}

	private void NotifyMessagesUpdated()
	{
		if (Messages != null)
		{
			Broadcast("messageRequest", EncodeMessages());
		}
	}

	public void NotifyMessageShown(Message message)
	{
		if (message != null)
		{
			Broadcast("messageSend", JObject.FromObject(new
			{
				messageIndex = (Messages?.IndexOf(message) ?? (-1))
			}));
		}
	}

	public void NotifyMessageHidden(Message message)
	{
		if (message != null)
		{
			Broadcast("messageHide", JObject.FromObject(new
			{
				messageIndex = (Messages?.IndexOf(message) ?? (-1))
			}));
		}
	}

	public void NotifyClearAll()
	{
		Broadcast("clearAll");
	}

	public void NotifySlideCleared(OutputDestination destination)
	{
		Broadcast((destination == OutputDestination.Announcement) ? "clearAnnouncements" : "clearText");
	}

	public void NotifyBackgroundCleared()
	{
		Broadcast("clearVideo");
	}

	public void NotifyAudioCleared()
	{
		Broadcast("clearAudio");
	}

	public void NotifyPropCleared()
	{
		Broadcast("clearProps");
	}

	public void NotifyAudioTriggered(MediaCue? cue, bool audioIsPlaying)
	{
		if (cue != null)
		{
			Broadcast("audioTriggered", JObject.FromObject(new
			{
				audioName = cue.MediaAction?.AudioMedia?.SourceFile.Filename,
				audioArtist = cue.MediaAction?.AudioMedia?.Metadata?.Artist
			}));
		}
		Broadcast("audioPlayPause", JObject.FromObject(new
		{
			audioPlayPause = (audioIsPlaying ? "Playing" : "Pause")
		}));
	}

	public void NotifyStageScreenLayoutsChanged()
	{
		if (StageScreens != null && StageScreenLayoutMap != null && StageLayouts != null)
		{
			Broadcast("stageDisplaySets", JObject.FromObject(new
			{
				stageScreens = from s in StageScreens
					where StageScreenLayoutMap.ContainsKey(s)
					select new
					{
						stageScreenName = s.Name,
						stageScreenUUID = s.ID,
						stageLayoutSelectedLayoutUUID = StageScreenLayoutMap[s]?.ID
					},
				stageLayouts = StageLayouts.DefaultArrangement.ArrangedCues.Select((ArrangedCue l) => new
				{
					stageLayoutName = l.Source.Name,
					stageLayoutUUID = l.Source.ID
				})
			}));
		}
	}

	private void MacroSource_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		NotifyMacrosChanged();
	}

	internal void NotifyMacrosChanged()
	{
		if (MacroSource != null)
		{
			Broadcast("macrosRequest", JObject.FromObject(new
			{
				macros = MacroSource.FlatCollection.Select((ProPresenterMacro macro) => new
				{
					macroName = macro.Name,
					macroID = macro.ID.ToString(),
					macroIndex = MacroSource.FlatCollection.IndexOf(macro),
					macroColor = macro.Color.EncodeColor()
				})
			}));
		}
	}

	private void AudienceLooks_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		NotifyLooksChanged();
	}

	private void NotifyLooksChanged()
	{
		if (AudienceLooks != null)
		{
			Broadcast("looksRequest", JObject.FromObject(new
			{
				looks = AudienceLooks.Select((AudienceLook look) => new
				{
					lookName = look.Name,
					lookID = look.ID.ToString(),
					lookIndex = AudienceLooks.IndexOf(look)
				}),
				activeLook = new
				{
					lookName = (_liveLook?.Live.Name ?? ""),
					lookID = _liveLook?.OriginalID.ToString()
				}
			}));
		}
	}

	private object? BuildClockFormat(TimerBase? timer)
	{
		if (timer == null)
		{
			return null;
		}
		TimerFormatData timerFormatData = new TimerFormatData();
		return new
		{
			clockHourFormat = (int)timerFormatData.HourFormat,
			clockMinuteFormat = (int)timerFormatData.MinuteFormat,
			clockSecondFormat = (int)timerFormatData.SecondFormat,
			clockMillisecondFormat = (int)timerFormatData.MillisecondFormat,
			clockWallTimeFormat = timerFormatData.UseWallClockFormat,
			clockTimePeriodFormat = (int)((timer as CountdownToTime)?.TimeFormat ?? TimeFormat.AM)
		};
	}

	private string TimeToString(TimeSlice? time)
	{
		if (time.HasValue && !(time == TimeSlice.MaxValue))
		{
			return TimeSliceHelper.TimeSliceToString(time.Value);
		}
		return "--:--:--";
	}

	private string DocumentCueToPath(IDocumentCue? documentCue)
	{
		RelativePath relativePath = documentCue?.DocumentAction?.Presentation?.SourceFile;
		return (((object)relativePath != null) ? ((string)relativePath) : string.Empty).Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
	}
}
