using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Pro.Common.Collections;
using Pro.Common.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Events;
using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller.NetworkAPI;

internal class PlaylistUpdatedEventHandler<T, C> : DebouncedEventSender<T> where T : IPlaylistCollectionUpdatedEvent where C : ProPresenterCue
{
	private sealed record PlaylistState(Guid Id, string Name, int Index, List<PlaylistState> Items, bool IsHidden = false)
	{
		private readonly int _hashCode;

		public PlaylistState(Guid Id, string Name, int Index, List<PlaylistState> Items, bool IsHidden = false)
		{
			_hashCode = HashCodeHelper.GenerateHashCode(new List<PlaylistState>[1] { Items }, Id, Name, Index, IsHidden);
			base._002Ector();
		}

		public override int GetHashCode()
		{
			return _hashCode;
		}

		public bool Equals(PlaylistState? other)
		{
			if ((object)other == null)
			{
				return false;
			}
			bool result = Id == other.Id && Name == other.Name && Index == other.Index && IsHidden == other.IsHidden;
			if (Items.Count != other.Items.Count)
			{
				result = false;
			}
			else
			{
				foreach (var (playlistState, index) in other.Items.Enumerate())
				{
					if (playlistState.Id != Items[index].Id || playlistState.Name != Items[index].Name || playlistState.IsHidden != Items[index].IsHidden)
					{
						result = false;
						break;
					}
				}
			}
			return result;
		}

		[CompilerGenerated]
		private bool PrintMembers(StringBuilder builder)
		{
			RuntimeHelpers.EnsureSufficientExecutionStack();
			builder.Append("Id = ");
			builder.Append(Id.ToString());
			builder.Append(", Name = ");
			builder.Append((object?)Name);
			builder.Append(", Index = ");
			builder.Append(Index.ToString());
			builder.Append(", Items = ");
			builder.Append(Items);
			builder.Append(", IsHidden = ");
			builder.Append(IsHidden.ToString());
			return true;
		}
	}

	private List<PlaylistState> _previousState = new List<PlaylistState>();

	private List<PlaylistState> _currentState = new List<PlaylistState>();

	public Func<Guid, string, uint, NetworkAPI_v1> _handlerUpdate;

	public IEnumerable<IPlaylist<C>> _playlists;

	public PlaylistUpdatedEventHandler(IEnumerable<IPlaylist<C>> playlists, Func<Guid, string, uint, NetworkAPI_v1> handlerUpdate)
	{
		_playlists = playlists;
		InitState();
		_handlerUpdate = handlerUpdate;
		ApplicationEventPublisher.AddHandler(this);
	}

	private void InitState()
	{
		UpdateCurrent();
		_previousState = _currentState;
	}

	private void UpdateCurrent()
	{
		_currentState = _playlists?.GetPlaylists().Select(delegate(IPlaylist<C> playlist, int i)
		{
			IEnumerable<PlaylistState> enumerable = (playlist as Playlist<C>)?.Select((C item, int j) => new PlaylistState(item.ID, item.Name, j, new List<PlaylistState>(), item.IsHidden));
			IEnumerable<IPlaylist<C>> source = (playlist.PlaylistParent as IEnumerable<IPlaylist<C>>) ?? _playlists;
			return new PlaylistState(playlist.ID, playlist.Name, source.IndexOf(playlist), enumerable?.ToList() ?? new List<PlaylistState>());
		}).ToList() ?? new List<PlaylistState>();
	}

	protected override EventResult OnEventReceived(T @event)
	{
		UpdateCurrent();
		return EventResult.Debounce;
	}

	protected override void Publish()
	{
		_currentState.Except(_previousState).ForEach(delegate(PlaylistState x)
		{
			OnSend(_handlerUpdate(x.Id, x.Name, (uint)x.Index));
		});
		if (_previousState.Count > _currentState.Count)
		{
			foreach (PlaylistState x2 in _previousState)
			{
				if (!_currentState.Any((PlaylistState y) => y.Id == x2.Id))
				{
					OnSend(_handlerUpdate(x2.Id, x2.Name, (uint)x2.Index));
				}
			}
		}
		_previousState = _currentState;
	}
}
