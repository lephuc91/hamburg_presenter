using System;
using System.ComponentModel;
using Pro.Common.Time;
using ProPresenter.DO;

namespace ProPresenter.UI.ViewModels;

public interface ITimecodeItemVM : INotifyPropertyChanged
{
	ITimeTriggerable Item { get; }

	TimeSlice Time { get; }

	string TimeStr { get; }

	string Name { get; }

	Guid SequenceID { get; }
}
