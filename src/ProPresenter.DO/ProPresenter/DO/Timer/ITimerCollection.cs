using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Time;

namespace ProPresenter.DO.Timer;

public interface ITimerCollection : IImmutableObservableCollection<TimerData>, IReadOnlyList<TimerData>, IEnumerable<TimerData>, IEnumerable, IReadOnlyCollection<TimerData>, INotifyEnumerableChanged<TimerData>, INotifyCollectionChanged, IDragDropNotifyEnumerableChanged<TimerData>, IDragDropCollection<TimerData>
{
	UndoStack? UndoStack { get; set; }

	event Action? DataModified;

	void AddNewCountdownTimer(string name, TimeSlice defaultDuration, bool allowOverrun = false);

	void AddNewCountdownToTimeTimer(string name, TimeSlice defaultDuration);

	void AddNewCountdownToTimeTimer(string name, TimeSlice endTime, TimeFormat timeFormat, bool allowOverrun = false);

	void AddNewElapsedTimer(string name);

	void AddNewElapsedTimer(string name, TimeSlice duration, bool hasEndTime, bool allowOverrun = false);

	void AddNewElapsedTimer(string name, TimeSlice startTime, TimeSlice duration, bool hasEndTime, bool allowOverrun = false);

	void AddTimer(TimerData timer);

	void ChangeTimerType(TimerData selectedTimer, TimerType newType);

	void InsertTimer(TimerData timer, int index = -1);

	void RemoveTimer(TimerData timer);

	void RemoveTimers(IEnumerable<TimerData> timers);

	void Reset();
}
