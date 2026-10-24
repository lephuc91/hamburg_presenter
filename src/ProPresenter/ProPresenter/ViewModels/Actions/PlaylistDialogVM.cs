using System.Diagnostics.CodeAnalysis;
using Pro.Common.Collections;
using Pro.DO.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.Actions;

public class PlaylistDialogVM : ActionDialogContentVM
{
	private readonly IProPresenterResourceService _resources;

	public INotifyEnumerableChanged<IPlaylist<MediaCue>>? Playlists => base.Action?.ActionType switch
	{
		ActionType.VisualPlaylist => _resources.VisualPlaylists, 
		ActionType.AudioPlaylist => _resources.AudioPlaylists, 
		_ => null, 
	};

	public IPlaylist<MediaCue>? SelectedPlaylist
	{
		get
		{
			if (PlaylistAction == null)
			{
				return null;
			}
			return Playlists?.GetPlaylists().FirstOrDefaultBy((IPlaylist<MediaCue> p) => p.ID == PlaylistAction.PlaylistID, (IPlaylist<MediaCue> p) => p.Name == PlaylistAction.PlaylistName);
		}
		[param: DisallowNull]
		set
		{
			PlaylistAction?.SetIdentifier(value.ID, value.Name);
			OnPropertyChanged("SelectedPlaylist");
		}
	}

	public PlaylistAction? PlaylistAction => base.Action as PlaylistAction;

	public PlaylistDialogVM(IProPresenterResourceService resources)
	{
		_resources = resources;
	}

	protected override void OnContextChanged(IActionDialogContext? oldValue, IActionDialogContext? newValue)
	{
		OnPropertyChanged("Playlists");
		OnPropertyChanged("SelectedPlaylist");
		base.OnContextChanged(oldValue, newValue);
	}
}
