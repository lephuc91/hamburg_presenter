using System;
using System.Collections.Generic;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Timer;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.Actions;

public class TimerDialogVM : ActionDialogContentVM
{
	public IEnumerable<TimerData> Timers => DataVault.TimerDocument.Timers;

	public ICommand<TimerData> SelectTimerCommand => new RelayCommand<TimerData>(OnSelectTimerCommand, (TimerData t) => base.ActionStore.CanAssignData(t, base.Action));

	public ICommand<TimerType> ChangeConfigurationCommand => new RelayCommand<TimerType>(OnChangeConfigurationCommand);

	public TimerAction? TimerAction => base.Action as TimerAction;

	private void OnSelectTimerCommand(TimerData timer)
	{
		TimerAction?.SetIdentifier(timer);
	}

	private void OnChangeConfigurationCommand(TimerType timerType)
	{
		if (TimerAction?.Configuration != null && TimerAction.Configuration.TimerType != timerType)
		{
			TimerAction.Configuration = getConfiguration();
		}
		TimerBase getConfiguration()
		{
			return timerType switch
			{
				TimerType.Countdown => new CountdownTimer(), 
				TimerType.CountdownToTime => new CountdownToTime(), 
				TimerType.ElapsedTime => new ElapsedTime(), 
				_ => throw new NotSupportedException(), 
			};
		}
	}

	protected override void OnContextChanged(IActionDialogContext? oldValue, IActionDialogContext? newValue)
	{
		base.OnContextChanged(oldValue, newValue);
		OnPropertyChanged("TimerAction");
	}
}
