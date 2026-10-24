using System;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Events;
using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller.NetworkAPI;

internal class PlaylistAndItemEventsHandler<T, E, EventSubType, ProtoPlaylist> : DebouncedEventSender<E> where T : ProPresenterCue where E : IApplicationEvent where EventSubType : IApplicationEvent
{
	private readonly bool _itemRequired;

	private readonly PlaylistCollectionBase<T> _playlistCollection;

	private T? _item;

	private Playlist<T>? _playlist;

	private ProtoPlaylist _previous;

	private ProtoPlaylist _current;

	private readonly Func<API_v1_Identifier?, API_v1_Identifier?, API_v1_PlaylistItem?, ProtoPlaylist> _createProto;

	private readonly Func<ProtoPlaylist, ProtoPlaylist, bool> _protoEqual;

	private readonly Func<ProtoPlaylist, NetworkAPI_v1> _sendUpdate;

	public PlaylistAndItemEventsHandler(PlaylistCollectionBase<T> playlistCollection, Func<API_v1_Identifier?, API_v1_Identifier?, API_v1_PlaylistItem?, ProtoPlaylist> createProto, Func<ProtoPlaylist, ProtoPlaylist, bool> protoEqual, Func<ProtoPlaylist, NetworkAPI_v1> sendUpdate, bool itemRequired)
	{
		_itemRequired = itemRequired;
		_playlistCollection = playlistCollection;
		_createProto = createProto;
		_current = Proto();
		_previous = _current;
		_protoEqual = protoEqual;
		_sendUpdate = sendUpdate;
		ApplicationEventPublisher.AddHandler(this);
	}

	protected override EventResult OnEventReceived(E @event)
	{
		EventResult result = EventResult.Continue;
		if (@event is PlaylistCollectionUpdated<T>)
		{
			result = Update();
		}
		else if (@event is EventSubType)
		{
			if (@event is PlaylistUpdated<T> playlistUpdated)
			{
				_item = playlistUpdated.Item;
				_playlist = playlistUpdated.Playlist;
				result = Update();
			}
			else if (@event is PlaylistProtoRequest<ProtoPlaylist> playlistProtoRequest)
			{
				playlistProtoRequest.Callback(_current);
			}
			else if (@event is PlaylistRequest<Playlist<T>> playlistRequest)
			{
				playlistRequest.Callback(_playlist);
			}
		}
		return result;
	}

	private EventResult Update()
	{
		ProtoPlaylist val = Proto();
		int result = (_protoEqual(_current, val) ? 1 : 0);
		_current = val;
		return (EventResult)result;
	}

	private ProtoPlaylist Proto()
	{
		Playlist<T> playlist = _playlist;
		int num = Common.PlaylistIndexInParent(playlist, _playlistCollection);
		if (num < 0)
		{
			playlist = null;
		}
		T val = _item;
		int num2 = ((val == null) ? (-1) : (playlist?.IndexOf(val) ?? (-1)));
		if (num2 < 0)
		{
			if (_itemRequired)
			{
				playlist = null;
			}
			val = null;
		}
		return _createProto(Common.NullableID(playlist, (uint)num), Common.NullableID(val, (uint)num2), val?.ToPlaylistItem(playlist));
	}

	protected override void Publish()
	{
		if (!_protoEqual(_previous, _current))
		{
			OnSend(_sendUpdate(_current));
		}
		_previous = _current;
	}
}
