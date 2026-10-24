using System.ComponentModel;
using Pro.Common.Components;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.ViewModels;

public class HeaderViewTimerTypeSelectorVM : LinkedNotifyPropertyChangedBase, ITimerTypeSelectorVM, INotifyPropertyChanged
{
	private TimerData? _selectedTimer;

	public TimerType SelectedTimerType
	{
		get
		{
			return SelectedTimer?.Source.TimerType ?? TimerType.Countdown;
		}
		set
		{
			SelectedTimer?.UpdateSource(value);
		}
	}

	public TimerData? SelectedTimer
	{
		get
		{
			return _selectedTimer;
		}
		set
		{
			SetValue("SelectedTimer", ref _selectedTimer, value, OnSelectedTimerChanged);
		}
	}

	private void OnSelectedTimerChanged(TimerData? oldValue, TimerData? newValue)
	{
		if (oldValue != null)
		{
			oldValue.PropertyChanged -= base.RaiseLinkedValues;
		}
		if (newValue != null)
		{
			newValue.PropertyChanged += base.RaiseLinkedValues;
		}
		OnPropertyChanged("SelectedTimerType");
	}
}
