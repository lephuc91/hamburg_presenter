using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Time;
using Pro.Localization;
using Pro.UI.Components;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Settings;
using ProPresenter.UI;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public class AudioPlaylistVM : NotifyPropertyChangedBase, IAudioPlaylistVM, IPlaylistVM<MediaCue, AudioPlaylistCollection>, INotifyPropertyChanged
{
	private readonly ICoreManager _manager;

	private readonly IApp _app;

	private readonly IProPresenterResourceService _resourceService;

	private IPlaylist<MediaCue>? _selectedPlaylist;

	private MediaCue? _selectedAudioItem;

	private string _searchText = string.Empty;

	private readonly FilteredObservableCollection<MediaCue> _filteredCues;

	public AudioPlaylistCollection Playlists => _resourceService.AudioPlaylists;

	public IPlaylist<MediaCue>? SelectedPlaylist
	{
		get
		{
			return _selectedPlaylist;
		}
		set
		{
			SetValue<IPlaylist<MediaCue>>("SelectedPlaylist", ref _selectedPlaylist, value, delegate(IPlaylist<MediaCue> o, IPlaylist<MediaCue> n)
			{
				if (o is AudioPlaylist audioPlaylist)
				{
					audioPlaylist.CollectionChanged -= OnAudioPlaylistCollectionChanged;
				}
				if (n is AudioPlaylist audioPlaylist2)
				{
					audioPlaylist2.CollectionChanged += OnAudioPlaylistCollectionChanged;
					_manager.ActiveAudioPlaylist = audioPlaylist2;
				}
				_app.SelectedAudioPlaylist = n?.ID ?? Guid.Empty;
				SearchText = string.Empty;
				IAudioPlaylist collection = n as IAudioPlaylist;
				_filteredCues.UpdateSourceCollection(collection);
				OnPropertyChanged("ItemCountLabel");
				OnPropertyChanged("TotalPlayLength");
				OnPropertyChanged("DragDropCueSource");
				OnPropertyChanged("FilteredCues");
			}, (IPlaylist<MediaCue> n) => n == null || n is IAudioPlaylist);
		}
	}

	public string SearchText
	{
		get
		{
			return _searchText;
		}
		set
		{
			SetValue("SearchText", ref _searchText, value, (Action)delegate
			{
				_filteredCues.Refresh();
			}, (Predicate<string>?)null, referenceComparison: false);
		}
	}

	public string ItemCountLabel => GetItemCountLabel(((AudioPlaylist)SelectedPlaylist)?.Count() ?? 0);

	public string TotalPlayLength => GetTotalPlayLength((AudioPlaylist)SelectedPlaylist);

	public MediaCue? SelectedPlaylistItem
	{
		get
		{
			return _selectedAudioItem;
		}
		set
		{
			SetValue("SelectedPlaylistItem", ref _selectedAudioItem, value);
		}
	}

	public ObservableCollection<MediaCue> SelectedPlaylistItems { get; } = new ObservableCollection<MediaCue>();

	public ObservableCollection<IPlaylist<MediaCue>> SelectedPlaylists { get; } = new ObservableCollection<IPlaylist<MediaCue>>();

	public IDragDropNotifyEnumerableChanged<MediaCue>? DragDropCueSource => SelectedPlaylist as IAudioPlaylist;

	public INotifyEnumerableChanged<MediaCue> FilteredCues => _filteredCues;

	public ICommand DeletePlaylistCommand => new RelayCommand(OnDeletePlaylistCommand, () => SelectedPlaylists.Any());

	public ICommand DuplicatePlaylistCommand => new RelayCommand(OnDuplicatePlaylistCommand, () => SelectedPlaylists.Any());

	public ICommand<IPlaylist<MediaCue>> SelectPlaylistCommand => new RelayCommand<IPlaylist<MediaCue>>(delegate(IPlaylist<MediaCue> c)
	{
		SelectedPlaylist = c;
	});

	public AudioPlaylistVM(ICoreManager manager, IApp app, IProPresenterResourceService resourceService, IUiDispatcher uiDispatcher)
	{
		_manager = manager;
		_app = app;
		_resourceService = resourceService;
		_filteredCues = new UpdatingFilteredObservableCollection<MediaCue>(null, FilterCues, uiDispatcher, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Name"));
		_manager.ActiveAudioPlaylistChanged += delegate(Playlist<MediaCue> n)
		{
			SelectedPlaylist = n;
		};
		SelectedPlaylist = Playlists.GetPlaylists((IPlaylist<MediaCue> p) => p.ID == _app.SelectedAudioPlaylist).FirstOrDefault() ?? Playlists.FirstOrDefault();
		Playlists.LocationChanged += delegate
		{
			SelectedPlaylist = Playlists.FirstOrDefault();
		};
		Playlists.CollectionChanged += delegate
		{
			OnPropertyChanged("Playlists");
		};
		Playlists.CollectionModified += delegate
		{
			OnPropertyChanged("Playlists");
		};
	}

	private bool FilterCues(MediaCue cue)
	{
		if (!string.IsNullOrWhiteSpace(SearchText))
		{
			return cue.Name.ToLowerInvariant().Contains(SearchText.ToLowerInvariant());
		}
		return true;
	}

	private void OnAudioPlaylistCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		OnPropertyChanged("TotalPlayLength");
		OnPropertyChanged("ItemCountLabel");
	}

	private static string GetItemCountLabel(int items)
	{
		if (items != 1)
		{
			return LocalizedStrings.Get("PLAYLIST_HEADER_ITEM_COUNT_PLURAL_title", new object[1] { items });
		}
		return LocalizedStrings.Get("PLAYLIST_HEADER_ITEM_COUNT_title");
	}

	private static string GetTotalPlayLength(AudioPlaylist? playlist)
	{
		if (playlist != null)
		{
			return TimeSlice.FromMinutes(playlist.Sum((MediaCue c) => (c.MediaAction?.AudioMedia?.Metadata.Duration.TotalMinutes).GetValueOrDefault())).GetFormattedTotalLength();
		}
		return string.Empty;
	}

	private void OnDeletePlaylistCommand()
	{
		IPlaylist<MediaCue>[] array = SelectedPlaylists.ToArray();
		foreach (IPlaylist<MediaCue> playlist in array)
		{
			IReadOnlyList<ITrackedMedia> mediaToRemove = PlaylistHelper.GetTrackedMediaFromPlaylists(new global::_003C_003Ez__ReadOnlySingleElementList<IPlaylist<MediaCue>>(playlist));
			mediaToRemove.ForEach(delegate(ITrackedMedia x)
			{
				x.RemoveFromMediaService(deleteAssets: false);
			});
			if (playlist.Parent is GroupPlaylist<MediaCue> groupPlaylist)
			{
				using (groupPlaylist.UndoStack?.Transaction(UndoActionTypes.RemovePlaylist.ToAction(), null, null, autoFinalize: true))
				{
					groupPlaylist.RemoveChild(playlist);
					groupPlaylist.UndoStack?.Commit(delegate
					{
						mediaToRemove.ForEach(delegate(ITrackedMedia x)
						{
							x.AddToMediaServiceAndApplyTransform(userInitiated: true);
						});
					}, delegate
					{
						mediaToRemove.ForEach(delegate(ITrackedMedia x)
						{
							x.RemoveFromMediaService(deleteAssets: false);
						});
					});
				}
				continue;
			}
			using (Playlists.UndoStack?.Transaction(UndoActionTypes.RemovePlaylist.ToAction(), null, null, autoFinalize: true))
			{
				Playlists.Remove(playlist);
				Playlists.UndoStack?.Commit(delegate
				{
					mediaToRemove.ForEach(delegate(ITrackedMedia x)
					{
						x.AddToMediaServiceAndApplyTransform(userInitiated: true);
					});
				}, delegate
				{
					mediaToRemove.ForEach(delegate(ITrackedMedia x)
					{
						x.RemoveFromMediaService(deleteAssets: false);
					});
				});
			}
		}
	}

	private void OnDuplicatePlaylistCommand()
	{
		Playlists.Duplicate(SelectedPlaylists);
	}
}
