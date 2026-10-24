using System;
using System.ComponentModel;
using Pro.Common.Components;

namespace ProPresenter.DO.Actions;

public class PlaylistActionValidator : NotifyPropertyChangedBase, IPlaylistActionValidator, INotifyPropertyChanged
{
	private readonly PlaylistAction _playlistAction;

	private readonly ITargetPlaylistCollection _targetPlaylistCollection;

	private bool _isValid;

	public bool IsValid
	{
		get
		{
			return _isValid;
		}
		private set
		{
			SetValue("IsValid", ref _isValid, value);
		}
	}

	public event Action<string?>? UpdateName;

	public PlaylistActionValidator(PlaylistAction playlistAction, ITargetPlaylistCollection targetPlaylistCollection)
	{
		_playlistAction = playlistAction;
		_playlistAction.DataModified += Validate;
		_targetPlaylistCollection = targetPlaylistCollection;
		_targetPlaylistCollection.CollectionModified += Validate;
		Validate();
	}

	private void Validate()
	{
		Guid playlistID = _playlistAction.PlaylistID;
		string playlistName = _playlistAction.PlaylistName;
		IIdentifiable playlist = _targetPlaylistCollection.GetPlaylist(playlistID, playlistName);
		IsValid = playlist != null;
		if (IsValid && playlist?.Name != playlistName)
		{
			this.UpdateName?.Invoke(playlist?.Name);
		}
	}
}
