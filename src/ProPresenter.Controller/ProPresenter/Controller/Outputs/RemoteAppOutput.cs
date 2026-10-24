using System;
using System.ComponentModel;
using System.Windows.Threading;
using Newtonsoft.Json.Linq;
using Pro.Common.Components;
using ProPresenter.Controller.NetworkAPI.Receive;
using ProPresenter.Controller.Remote;
using ProPresenter.Controller.Remote.Apps;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Timer;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.Controller.Outputs;

public class RemoteAppOutput : LinkedNotifyPropertyChangedBase
{
	private const ProNetworkEndpointType ProRemoteEndpoint = ProNetworkEndpointType.kProNetworkEndpointRemote;

	private const string ProRemoteActionKey = "action";

	public const string WebResourcesRoot = "web/";

	private readonly ICoreManager _manager;

	private readonly ITimelineManager _timelineManager;

	private readonly INetwork _network;

	private readonly ITriggering _service;

	private readonly IProCoreInstance _proCore;

	private readonly WebSocketHandler _webSocketHandler;

	private readonly ProRemoteHandler _proRemoteHandler;

	public RemoteAppOutput(IProCoreInstance proCore, IServerStateHandler serverStateHandler, ICoreManager manager, ITriggeringFactory triggeringFactory, ITimelineManager timelineManager, INetwork network)
	{
		_proCore = proCore;
		_network = network;
		_webSocketHandler = new WebSocketHandler(_proCore);
		_proRemoteHandler = new ProRemoteHandler(_webSocketHandler.RegisterEndpoint(ProNetworkEndpointType.kProNetworkEndpointRemote, "action", isEnabled: true), delegate(string a, JObject d, Predicate<RemoteClient> p)
		{
			_webSocketHandler.Broadcast(ProNetworkEndpointType.kProNetworkEndpointRemote, a, d, p);
		}, Dispatcher.CurrentDispatcher);
		LinkAction("ActivePlaylistItem", ActivePlaylistItemChanged);
		LinkAction("ActiveSlide", ActiveSlideChanged);
		LinkAction("ActiveAudio", ActiveAudioChanged);
		LinkAction("ActiveLibraryPlaylist", ActivePlaylistChanged);
		LinkAction("ActiveAudioPlaylist", ActiveAudioPlaylistChanged);
		LinkAction("ConnectedPort", UpdateNetListeningState);
		network.PropertyChanged += OnNetworkSettingsChanged;
		UpdateNetConfig();
		UpdateNetListeningState();
		serverStateHandler.State.PropertyChanged += base.RaiseLinkedValues;
		_manager = manager;
		_timelineManager = timelineManager;
		_service = triggeringFactory.Create(TriggerSource.ProRemote);
		_proRemoteHandler.SetInteractor(new ProRemoteInteractor(new ProRemoteService(manager, triggeringFactory))
		{
			Libraries = DataVault.LibraryCollection,
			PlaylistLibrary = DataVault.LibraryPlaylistCollection
		});
		_proRemoteHandler.Libraries = DataVault.LibraryCollection;
		_proRemoteHandler.PlaylistLibrary = DataVault.LibraryPlaylistCollection;
		_proRemoteHandler.AudioPlaylistLibrary = DataVault.AudioPlaylistCollection;
		_proRemoteHandler.Timers = DataVault.TimerDocument.Timers;
		_proRemoteHandler.Messages = DataVault.Messages;
		_proRemoteHandler.StageScreens = OutputVault.StageScreenArrangementCollection;
		_proRemoteHandler.StageLayouts = DataVault.StagePresentation;
		_proRemoteHandler.StageScreenLayoutMap = manager.OutputConfiguration.StageScreenLayoutMap;
		_proRemoteHandler.MacroSource = DataVault.MacroSource;
		_proRemoteHandler.AudienceLooks = _manager.OutputConfiguration.AudienceLooks;
		_proRemoteHandler.TriggerPreviousSlide += _service.TriggerPreviousSlide;
		_proRemoteHandler.TriggerNextSlide += _service.TriggerNextSlide;
		_proRemoteHandler.ResetTimeline += ProRemoteHandler_ResetTimeline;
		_proRemoteHandler.PlayPauseTimeline += ProRemoteHandler_PlayPauseTimeline;
		_proRemoteHandler.TriggerAudio += delegate(MediaCue a, Playlist<MediaCue> p)
		{
			_service.TriggerAudio(a, p);
		};
		_proRemoteHandler.ChangeActiveAudioPlaylist += ProRemoteHandler_ChangeActiveAudioPlaylist;
		_proRemoteHandler.PlayAudio += delegate
		{
			_manager.PlayAudio(AudioType.AudioTrack);
		};
		_proRemoteHandler.PauseAudio += delegate
		{
			_manager.PauseAudio(AudioType.AudioTrack);
		};
		_proRemoteHandler.StartTimer += delegate(TimerData t)
		{
			_service.TriggerTimerAction(t, TimerActionType.Start, null);
		};
		_proRemoteHandler.StopTimer += delegate(TimerData t)
		{
			_service.TriggerTimerAction(t, TimerActionType.Stop, null);
		};
		_proRemoteHandler.ResetTimer += delegate(TimerData t)
		{
			_service.TriggerTimerAction(t, TimerActionType.Reset, null);
		};
		_proRemoteHandler.ClearAll += _manager.ClearAll;
		_proRemoteHandler.ClearSlide += _service.ClearSlide;
		_proRemoteHandler.ClearVideo += _service.ClearBackground;
		_proRemoteHandler.ClearAudio += _service.ClearAudio;
		_proRemoteHandler.ClearProps += _service.ClearProps;
		_proRemoteHandler.ClearToLogo += _manager.TriggerLogo;
		_proRemoteHandler.ClearMessages += _service.ClearMessages;
		_proRemoteHandler.ClearAnnouncement += _service.ClearAnnouncement;
		_proRemoteHandler.ShowMessage += _service.TriggerMessage;
		_proRemoteHandler.HideMessage += _service.ClearMessage;
		_proRemoteHandler.ChangeStageMessage += _service.SendStageMessage;
		_proRemoteHandler.HideStageMessage += _service.HideStageMessage;
		_proRemoteHandler.TriggerLook += _service.TriggerAudienceLook;
		_proRemoteHandler.TriggerMacro += _service.TriggerMacro;
		_manager.PropertyChanged += base.RaiseLinkedValues;
		_manager.SlideTriggered += _proRemoteHandler.NotifySlideTriggered;
		_manager.AudioTriggered += _proRemoteHandler.NotifyAudioTriggered;
		_manager.MessageTriggered += _proRemoteHandler.NotifyMessageShown;
		_manager.AllCleared += _proRemoteHandler.NotifyClearAll;
		_manager.SlideCleared += delegate(OutputDestination d)
		{
			_proRemoteHandler.NotifySlideCleared(d);
		};
		_manager.BackgroundCleared += _proRemoteHandler.NotifyBackgroundCleared;
		_manager.AudioCleared += _proRemoteHandler.NotifyAudioCleared;
		_manager.PropCleared += _proRemoteHandler.NotifyPropCleared;
		_manager.MessageCleared += _proRemoteHandler.NotifyMessageHidden;
		_manager.LiveLookChanged += _proRemoteHandler.UpdateLiveLook;
		_manager.TransportStatusChanged += Manager_TransportStatusChanged;
		_proRemoteHandler.UpdateLiveLook(_manager.OutputConfiguration.LiveLook);
	}

	private void OnNetworkSettingsChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "EnableRemoteStageDisplay":
		case "RemoteStageDisplayPassword":
			UpdateNetConfig();
			break;
		case "EnableNetwork":
		case "NetworkPort":
			UpdateNetListeningState();
			break;
		}
	}

	private void UpdateNetConfig()
	{
		_proCore.NetSetServiceConfig(new ProNetServiceConfig
		{
			RemoteStageEnabled = _network.EnableRemoteStageDisplay,
			RemoteStagePassword = _network.RemoteStageDisplayPassword,
			RemoteWebEnabled = true,
			SlaveTriggerEnabled = false
		});
		_webSocketHandler.DisableEndpoint(ProNetworkEndpointType.kProNetworkEndpointRemote);
	}

	private void UpdateNetListeningState()
	{
		if (_network.EnableNetwork)
		{
			ushort port = (ushort)_network.NetworkPort;
			bool num = port == _network.DefaultPort;
			_proCore.NetStartListener(ref port);
			if (!num && _network.NetworkPort != port)
			{
				_network.NetworkPort = port;
			}
		}
		else
		{
			_proCore.NetStopListener();
		}
	}

	private void ActiveSlideChanged()
	{
		_proRemoteHandler.ActiveSlide = _manager.ActiveSlide;
	}

	private void ActivePlaylistItemChanged()
	{
		if (_manager.ActivePlaylistItem != null)
		{
			_proRemoteHandler.ActivePlaylistItem = _manager.ActivePlaylistItem;
		}
	}

	private void ProRemoteHandler_ResetTimeline(IDocumentCue? documentCue, ILibrary? library, IPlaylist<ProPresenterCue>? playlist)
	{
		if (documentCue != null)
		{
			SetActive(documentCue, library, playlist);
			_timelineManager.Reset(documentCue);
		}
	}

	private void ProRemoteHandler_PlayPauseTimeline(IDocumentCue? documentCue, ILibrary? library, IPlaylist<ProPresenterCue>? playlist)
	{
		SetActive(documentCue, library, playlist);
		if (!_timelineManager.GetInfo(documentCue).isPlaying)
		{
			_timelineManager.Play(documentCue, null);
		}
		else
		{
			_timelineManager.Pause(documentCue);
		}
	}

	private void SetActive(IDocumentCue? documentCue, ILibrary? library, IPlaylist<ProPresenterCue>? playlist)
	{
		_manager.ActiveLibrary = library;
		_manager.ActiveLibraryPlaylist = playlist as Playlist<ProPresenterCue>;
		if (documentCue is ProPresenterCue activePlaylistItem)
		{
			_manager.ActivePlaylistItem = activePlaylistItem;
		}
	}

	private void ActiveAudioChanged()
	{
		if (_manager != null)
		{
			_proRemoteHandler.ActiveAudio = _manager.ActiveAudio?.MediaAction?.AudioMedia;
		}
	}

	private void ProRemoteHandler_ChangeActiveAudioPlaylist(AudioPlaylist? audioPlaylist)
	{
		if (_manager != null)
		{
			_manager.ActiveAudioPlaylist = audioPlaylist;
		}
	}

	private void Manager_TransportStatusChanged(ResourceAddress address, ProTransportStatus transportStatus)
	{
		if (address.Layer == ProLayerIndex.Music && address.ResourceType == ProResourceType.Media)
		{
			_proRemoteHandler.IsAudioPlaying = transportStatus.IsPlaying;
		}
	}

	private void ActivePlaylistChanged()
	{
		_proRemoteHandler.ActivePlaylist = _manager.ActiveLibraryPlaylist;
	}

	private void ActiveAudioPlaylistChanged()
	{
		_proRemoteHandler.ActiveAudioPlaylist = _manager.ActiveAudioPlaylist;
	}
}
