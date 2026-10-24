using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.UI.MediaLibrary;

public partial class MediaLibrarySelectionControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty SelectedPlaylistProperty = DependencyProperty.Register("SelectedPlaylist", typeof(IPlaylist<MediaCue>), typeof(MediaLibrarySelectionControl));

	public static readonly DependencyProperty PlaylistsProperty = DependencyProperty.Register("Playlists", typeof(INotifyEnumerableChanged<IPlaylist<MediaCue>>), typeof(MediaLibrarySelectionControl));

	public static readonly DependencyProperty NoSelectionTranslationKeyProperty = DependencyProperty.Register("NoSelectionTranslationKey", typeof(string), typeof(MediaLibrarySelectionControl));

	public static readonly DependencyProperty CanAddPlaylistProperty = DependencyProperty.Register("CanAddPlaylist", typeof(bool), typeof(MediaLibrarySelectionControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public IPlaylist<MediaCue>? SelectedPlaylist
	{
		get
		{
			return (IPlaylist<MediaCue>)((DependencyObject)this).GetValue(SelectedPlaylistProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedPlaylistProperty, (object)value);
		}
	}

	public INotifyEnumerableChanged<IPlaylist<MediaCue>>? Playlists
	{
		get
		{
			return (INotifyEnumerableChanged<IPlaylist<MediaCue>>)((DependencyObject)this).GetValue(PlaylistsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PlaylistsProperty, (object)value);
		}
	}

	public string? NoSelectionTranslationKey
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(NoSelectionTranslationKeyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NoSelectionTranslationKeyProperty, (object)value);
		}
	}

	public bool CanAddPlaylist
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanAddPlaylistProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanAddPlaylistProperty, (object)value);
		}
	}

	public IRelayCommand<IPlaylist<MediaCue>> SelectPlaylistCommand { get; }

	public MediaLibrarySelectionControl()
	{
		SelectPlaylistCommand = new RelayCommand<IPlaylist<MediaCue>>(SelectPlaylist);
		InitializeComponent();
	}

	private void SelectPlaylist(IPlaylist<MediaCue>? playlist)
	{
		((DependencyObject)this).SetCurrentValue(SelectedPlaylistProperty, (object)playlist);
	}
}
