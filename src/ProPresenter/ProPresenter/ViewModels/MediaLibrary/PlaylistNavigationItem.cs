using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.SourceGenerator.Attributes;
using Pro.UI.Themes;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenter.UI.ViewModels.MediaLibrary;

namespace ProPresenter.ViewModels.MediaLibrary;

public class PlaylistNavigationItem : ObservableObject, INavigationItem
{
	private readonly string? _name;

	private readonly PairedCollection<IPlaylist<MediaCue>, PlaylistNavigationItem> _children;

	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Name", "Name")]
	private readonly IPlaylist<MediaCue>? _playlist;

	public INavigationItem? Parent { get; }

	public IEnumerable Children => _children;

	public ImageSource? Icon
	{
		get
		{
			if (Parent == null || Playlist == null)
			{
				return Icons.GetIcon(Icons.MediaBinPlaylistHeader);
			}
			return Playlist.Type switch
			{
				PlaylistType.Custom => Icons.GetIcon(Icons.MediaBinPlaylist), 
				PlaylistType.Group => Icons.GetIcon(Icons.MediaBinFolder), 
				PlaylistType.Smart => Icons.GetIcon(Icons.MediaBinSmartPlaylist), 
				PlaylistType.LiveVideo => Icons.GetIcon(Icons.MediaBinVideoInputPlaylist), 
				_ => null, 
			};
		}
	}

	public IPlaylist<MediaCue>? Playlist => _playlist;

	public string Name => _name ?? Playlist?.Name ?? string.Empty;

	public PlaylistNavigationItem(IPlaylist<MediaCue> playlist, INavigationItem? parent, string? name = null)
		: this(parent, playlist as VisualGroupPlaylist, name)
	{
		_playlist = playlist;
		AddPropertyLinks();
	}

	public PlaylistNavigationItem(INavigationItem? parent, INotifyEnumerableChanged<IPlaylist<MediaCue>>? playlists, string? name)
	{
		Parent = parent;
		_name = name;
		_children = new PairedCollection<IPlaylist<MediaCue>, PlaylistNavigationItem>(playlists, (IPlaylist<MediaCue> child) => new PlaylistNavigationItem(child, this));
	}

	public INavigationItem? FindItem(IPlaylist<MediaCue> selectedPlaylist)
	{
		if (Playlist == selectedPlaylist)
		{
			return this;
		}
		if (Children != null)
		{
			foreach (INavigationItem item in Children.Cast<INavigationItem>())
			{
				if (item is PlaylistNavigationItem playlistNavigationItem)
				{
					INavigationItem navigationItem = playlistNavigationItem.FindItem(selectedPlaylist);
					if (navigationItem != null)
					{
						return navigationItem;
					}
				}
			}
		}
		return null;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _playlist_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Name")
		{
			OnPropertyChanged("Name");
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_playlist.PropertyChanged += _playlist_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		if (_playlist != null)
		{
			_playlist.PropertyChanged -= _playlist_PropertyChanged;
		}
	}
}
