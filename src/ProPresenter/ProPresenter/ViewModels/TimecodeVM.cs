using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.UI.Components;
using Pro.ssAPI.Devices;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Repositories;
using ProPresenter.DO.Timecode;
using ProPresenter.DO.Timer;
using ProPresenter.UI.ViewModels;
using ProPresenter.ViewModels.Timecode;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.ViewModels;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_debouncer" })]
public class TimecodeVM : LinkedNotifyPropertyChangedBase, ITimecodeVM, INotifyPropertyChanged, IDisposable
{
	private sealed class TimeTriggerableCollection : ObservableCollection<ITimeTriggerable>, INotifyEnumerableChanged<ITimeTriggerable>, IEnumerable<ITimeTriggerable>, IEnumerable, INotifyCollectionChanged
	{
	}

	[CompilerGenerated]
	private sealed class _003CGetItems_003Ed__73 : IEnumerable<TimecodeItem>, IEnumerable, IEnumerator<TimecodeItem>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private TimecodeItem _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public TimecodeVM _003C_003E4__this;

		private IEnumerator<ITimecodeItemVM> _003C_003E7__wrap1;

		TimecodeItem IEnumerator<TimecodeItem>.Current
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
		public _003CGetItems_003Ed__73(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				TimecodeVM timecodeVM = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E7__wrap1 = timecodeVM._timecodeItems.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				if (_003C_003E7__wrap1.MoveNext())
				{
					ITimecodeItemVM current = _003C_003E7__wrap1.Current;
					_003C_003E2__current = new TimecodeItem(current.Item, current.Item.Offset.TotalSeconds, current.SequenceID);
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<TimecodeItem> IEnumerable<TimecodeItem>.GetEnumerator()
		{
			_003CGetItems_003Ed__73 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003CGetItems_003Ed__73(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<TimecodeItem>)this).GetEnumerator();
		}
	}

	private Playlist<ProPresenterCue>? _selectedPlaylist;

	private bool _isPopupOpen;

	private readonly ITimecodeSettings _settings;

	private readonly ITimecodeService _timecodeService;

	private readonly IOutputRepository _outputRepo;

	private readonly ITimecodeAnalyticsEvents _timecodeAnalyticEvents;

	private readonly TimerFormatData _timeFormatData;

	private readonly IDebouncer<IEnumerable<ITimecodeItemVM>> _debouncer;

	private readonly PairedCollection<ITimeTriggerable, ITimecodeItemVM> _timecodeItems;

	private readonly TimeTriggerableCollection _timeTriggerableItems = new TimeTriggerableCollection();

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public string TimecodeTimeStr => TimeSlice.FromSeconds(_timecodeService.CurrentTimecodePlaybackStatus?.Time ?? 0.0).FormatTime(_timecodeService.CurrentTimecodePlaybackStatus?.Framerate ?? 0.0, showSubSeconds: true, _timeFormatData);

	public TimedPlaybackState State => _timecodeService.CurrentTimecodePlaybackStatus?.State ?? TimedPlaybackState.Stopped;

	public IAudioInputDevice? SelectedDevice => _outputRepo.AudioInputDeviceCollection.FirstOrDefault((IAudioInputDevice a) => a.UUID == _settings.DeviceID);

	public AudioInputDeviceCollection Devices => _outputRepo.AudioInputDeviceCollection;

	public int Channel => _settings.Channel;

	public IEnumerable<int> Channels
	{
		get
		{
			if (SelectedDevice != null)
			{
				return Enumerable.Range(1, SelectedDevice.ChannelCount);
			}
			return Array.Empty<int>();
		}
	}

	public TimecodeFormat Format => _settings.Format;

	public IEnumerable<TimecodeFormat> Formats => Enum.GetValues<TimecodeFormat>();

	public double Offset
	{
		get
		{
			return _settings.Offset;
		}
		set
		{
			_settings.Offset = value;
		}
	}

	public Playlist<ProPresenterCue>? SelectedPlaylist
	{
		get
		{
			return _selectedPlaylist;
		}
		set
		{
			SetValue<Playlist<ProPresenterCue>>("SelectedPlaylist", ref _selectedPlaylist, value, delegate(Playlist<ProPresenterCue> o, Playlist<ProPresenterCue> n)
			{
				if (o != null)
				{
					TearDownPlaylist(o);
				}
				if (n != null)
				{
					SetupPlaylist(n);
				}
				_settings.Playlist = n?.ID ?? Guid.Empty;
			});
		}
	}

	public bool IsActive
	{
		get
		{
			return _settings.IsActive;
		}
		set
		{
			_settings.IsActive = value;
		}
	}

	public bool IsPopupOpen
	{
		get
		{
			return _isPopupOpen;
		}
		set
		{
			SetValue("IsPopupOpen", ref _isPopupOpen, value);
		}
	}

	public LibraryPlaylistCollection Playlists { get; }

	public ICollectionView Items { get; }

	public ICommand<Playlist<ProPresenterCue>> SelectPlaylistCommand => new RelayCommand<Playlist<ProPresenterCue>>(SelectPlaylistCommandExecuted);

	public ICommand ToggleTimecodeCommand => new AsyncRelayCommand(ToggleTimecodeCommandExecutedAsync);

	public ICommand<IAudioInputDevice?> SelectDeviceCommand => new RelayCommand<IAudioInputDevice>(SelectDeviceCommandExecuted);

	public ICommand<int> SelectChannelCommand => new RelayCommand<int>(delegate(int i)
	{
		_settings.Channel = i;
	});

	public ICommand<TimecodeFormat> SelectFormatCommand => new RelayCommand<TimecodeFormat>(delegate(TimecodeFormat f)
	{
		_settings.Format = f;
	});

	public ICommand<bool> MonitorCommand => new AsyncRelayCommand<bool>(MonitorExecuted);

	public TimecodeVM(ITimecodeService timecodeService, IProPresenterResourceService proResources, IOutputRepository outputRepo, ITimecodeAnalyticsEvents timecodeAnalyticEvents, IDebouncerFactory debouncerFactory, ITimecodeItemVMFactory timecodeItemVMFactory)
	{
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		TimecodeVM timecodeVM = this;
		_timecodeService = timecodeService;
		_outputRepo = outputRepo;
		_timecodeAnalyticEvents = timecodeAnalyticEvents;
		_timeFormatData = new TimerFormatData
		{
			HourFormat = TimerFormatStyle.Long,
			MinuteFormat = TimerFormatStyle.Long,
			SecondFormat = TimerFormatStyle.Long,
			MillisecondFormat = TimerFormatStyle.None
		};
		Playlists = proResources.LibraryPlaylists;
		_settings = _timecodeService.ActiveTimecodeSettings;
		_debouncer = debouncerFactory.Create<IEnumerable<ITimecodeItemVM>>(delegate
		{
			timecodeVM._timecodeService.UpdateSessionSequenceItemsAsync(timecodeVM.GetItems()).ExecuteAsync();
		}, 200.0);
		SelectedPlaylist = Playlists.GetPlaylists((IPlaylist<ProPresenterCue> p) => p.ID == timecodeVM._settings.Playlist)?.FirstOrDefault() as Playlist<ProPresenterCue>;
		_timecodeItems = new PairedCollection<ITimeTriggerable, ITimecodeItemVM>(_timeTriggerableItems, (ITimeTriggerable i) => timecodeItemVMFactory.Create(i));
		LinkProperties("DeviceID", new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "SelectedDevice", "Channels" }));
		LinkProperties("Channel", "Channel");
		LinkProperties("Format", "Format");
		LinkProperties("Offset", "Offset");
		LinkProperties("Playlist", "SelectedPlaylist");
		LinkProperties("IsActive", "IsActive");
		LinkProperties("CurrentTimecodePlaybackStatus", new string[2] { "TimecodeTimeStr", "State" });
		LinkAction("Time", delegate
		{
			timecodeVM._debouncer.Invoke(timecodeVM._timecodeItems);
		});
		_settings.PropertyChanged += base.RaiseLinkedValues;
		_timecodeService.PropertyChanged += base.RaiseLinkedValues;
		Items = CollectionViewSource.GetDefaultView(_timecodeItems);
		if (Items is ListCollectionView listCollectionView)
		{
			((Collection<SortDescription>)(object)listCollectionView.SortDescriptions).Add(new SortDescription("Time", ListSortDirection.Ascending));
			listCollectionView.IsLiveSorting = true;
			listCollectionView.LiveSortingProperties.Add("Time");
		}
		if (SelectedDevice != null)
		{
			_timecodeService.CreateTimecodePlaybackSessionAsync(GetItems());
		}
		_timecodeItems.CollectionChanged += TimecodeItems_CollectionChanged;
		_timecodeItems.ForEach(SetupItemVM);
		ITimecodeSettings activeTimecodeSettings = _timecodeService.ActiveTimecodeSettings;
		if (activeTimecodeSettings != null && activeTimecodeSettings.IsActive)
		{
			int playlistItemCount = SelectedPlaylist?.OfType<IDocumentCue>().Count((IDocumentCue d) => d.DocumentAction?.Presentation?.PresentationTimeline.IsTimecodeEnabled == true) ?? 0;
			_timecodeAnalyticEvents.Activate(playlistItemCount, _timeTriggerableItems.Count(), isStartup: true);
		}
		_timecodeAnalyticEvents.Startup(!string.IsNullOrEmpty(_timecodeService.ActiveTimecodeSettings?.DeviceID), _timecodeService.ActiveTimecodeSettings?.IsActive ?? false, _timecodeService.ActiveTimecodeSettings?.Playlist != Guid.Empty);
	}

	private void TimecodeItems_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<ITimecodeItemVM>().ForEach(TeardownItemVM);
		e.NewItems?.OfType<ITimecodeItemVM>().ForEach(SetupItemVM);
		_debouncer.Invoke(_timecodeItems);
	}

	private void SetupItemVM(ITimecodeItemVM vm)
	{
		vm.PropertyChanged += base.RaiseLinkedValues;
		vm.Item.DataModified += TimeTriggerableItems_DataModified;
	}

	private void TeardownItemVM(ITimecodeItemVM vm)
	{
		vm.PropertyChanged -= base.RaiseLinkedValues;
		vm.Item.DataModified -= TimeTriggerableItems_DataModified;
	}

	private void TimeTriggerableItems_DataModified()
	{
		_debouncer.Invoke(_timecodeItems);
	}

	private void SetupPlaylist(Playlist<ProPresenterCue> newPlaylist)
	{
		newPlaylist.CollectionChanged += Playlist_CollectionChanged;
		(from d in newPlaylist.OfType<IDocumentCue>()
			select d.DocumentAction?.Presentation).NonNull().ForEach(delegate(IPresentation d)
		{
			SetupTimeline(d.PresentationTimeline);
		});
	}

	private void TearDownPlaylist(Playlist<ProPresenterCue> oldPlaylist)
	{
		oldPlaylist.CollectionChanged -= Playlist_CollectionChanged;
		(from d in oldPlaylist.OfType<IDocumentCue>()
			select d.DocumentAction?.Presentation).NonNull().ForEach(delegate(IPresentation d)
		{
			TearDownTimeline(d.PresentationTimeline);
		});
	}

	private void Playlist_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		(from d in e.OldItems?.OfType<IDocumentCue>()
			select d.DocumentAction?.Presentation).NonNull().ForEach(delegate(IPresentation d)
		{
			TearDownTimeline(d.PresentationTimeline);
		});
		(from d in e.NewItems?.OfType<IDocumentCue>()
			select d.DocumentAction?.Presentation).NonNull().ForEach(delegate(IPresentation d)
		{
			SetupTimeline(d.PresentationTimeline);
		});
	}

	private void SetupTimeline(ProPresenter.DO.Presentation.Timeline presentationTimeline)
	{
		presentationTimeline.CollectionChanged += PresentationTimeline_CollectionChanged;
		presentationTimeline.PropertyChanged += PresentationTimeline_PropertyChanged;
		if (presentationTimeline.IsTimecodeEnabled)
		{
			_timeTriggerableItems.AddRange(presentationTimeline, ignoreDuplicates: false);
		}
	}

	private void TearDownTimeline(ProPresenter.DO.Presentation.Timeline presentationTimeline)
	{
		presentationTimeline.CollectionChanged -= PresentationTimeline_CollectionChanged;
		presentationTimeline.PropertyChanged -= PresentationTimeline_PropertyChanged;
		if (presentationTimeline.IsTimecodeEnabled)
		{
			_timeTriggerableItems.RemoveRange(presentationTimeline);
		}
	}

	private void PresentationTimeline_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (sender is ProPresenter.DO.Presentation.Timeline timeline && e.PropertyName == "IsTimecodeEnabled")
		{
			if (timeline.IsTimecodeEnabled)
			{
				_timeTriggerableItems.AddRange(timeline, ignoreDuplicates: false);
			}
			else
			{
				_timeTriggerableItems.RemoveRange(timeline);
			}
		}
	}

	private void PresentationTimeline_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (!(sender is ProPresenter.DO.Presentation.Timeline { IsTimecodeEnabled: not false }))
		{
			return;
		}
		e.OldItems?.OfType<ITimeTriggerable>().ForEach(delegate(ITimeTriggerable i)
		{
			_timeTriggerableItems.RemoveIf((object? item) => item is ITimeTriggerable timeTriggerable && timeTriggerable == i);
		});
		e.NewItems?.OfType<ITimeTriggerable>().ForEach(delegate(ITimeTriggerable i)
		{
			_timeTriggerableItems.Add(i);
		});
	}

	private void SelectPlaylistCommandExecuted(Playlist<ProPresenterCue> playlist)
	{
		SelectedPlaylist = playlist;
	}

	private async Task ToggleTimecodeCommandExecutedAsync()
	{
		IsActive = !IsActive;
		if (IsActive)
		{
			TimecodeItem[] items = GetItems().ToArray();
			if ((object)_timecodeService.ActiveSessionHandle == null && SelectedDevice != null)
			{
				await _timecodeService.CreateTimecodePlaybackSessionAsync(items);
			}
			await _timecodeService.UpdateSessionSequenceItemsAsync(items);
		}
		await _timecodeService.Engage(IsActive);
		if (IsActive)
		{
			_timecodeAnalyticEvents.Activate(SelectedPlaylist?.Count() ?? 0, _timeTriggerableItems.Count(), isStartup: false);
		}
	}

	private void SelectDeviceCommandExecuted(IAudioInputDevice? device)
	{
		_settings.DeviceID = device?.UUID ?? string.Empty;
	}

	private async Task MonitorExecuted(bool enable)
	{
		if (enable)
		{
			await _timecodeService.TimecodeCaptureStartAsync();
		}
		else
		{
			await _timecodeService.TimecodeCaptureStopAsync();
		}
	}

	[IteratorStateMachine(typeof(_003CGetItems_003Ed__73))]
	private IEnumerable<TimecodeItem> GetItems()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetItems_003Ed__73(-2)
		{
			_003C_003E4__this = this
		};
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_debouncer.Dispose();
		}
	}
}
