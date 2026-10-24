using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller.Remote.Apps;

public class PlaylistEncoder : IPlaylistEncoder
{
	private readonly IDocumentPlaylistItemEncoder _documentEncoder;

	private readonly IMediaPlaylistItemEncoder _mediaEncoder;

	private readonly IHeaderPlaylistItemEncoder _headerEncoder;

	public PlaylistEncoder(IDocumentPlaylistItemEncoder? documentEncoder = null, IMediaPlaylistItemEncoder? mediaEncoder = null, IHeaderPlaylistItemEncoder? headerEncoder = null)
	{
		_documentEncoder = documentEncoder ?? new DocumentPlaylistItemEncoder();
		_mediaEncoder = mediaEncoder ?? new MediaPlaylistItemEncoder();
		_headerEncoder = headerEncoder ?? new HeaderPlaylistItemEncoder();
	}

	public AllPlaylistResponse Encode<T>(IEnumerable<IPlaylist<T>> playlists) where T : ProPresenterCue
	{
		return new AllPlaylistResponse
		{
			Playlists = GetPlaylistCollection(playlists).ToArray()
		};
	}

	private IEnumerable<Playlist> GetPlaylistCollection<T>(IEnumerable<IPlaylist<T>> playlists, string? location = null) where T : ProPresenterCue
	{
		int counter = 0;
		return playlists.Select(encode);
		Playlist encode(IPlaylist<T> source)
		{
			string location2 = (string.IsNullOrEmpty(location) ? counter++.ToString() : $"{location}.{counter++}");
			Playlist obj = new Playlist
			{
				Location = location2,
				Type = source.Type.ToInteropType(),
				Name = source.Name
			};
			object[] children;
			if (!(source is GroupPlaylist<T> groupPlaylist))
			{
				if (!(source is Playlist<T> playlist))
				{
					throw new NotSupportedException("Could not encode unknown playlist");
				}
				object[] array = GetPlaylistItems(playlist, location2).ToArray();
				children = array;
			}
			else
			{
				object[] array = GetPlaylistCollection(groupPlaylist.Children, location2).ToArray();
				children = array;
			}
			obj.Children = children;
			return obj;
		}
	}

	private IEnumerable<PlaylistItem> GetPlaylistItems<T>(Playlist<T> playlist, string location) where T : ProPresenterCue
	{
		int counter = 0;
		return (from i in playlist
			where !i.IsHidden
			select GetPlaylistItemData(i, $"{location}:{counter++}")).NonNull();
	}

	private PlaylistItem? GetPlaylistItemData<T>(T item, string location) where T : ProPresenterCue
	{
		PlaylistItem data = null;
		if (CueHelper.TryExecute(item, delegate(IDocumentCue d, DocumentAction _)
		{
			data = _documentEncoder.Encode(d);
		}, delegate(IMediaCue m, MediaAction _)
		{
			data = _mediaEncoder.Encode(m);
		}, delegate(IHeaderCue h, HeaderAction _)
		{
			data = _headerEncoder.Encode(h);
		}))
		{
			data.Location = location;
		}
		return data;
	}
}
