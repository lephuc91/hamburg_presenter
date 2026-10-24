using System;
using System.ComponentModel;
using Pro.DO.Triggering;

namespace ProPresenter.DO.Presentation;

public interface ITimelineItem : ITriggerable, INotifyPropertyChanged
{
	Guid ID { get; }

	string Name { get; }

	bool IsEnabled { get; }

	TimelineItemType TimelineItemType { get; }
}
