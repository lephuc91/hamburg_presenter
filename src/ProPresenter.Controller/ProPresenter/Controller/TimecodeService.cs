using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Time;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Repos;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Timecode;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.Controller;

public class TimecodeService : NotifyPropertyChangedBase, ITimecodeService, INotifyPropertyChanged
{
	private readonly DispatcherTimer _pollingTimer;

	private IEnumerable<TimecodeItem> _itemsCache = Array.Empty<TimecodeItem>();

	private readonly ITimedPlaybackRepository _timedPlaybackRepository;

	private readonly ITimecodeSettingsRepository _timecodeSettingsRepository;

	private readonly IProPresenterResourceService _resources;

	private TriggerHandle? _activeSessionHandle;

	private TimedPlaybackStatus? _currentStatus;

	public TriggerHandle? ActiveSessionHandle
	{
		get
		{
			return _activeSessionHandle;
		}
		private set
		{
			SetValue("ActiveSessionHandle", ref _activeSessionHandle, value);
		}
	}

	public TimedPlaybackStatus? CurrentTimecodePlaybackStatus
	{
		get
		{
			return _currentStatus;
		}
		private set
		{
			SetValue("CurrentTimecodePlaybackStatus", ref _currentStatus, value);
		}
	}

	public bool IsPolling
	{
		get
		{
			DispatcherTimer pollingTimer = _pollingTimer;
			if (pollingTimer == null)
			{
				return false;
			}
			return pollingTimer.IsEnabled;
		}
	}

	public ITimecodeSettings ActiveTimecodeSettings => _timecodeSettingsRepository.ActiveSettings;

	private double SecondsPerFrame => ActiveTimecodeSettings.Format.ToFps();

	public TimecodeService(ITimedPlaybackRepository timedPlaybackRepository, ITimecodeSettingsRepository timecodeSettingsRepository, IProPresenterResourceService resources)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		TimecodeService timecodeService = this;
		_timedPlaybackRepository = timedPlaybackRepository;
		_timecodeSettingsRepository = timecodeSettingsRepository;
		_resources = resources;
		_pollingTimer = new DispatcherTimer();
		_pollingTimer.Tick += async delegate
		{
			TimedPlaybackStatus timedPlaybackStatus = await timedPlaybackRepository.GetTimedPlaybackSessionStatusAsync(timecodeService.ActiveSessionHandle);
			if (timedPlaybackStatus.State != timecodeService.CurrentTimecodePlaybackStatus?.State || timedPlaybackStatus.Time != timecodeService.CurrentTimecodePlaybackStatus.Time || timedPlaybackStatus.Framerate != timecodeService.CurrentTimecodePlaybackStatus.Framerate)
			{
				timecodeService.CurrentTimecodePlaybackStatus = timedPlaybackStatus;
			}
		};
		ActiveTimecodeSettings.PropertyChanged += OnTimecodeSettingsUpdated;
	}

	public void StartTimecodePolling()
	{
		_pollingTimer.Interval = TimeSpan.FromSeconds(SecondsPerFrame);
		_pollingTimer.Start();
		OnPropertyChanged("IsPolling");
	}

	public void StopTimecodePolling()
	{
		_pollingTimer.Stop();
		OnPropertyChanged("IsPolling");
	}

	public async Task CreateTimecodePlaybackSessionAsync(IEnumerable<TimecodeItem> items)
	{
		if (items == null)
		{
			ActiveSessionHandle = null;
			StopTimecodePolling();
			throw new Exception("Timeline cannot be null");
		}
		if (ActiveTimecodeSettings == null)
		{
			ActiveSessionHandle = null;
			StopTimecodePolling();
			throw new Exception("Timecode settings cannot be null");
		}
		_itemsCache = (ActiveTimecodeSettings.IsActive ? items.ToArray() : Array.Empty<TimecodeItem>());
		Playlist<ProPresenterCue> playlist = _resources?.LibraryPlaylists?.GetPlaylists((IPlaylist<ProPresenterCue> p) => p.ID == ActiveTimecodeSettings.Playlist)?.FirstOrDefault() as Playlist<ProPresenterCue>;
		TimedPlayback data = new TimedPlayback
		{
			Sequence = new TimedPlayback.Types.Sequence
			{
				Sequence_ = { _itemsCache.Select((TimecodeItem i) => ToSequenceItem(playlist, i)).NonNull() }
			},
			Timing = new TimedPlayback.Types.Timing
			{
				SmpteTimecode = new TimedPlayback.Types.Timing.Types.SMPTETimecode
				{
					DeviceIdentifier = (ActiveTimecodeSettings.DeviceID ?? string.Empty),
					Channel = Math.Max(ActiveTimecodeSettings.Channel - 1, 0),
					Format = ActiveTimecodeSettings.Format.ToSMPTETimcodeFormat(),
					Offset = ActiveTimecodeSettings.Offset
				}
			}
		};
		ActiveSessionHandle = await _timedPlaybackRepository.CreateTimedPlaybackSessionAsync(data);
		if ((object)ActiveSessionHandle != null && ActiveSessionHandle != TriggerHandle.Invalid)
		{
			CurrentTimecodePlaybackStatus = await _timedPlaybackRepository.GetTimedPlaybackSessionStatusAsync(ActiveSessionHandle);
			OnPropertyChanged("CurrentTimecodePlaybackStatus");
			StartTimecodePolling();
		}
	}

	public async Task DestroyTimecodePlaybackSessionAsync()
	{
		if ((object)ActiveSessionHandle != null)
		{
			if (await _timedPlaybackRepository.DestroyTimedPlaybackSessionAsync(ActiveSessionHandle) != 0)
			{
				throw new Exception("Unable to destroy timed playback session");
			}
			ActiveSessionHandle = null;
			StopTimecodePolling();
		}
	}

	public async Task UpdateSessionSequenceItemsAsync(IEnumerable<TimecodeItem> items)
	{
		_itemsCache = ((ActiveTimecodeSettings?.IsActive ?? false) ? items.ToArray() : Array.Empty<TimecodeItem>());
		if ((object)ActiveSessionHandle != null)
		{
			Playlist<ProPresenterCue> playlist = _resources?.LibraryPlaylists?.GetPlaylists(delegate(IPlaylist<ProPresenterCue> p)
			{
				Guid iD = p.ID;
				Guid? obj = ActiveTimecodeSettings?.Playlist;
				return iD == obj;
			})?.FirstOrDefault() as Playlist<ProPresenterCue>;
			TimedPlayback.Types.Update update = new TimedPlayback.Types.Update
			{
				UpdateSequence = new TimedPlayback.Types.Sequence
				{
					Sequence_ = { _itemsCache.Select((TimecodeItem i) => ToSequenceItem(playlist, i)).NonNull() }
				}
			};
			await _timedPlaybackRepository.UpdateTimedPlaybackSessionAsync(ActiveSessionHandle, update);
		}
	}

	public async Task TimecodeCaptureStartAsync()
	{
		if ((object)ActiveSessionHandle != null)
		{
			TimedPlayback.Types.Update update = new TimedPlayback.Types.Update
			{
				MonitorSource = new TimedPlayback.Types.Update.Types.MonitorSource
				{
					Enable = true
				}
			};
			await _timedPlaybackRepository.UpdateTimedPlaybackSessionAsync(ActiveSessionHandle, update);
		}
	}

	public async Task TimecodeCaptureStopAsync()
	{
		if ((object)ActiveSessionHandle != null)
		{
			TimedPlayback.Types.Update update = new TimedPlayback.Types.Update
			{
				MonitorSource = new TimedPlayback.Types.Update.Types.MonitorSource
				{
					Enable = false
				}
			};
			await _timedPlaybackRepository.UpdateTimedPlaybackSessionAsync(ActiveSessionHandle, update);
		}
	}

	public async Task UpdateTimecodeSettingsAsync(TimedPlayback proto)
	{
		await DestroyTimecodePlaybackSessionAsync();
		ActiveSessionHandle = await _timedPlaybackRepository.CreateTimedPlaybackSessionAsync(proto);
		if (!ActiveSessionHandle.Equals(null) && ActiveSessionHandle != TriggerHandle.Invalid)
		{
			CurrentTimecodePlaybackStatus = await _timedPlaybackRepository.GetTimedPlaybackSessionStatusAsync(ActiveSessionHandle);
			StartTimecodePolling();
		}
	}

	public async Task Engage(bool engage)
	{
		if ((object)ActiveSessionHandle != null)
		{
			TimedPlayback.Types.Update update = (engage ? new TimedPlayback.Types.Update
			{
				Play = new TimedPlayback.Types.Update.Types.Play()
			} : new TimedPlayback.Types.Update
			{
				Pause = new TimedPlayback.Types.Update.Types.Pause()
			});
			await _timedPlaybackRepository.UpdateTimedPlaybackSessionAsync(ActiveSessionHandle, update);
		}
	}

	private static TimedPlayback.Types.Sequence.Types.SequenceItem? ToSequenceItem(Playlist<ProPresenterCue>? playlist, TimecodeItem item)
	{
		IDocumentCue documentCue = null;
		ITimeTriggerable item2 = item.Item;
		TimelineItemInfo timelineItem = item2 as TimelineItemInfo;
		if (timelineItem != null)
		{
			documentCue = (from d in playlist?.OfType<IDocumentCue>()
				where d.DocumentAction != null
				select d).FirstOrDefault((IDocumentCue d) => d.DocumentAction?.Presentation?.PresentationTimeline == timelineItem.Owner);
		}
		OutputDestination valueOrDefault = (documentCue?.DocumentAction?.Destination).GetValueOrDefault();
		Guid playlistID = playlist?.ID ?? Guid.Empty;
		Guid itemID = documentCue?.ID ?? Guid.Empty;
		TimeSlice endTime = documentCue?.DocumentAction?.Presentation?.PresentationTimeline?.Duration ?? TimeSlice.Zero;
		return item.Item.ToSequenceItem(item.Item.TriggerTime, endTime, valueOrDefault, playlistID, itemID, item.Offset, item.SequenceID);
	}

	private void OnTimecodeSettingsUpdated(object? sender, PropertyChangedEventArgs e)
	{
		OnTimecodeSettingsUpdatedAsync(e).ExecuteAsync();
	}

	private async Task OnTimecodeSettingsUpdatedAsync(PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "DeviceID":
		case "Format":
		case "Channel":
		case "Offset":
			await DestroyTimecodePlaybackSessionAsync();
			await CreateTimecodePlaybackSessionAsync(_itemsCache);
			break;
		}
	}

	public TimecodeInformation GetTimecodeInformation()
	{
		TimedPlaybackStatus currentTimecodePlaybackStatus = CurrentTimecodePlaybackStatus;
		TimeSlice value = TimeSlice.FromSeconds(currentTimecodePlaybackStatus?.Time ?? 0.0);
		double fps = currentTimecodePlaybackStatus?.Framerate ?? 0.0;
		System.Windows.Media.Color value2 = Colors.Transparent;
		if (currentTimecodePlaybackStatus != null)
		{
			value2 = currentTimecodePlaybackStatus.State switch
			{
				TimedPlaybackState.Stopped => Colors.Transparent, 
				TimedPlaybackState.Playing => Colors.Green, 
				TimedPlaybackState.Error => Colors.Red, 
				_ => Colors.Red, 
			};
		}
		return new TimecodeInformation
		{
			ElapsedTime = value,
			StatusColor = value2,
			Fps = fps
		};
	}

	public bool CanFollow(IDocumentCue? document)
	{
		if (ActiveTimecodeSettings == null || document?.PlaylistParent == null)
		{
			return false;
		}
		return ActiveTimecodeSettings.Playlist == document.PlaylistParent.ID;
	}
}
