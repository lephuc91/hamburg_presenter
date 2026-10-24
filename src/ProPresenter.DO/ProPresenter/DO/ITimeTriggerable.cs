using System;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.Time;
using Pro.DO.Triggering;

namespace ProPresenter.DO;

public interface ITimeTriggerable : ICloneable<ITimeTriggerable>, INotifyPropertyChanged
{
	Guid ID { get; }

	ITriggerable Item { get; }

	TimeSlice TriggerTime { get; }

	string Name { get; }

	TimeSlice Offset { get; }

	event Action? DataModified;
}
