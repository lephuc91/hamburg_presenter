using System.ComponentModel;
using Pro.Common.Components;
using ProPresenter.Controller.NetworkAPI.Transmit;
using ProPresenter.DO;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Timer;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

internal class UtilityViewTimerTypeSelectorVM : LinkedNotifyPropertyChangedBase, ITimerTypeSelectorVM, INotifyPropertyChanged
{
	private readonly TimerData _timerData;

	private readonly INetworkCommandTrigger _linkTrigger;

	public TimerType SelectedTimerType
	{
		get
		{
			return _timerData.Source.TimerType;
		}
		set
		{
			if (_timerData.Source.TimerType != value)
			{
				DataVault.TimerDocument.Timers.ChangeTimerType(_timerData, value);
				TimersEditEvent.Publish(EditField.Type);
				_linkTrigger?.OnConfigureTimer(_timerData);
			}
		}
	}

	public UtilityViewTimerTypeSelectorVM(TimerData timerData, INetworkCommandTrigger linkTrigger)
	{
		_timerData = timerData;
		_linkTrigger = linkTrigger;
		LinkProperties("TimerType", "SelectedTimerType");
		_timerData.PropertyChanged += base.RaiseLinkedValues;
	}
}
