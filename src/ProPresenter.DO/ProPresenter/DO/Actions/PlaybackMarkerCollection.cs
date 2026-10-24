using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Actions;

public class PlaybackMarkerCollection : ImmutableObservableCollection<IPlaybackMarker>, IDragDropNotifyEnumerableChanged<IPlaybackMarker>, INotifyEnumerableChanged<IPlaybackMarker>, IEnumerable<IPlaybackMarker>, IEnumerable, INotifyCollectionChanged, IDragDropCollection<IPlaybackMarker>, ICutPasteCollection<IPlaybackMarker>, ICutCollection<IPlaybackMarker>, IActionRepoContainer, IHasMediaContainerId, ICanReceiveMediaContainerIdUpdates
{
	private UndoStack? _undoStack;

	private readonly IApp _app;

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			_undoStack = value;
			this.ForEach(delegate(IPlaybackMarker a)
			{
				a.UndoStack = _undoStack;
			});
		}
	}

	public string ContainerId { get; private set; }

	public event System.Action? DataModified;

	public static ObjectBinder<PlaybackMarkerCollection, IComplexCollection<Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker>> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, PlaybackMarkerCollection left, IComplexCollection<Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker> right)
	{
		ObjectBinder<PlaybackMarkerCollection, IComplexCollection<Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker>> objectBinder = new ObjectBinder<PlaybackMarkerCollection, IComplexCollection<Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker>>(left, right);
		objectBinder.Bind((PlaybackMarkerCollection l) => l.Collection.WhenCollectionChanges(), (IComplexCollection<Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker> r) => r.WhenCollectionChanges, delegate(PlaybackMarkerCollection l, IComplexCollection<Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker> r)
		{
			r.SynchronizeFrom(l, (IPlaybackMarker m, Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker e) => m.ID == e.Uuid.Value, delegate(IPlaybackMarker m)
			{
				Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker playbackMarker = entityFactory.Create<Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker>();
				IReadOnlyObjectBinder<IPlaybackMarker, Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker> readOnlyObjectBinder = m.Bind(scheduler, actionBinderFactory, entityFactory, playbackMarker);
				playbackMarker.RegisterLinkedDisposable(readOnlyObjectBinder);
				readOnlyObjectBinder.InitializeRightFromLeft();
				return playbackMarker;
			});
		}, delegate(IComplexCollection<Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker> r, PlaybackMarkerCollection l)
		{
			r.Items.SynchronizeTo(l.Collection, (Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker e, IPlaybackMarker m) => m.ID == e.Uuid.Value, delegate(Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker e, int i)
			{
				PlaybackMarker playbackMarker2 = new PlaybackMarker();
				playbackMarker2.UpdateContainerId(l.ContainerId);
				IReadOnlyObjectBinder<IPlaybackMarker, Pro.Entity.IAction.Types.IMediaType.Types.IPlaybackMarker> readOnlyObjectBinder2 = playbackMarker2.Bind(scheduler, actionBinderFactory, entityFactory, e);
				e.RegisterLinkedDisposable(readOnlyObjectBinder2);
				readOnlyObjectBinder2.InitializeLeftFromRight();
				l.InsertMarker(playbackMarker2, i);
			}, l.Collection.Move, delegate(int i)
			{
				IPlaybackMarker marker = l[i];
				l.RemoveMarker(marker);
			});
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	public PlaybackMarkerCollection(IApp app, string containerId)
	{
		_app = app;
		ContainerId = containerId;
		base.Collection.CollectionChanged += delegate(object? _, NotifyCollectionChangedEventArgs args)
		{
			args.NewItems?.OfType<IPlaybackMarker>().ForEach(delegate(IPlaybackMarker m)
			{
				m.UpdateContainerId(ContainerId);
			});
		};
	}

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		OnDataModified();
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public void AddMarker(IPlaybackMarker marker)
	{
		InsertMarker(marker, base.Collection.Count);
		SortMarkers();
	}

	public void AddMarkers(IEnumerable<IPlaybackMarker> markers)
	{
		SortMarkers();
		InsertMarkers(markers, base.Collection.Count);
	}

	public void InsertMarkers(IEnumerable<IPlaybackMarker> markers, int index)
	{
		if (markers != null)
		{
			UndoStack?.BeginCommit(UndoActionTypes.AddPlaybackMarker.ToAction());
			markers.ForEach(delegate(IPlaybackMarker m)
			{
				InsertMarker(m, index++);
			});
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public void InsertMarker(IPlaybackMarker marker, int index)
	{
		if (marker.Color == default(System.Windows.Media.Color))
		{
			marker.Color = _app.GetNextPlaybackMarkerColor();
		}
		insertAction();
		UndoStack?.Commit(UndoActionTypes.AddPlaybackMarker.ToAction(), delegate
		{
			RemoveMarker(marker);
		}, insertAction, null, null, autoFinalize: true);
		void insertAction()
		{
			marker.DataModified += OnDataModified;
			marker.TimestampChanged += SortMarkers;
			marker.UndoStack = UndoStack;
			base.Collection.Insert(base.Collection.ClampIndexExclusive(index), marker);
		}
	}

	public void RemoveMarker(IPlaybackMarker marker)
	{
		RemoveMarkers(marker.ToEnumerable());
	}

	public void RemoveMarkers(IEnumerable<IPlaybackMarker> markers)
	{
		KeyValuePair<int, IPlaybackMarker>[] itemIndices = (from m in markers.Distinct().ToDictionary(base.Collection.IndexOf, (IPlaybackMarker i) => i)
			orderby m.Key
			select m).ToArray();
		System.Action action = delegate
		{
			itemIndices.Reverse().ForEach(delegate(KeyValuePair<int, IPlaybackMarker> m)
			{
				m.Value.DataModified -= OnDataModified;
				m.Value.TimestampChanged -= SortMarkers;
				IPlaybackMarker playbackMarker = base.Collection.ElementAtOrDefault(m.Key);
				if (playbackMarker != null)
				{
					base.Collection.Remove(playbackMarker);
				}
			});
		};
		action();
		UndoStack?.Commit(UndoActionTypes.RemovePlaybackMarker.ToAction(), delegate
		{
			itemIndices.ForEach(delegate(KeyValuePair<int, IPlaybackMarker> m)
			{
				m.Value.DataModified += OnDataModified;
				m.Value.TimestampChanged += SortMarkers;
				base.Collection.Insert(m.Key, m.Value);
			});
		}, action, null, null, autoFinalize: true);
	}

	private void SortMarkers()
	{
		base.Collection.SelectionSort((IPlaybackMarker lhs, IPlaybackMarker rhs) => lhs.Timestamp > rhs.Timestamp, base.Collection.Move);
	}

	public void Serialize(Pro.SerializationInterop.RVProtoData.Action.Types.MediaType mediaAction)
	{
		mediaAction.Markers.AddRange(base.Collection.Select((IPlaybackMarker m) => m.Serialize()));
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Action.Types.MediaType mediaAction, ApplicationData? applicationData)
	{
		base.Collection.DeserializeCollection(mediaAction.Markers, (IPlaybackMarker m, Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.Types.PlaybackMarker p) => m.ID == p.Uuid.ToGuid(), delegate
		{
			PlaybackMarker playbackMarker = new PlaybackMarker();
			playbackMarker.UndoStack = UndoStack;
			playbackMarker.UpdateContainerId(ContainerId);
			return playbackMarker;
		}, delegate(IPlaybackMarker m)
		{
			AddMarker(m);
		}, RemoveMarker, delegate(IPlaybackMarker m, Pro.SerializationInterop.RVProtoData.Action.Types.MediaType.Types.PlaybackMarker p)
		{
			m.DataModified -= OnDataModified;
			m.Deserialize(p, applicationData);
			m.DataModified += OnDataModified;
		});
	}

	public void DraggedFrom(IEnumerable<IPlaybackMarker> items)
	{
		throw new NotSupportedException();
	}

	public void DroppedInto(IEnumerable<IPlaybackMarker> items, int index, bool isCopy)
	{
		throw new NotSupportedException();
	}

	public void MoveTo(IEnumerable<IPlaybackMarker> items, int index)
	{
		throw new NotSupportedException();
	}

	public void CutFrom(IEnumerable<IPlaybackMarker> items)
	{
		RemoveMarkers(items.ToArray());
	}

	public void PasteInto(IEnumerable<IPlaybackMarker> items, int index)
	{
		InsertMarkers(items.ToArray(), index);
	}

	public void Insert(IEnumerable<IActionRepository> newRepos, IActionRepository? repo, bool insertBefore)
	{
		if (newRepos != null)
		{
			int index = ((!(repo is PlaybackMarker value)) ? base.Count : (IndexOf(value) + ((!insertBefore) ? 1 : 0)));
			InsertMarkers(newRepos.OfType<PlaybackMarker>(), index);
			SortMarkers();
		}
	}

	public void UpdateContainerId(string newContainerId)
	{
		ContainerId = newContainerId;
		this.ForEach(delegate(IPlaybackMarker m)
		{
			m.UpdateContainerId(newContainerId);
		});
	}
}
