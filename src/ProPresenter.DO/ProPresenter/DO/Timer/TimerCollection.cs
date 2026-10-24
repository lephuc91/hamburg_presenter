using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Merged.Collections;
using Pro.Entity.Merged.Entities;
using Pro.Entity.Merged.Factory;
using Pro.Localization;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Events;

namespace ProPresenter.DO.Timer;

public class TimerCollection : ImmutableObservableCollection<TimerData>, ITimerCollection, IImmutableObservableCollection<TimerData>, IReadOnlyList<TimerData>, IEnumerable<TimerData>, IEnumerable, IReadOnlyCollection<TimerData>, INotifyEnumerableChanged<TimerData>, INotifyCollectionChanged, IDragDropNotifyEnumerableChanged<TimerData>, IDragDropCollection<TimerData>
{
	public UndoStack? UndoStack { get; set; }

	public event System.Action? DataModified;

	public ObjectBinder<TimerCollection, IMergedCollection<IMergedTimer>> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IMergedEntityFactory mergedEntityFactory, IComplexCollection<ITimer> remoteTimers, IComplexCollection<ILocalTimer> localTimers)
	{
		IMergedCollection<IMergedTimer> mergedCollection = mergedEntityFactory.CreateTimerCollection(remoteTimers, localTimers);
		ObjectBinder<TimerCollection, IMergedCollection<IMergedTimer>> objectBinder = new ObjectBinder<TimerCollection, IMergedCollection<IMergedTimer>>(this, mergedCollection);
		objectBinder.RegisterChildDisposable(() => mergedCollection);
		objectBinder.Bind((TimerCollection l) => l.WhenCollectionChanges(), (IMergedCollection<IMergedTimer> r) => r.WhenCollectionChanges, delegate(TimerCollection l, IMergedCollection<IMergedTimer> r)
		{
			r.SynchronizeFrom(l, (TimerData m, IMergedTimer e) => m.ID == e.Uuid.Value, delegate(TimerData m)
			{
				IMergedTimer mergedTimer = mergedEntityFactory.CreateMergedTimer(m.ID);
				IReadOnlyObjectBinder<TimerData, IMergedTimer> readOnlyObjectBinder = m.Bind(scheduler, entityFactory, mergedTimer);
				readOnlyObjectBinder.InitializeRightFromLeft();
				mergedTimer.RegisterLinkedDisposable(readOnlyObjectBinder);
				return mergedTimer;
			});
		}, delegate(IMergedCollection<IMergedTimer> r, TimerCollection l)
		{
			r.Items.SynchronizeTo(l.Collection, (IMergedTimer e, TimerData m) => m.ID == e.Uuid.Value, delegate(IMergedTimer e, int i)
			{
				TimerData timerData = new TimerData();
				IReadOnlyObjectBinder<TimerData, IMergedTimer> readOnlyObjectBinder2 = timerData.Bind(scheduler, entityFactory, e);
				readOnlyObjectBinder2.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(readOnlyObjectBinder2);
				l.InsertTimer(timerData, i);
			}, l.Collection.Move, delegate(int i)
			{
				TimerData timerData2 = l.ElementAtOrDefault(i);
				if (timerData2 != null)
				{
					l.RemoveTimer(timerData2);
				}
			});
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	public TimerCollection()
	{
		base.CollectionChanged += delegate
		{
			OnDataModified();
		};
	}

	public void ChangeTimerType(TimerData selectedTimer, TimerType newType)
	{
		base.Collection.FirstOrDefault((TimerData i) => i.ID == selectedTimer.ID)?.UpdateSource(newType);
	}

	public void AddNewCountdownTimer(string name, TimeSlice defaultDuration, bool allowOverrun = false)
	{
		CountdownTimer source = new CountdownTimer(defaultDuration)
		{
			IsOverRunAllowed = allowOverrun
		};
		AddTimer(new TimerData(source, null)
		{
			Name = name
		});
	}

	public void AddNewCountdownToTimeTimer(string name, TimeSlice defaultDuration)
	{
		AddNewCountdownToTimeTimer(name, defaultDuration, TimeFormat.AM);
	}

	public void AddNewCountdownToTimeTimer(string name, TimeSlice endTime, TimeFormat timeFormat, bool allowOverrun = false)
	{
		CountdownToTime source = new CountdownToTime(endTime)
		{
			TimeFormat = timeFormat,
			IsOverRunAllowed = allowOverrun
		};
		AddTimer(new TimerData(source, null)
		{
			Name = name
		});
	}

	public void AddNewElapsedTimer(string name)
	{
		AddNewElapsedTimer(name, default(TimeSlice), hasEndTime: false);
	}

	public void AddNewElapsedTimer(string name, TimeSlice duration, bool hasEndTime, bool allowOverrun = false)
	{
		AddNewElapsedTimer(name, TimeSlice.Zero, duration, hasEndTime, allowOverrun);
	}

	public void AddNewElapsedTimer(string name, TimeSlice startTime, TimeSlice duration, bool hasEndTime, bool allowOverrun = false)
	{
		ElapsedTime source = new ElapsedTime
		{
			HasEndTime = hasEndTime,
			StartTime = startTime,
			EndTime = duration,
			IsOverRunAllowed = allowOverrun
		};
		AddTimer(new TimerData(source, null)
		{
			Name = name
		});
	}

	public void AddTimer(TimerData timer)
	{
		InsertTimer(timer, base.Collection.Count());
	}

	public void InsertTimer(TimerData timer, int index = -1)
	{
		timer.UndoStack = UndoStack;
		timer.DataModified += TimerData_DataModified;
		base.Collection.Insert(base.Collection.ClampIndexExclusive(index), timer);
		UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.AddTimer), delegate
		{
			RemoveTimer(timer);
		}, delegate
		{
			InsertTimer(timer, index);
		}, null, null, autoFinalize: true);
	}

	private void OnInsert(int index, IEnumerable<TimerData> timers, bool autoFinalize = true)
	{
		UndoStack?.BeginCommit(UndoActionTypes.AddTimer.ToAction());
		timers.ForEach(delegate(TimerData m)
		{
			InsertTimer(m, index++);
		});
		UndoStack?.EndCommit(null, null, autoFinalize);
	}

	public void Reset()
	{
		base.Collection.ToArray().ForEach(RemoveTimer);
		LoadDefaultTimers();
	}

	public void RemoveTimer(TimerData timer)
	{
		int itemIndex = base.Collection.IndexOf(timer);
		timer.DataModified -= TimerData_DataModified;
		base.Collection.Remove(timer);
		UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.RemoveTimer), delegate
		{
			InsertTimer(timer, itemIndex);
		}, delegate
		{
			RemoveTimer(timer);
		}, null, null, autoFinalize: true);
	}

	public void RemoveTimers(IEnumerable<TimerData> timers)
	{
		timers.ForEach(RemoveTimer);
	}

	private void TimerData_DataModified(TimerSourceBase<TimerBase> timer)
	{
		OnDataModified();
		TimerUpdated.Publish();
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
		TimerUpdated.Publish();
	}

	internal void LoadDefaultTimers()
	{
		AddNewCountdownTimer(LocalizedStrings.Get("TIMERS_WINDOW_DEFAULT_COUNTDOWN_TIMER_name"), TimeSlice.FromMinutes(5.0));
		AddNewCountdownToTimeTimer(LocalizedStrings.Get("TIMERS_WINDOW_DEFAULT_COUNTDOWN_TO_TIME_TIMER_name"), TimeSlice.FromHours(17.0));
		AddNewCountdownTimer(LocalizedStrings.Get("TIMERS_WINDOW_DEFAULT_ELAPSED_TIMER_name"), TimeSlice.FromMinutes(15.0));
	}

	public IEnumerable<Pro.SerializationInterop.RVProtoData.Timer> Serialize()
	{
		return base.Collection.Select((TimerData t) => t.Serialize());
	}

	public void Deserialize(IEnumerable<Pro.SerializationInterop.RVProtoData.Timer> protoTimers, bool removeExisting)
	{
		UndoStack?.StartIgnoring();
		base.Collection.DeserializeCollection(protoTimers, (TimerData t, Pro.SerializationInterop.RVProtoData.Timer p) => t.ID == p.Uuid.ToGuid(), delegate(Pro.SerializationInterop.RVProtoData.Timer p)
		{
			TimerData timerData = new TimerData();
			if (base.Collection.Any((TimerData t) => t.ID == p.Uuid.ToGuid()))
			{
				p.Uuid = Guid.NewGuid().ToUUID();
			}
			timerData.UpdateSource(p.Configuration.TimerTypeCase.ToTimerType());
			return timerData;
		}, AddTimer, delegate(TimerData t)
		{
			if (removeExisting)
			{
				RemoveTimer(t);
			}
		}, delegate(TimerData t, Pro.SerializationInterop.RVProtoData.Timer p)
		{
			t.DataModified -= TimerData_DataModified;
			t.Deserialize(p);
			t.DataModified += TimerData_DataModified;
		});
		UndoStack?.StopIgnoring();
	}

	public void DraggedFrom(IEnumerable<TimerData> items)
	{
	}

	public void DroppedInto(IEnumerable<TimerData> items, int index, bool isCopy)
	{
		UndoStack?.BeginCommit(UndoActionTypes.MoveTimer.ToAction());
		items = (isCopy ? items.CloneItems() : items);
		OnInsert(index, items);
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	public void MoveTo(IEnumerable<TimerData> items, int index)
	{
		TimerData timerData = items.FirstOrDefault();
		int origIndex = ((timerData == null) ? (-1) : base.Collection.IndexOf(timerData));
		if (origIndex > index)
		{
			origIndex++;
		}
		base.Collection.MoveTo(items, index);
		UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MoveTimer), delegate
		{
			MoveTo(items, origIndex);
		}, delegate
		{
			MoveTo(items, index);
		}, null, null, autoFinalize: true);
	}
}
