using System;
using System.ComponentModel;
using Pro.Common.Time;
using Pro.DO.Triggering;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.ViewModels;

public interface ITimerVM : ITriggerable, INotifyPropertyChanged
{
	Guid ID { get; }

	ITimerTypeSelectorVM TimerTypeSelectorVM { get; }

	TimerType TimerType { get; }

	TimerFormatData Format { get; }

	string Name { get; set; }

	bool Overrun { get; set; }

	TimeSlice StartTime { get; set; }

	TimeSlice EndTime { get; set; }

	string RunningTime { get; }

	TimerState State { get; set; }

	bool IsExpanded { get; set; }
}
